using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using MetadataExtractor;
using Accord.Video.DirectShow;
using System.IO;
using System.Security.Cryptography;

namespace Media_Sorter
{
    public class CFileManager
    {
        public delegate void DImageReady(int fileId, Image img, int progress);
        public delegate void DProgressChanged(int progress);
        public delegate void DWorkerCompleted(bool cancel);
        public delegate void DWorkerCompletedExtended(bool cancel, int[] failedFileIDs);
        public delegate void DErrorOccured(string message);

        int id;
        Dictionary<int, CFile> files;
        Thread bgt;

        public bool Cancel { private get;  set; }

        public CFileManager()
        {
            files = new Dictionary<int, CFile>();
        }

        ~CFileManager()
        {
            files.Clear();
            files = null;
        }

        public void AddFile(int folderId, string name, string path, string extension)
        {
            if (files.Values.Count(f => f.Path.Equals(path)) == 0)
                files.Add(id, new CFile(id++, folderId, name, path, extension));
        }

        public string GetExtension(int id)
        {
            if (!files.ContainsKey(id))
                throw new ArgumentException();

            return files[id].Extension;
        }

        public Image GetImage(int id)
        {
            if (!files.ContainsKey(id))
                throw new ArgumentException();

            return files[id].Image;
        }

        public IEnumerable<Tuple<int, string>> GetFileNames(int folderId)
        {
            foreach (var f in files.Values.Where(f => f.FolderID == folderId))
                yield return new Tuple<int, string>(f.ID, f.Name);
        }

        public IEnumerable<Tuple<int, string>> GetFileNames1(int sortedFolderId)
        {
            foreach (var f in files.Values.Where(f => f.SortedFolderID == sortedFolderId))
                yield return new Tuple<int, string>(f.ID, f.Name);
        }

        public string GetFileName(int id)
        {
            return files[id].Name;
        }

        public void Clear()
        {
            id = 0;
            files.Clear();

            if (bgt != null && bgt.IsAlive)
            {
                bgt.Abort();
                bgt.Join();
            }
        }

        public void LoadImages(int folderId, DImageReady imageReady, DWorkerCompleted workerCompleted, int width = 64, int height = 64)
        {
            var seededFiles = files.Values.Where(f => f.FolderID == folderId).ToArray();

            if (bgt != null)
            {
                bgt.Abort();
                bgt.Join();
                bgt = null;
            }

            bgt = new Thread
            (
                () =>
                {
                    int count = seededFiles.Length;
                    for (int i = 0; i < count; i++)
                    {
                        var file = seededFiles[i];

                        if (!file.ImageScanned || file.Image == Properties.Resources.long_image)
                        {
                            switch (file.Extension)
                            {
                                case ".mp4":
                                case ".mov":
                                    {
                                        try
                                        {
                                            int waitingTime = 2000;
                                            int time = 0;

                                            Image image = null;

                                            FileVideoSource source = new FileVideoSource(file.Path);

                                            source.NewFrame += (ss, ee) =>
                                            {
                                                image = new Bitmap(ee.Frame);

                                                source.SignalToStop();
                                            };

                                            source.Start();

                                            while ((time < waitingTime) && image == null && source != null)
                                            {
                                                time += 50;
                                                Thread.Sleep(50);
                                            }

                                            source.WaitForStop();
                                            source = null;

                                            if (image == null)
                                                throw new OutOfMemoryException();

                                            file.SetImage(ResizeImage(image, width, height));

                                            image.Dispose();
                                            image = null;
                                        }
                                        catch (OutOfMemoryException oome)
                                        {
                                            file.SetImage(Properties.Resources.long_image);
                                            file.BadFile = true;
                                        }

                                        break;
                                    }
                                default:
                                    {
                                        try
                                        {
                                            file.SetImage(ResizeImage(Image.FromFile(file.Path), width, height));
                                        }
                                        catch (OutOfMemoryException oome)
                                        {
                                            file.SetImage(Properties.Resources.bad_image);
                                            file.BadFile = true;
                                        }

                                        break;
                                    }
                            }
                        }

                        if (imageReady != null)
                            imageReady.Invoke(file.ID, file.Image, Convert.ToInt32(100.0 * (i + 1) / count));
                    }

                    if (workerCompleted != null)
                        workerCompleted.Invoke(false);

                    bgt = null;
                }
            );

            bgt.Start();
        }

        public void LoadImages1(int[] sortedFolderIds, DImageReady imageReady, DWorkerCompleted workerCompleted, int width = 64, int height = 64)
        {
            List<CFile> seededFiles = new List<CFile>();
            for (int i = 0; i < sortedFolderIds.Length; i++)
                seededFiles.AddRange(files.Values.Where(f => f.SortedFolderID == sortedFolderIds[i] && !f.BadFile));

            if (bgt != null)
            {
                bgt.Abort();
                bgt.Join();
                bgt = null;
            }

            bgt = new Thread
            (
                () =>
                {
                    int count = seededFiles.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var file = seededFiles[i];

                        if (!file.ImageScanned)
                        {
                            switch (file.Extension)
                            {
                                case ".mp4":
                                case ".mov":
                                    {
                                        try
                                        {
                                            int waitingTime = 2000;
                                            int time = 0;

                                            Image image = null;

                                            FileVideoSource source = new FileVideoSource(file.Path);

                                            source.NewFrame += (ss, ee) =>
                                            {
                                                image = new Bitmap(ee.Frame);

                                                source.SignalToStop();
                                            };

                                            source.Start();

                                            while ((time < waitingTime) && image == null && source != null)
                                            {
                                                time += 50;
                                                Thread.Sleep(50);
                                            }

                                            if (image == null)
                                                throw new OutOfMemoryException();

                                            file.SetImage(ResizeImage(image, width, height));

                                            image.Dispose();
                                            image = null;

                                            source.WaitForStop();
                                            source = null;
                                        }
                                        catch (OutOfMemoryException oome)
                                        {
                                            file.SetImage(Properties.Resources.long_image);
                                        }

                                        break;
                                    }
                                default:
                                    {
                                        try
                                        {
                                            file.SetImage(ResizeImage(Image.FromFile(file.Path), width, height));
                                        }
                                        catch (OutOfMemoryException oome)
                                        {
                                            file.SetImage(Properties.Resources.bad_image);
                                        }

                                        break;
                                    }
                            }
                        }

                        if (imageReady != null)
                            imageReady.Invoke(file.ID, file.Image, Convert.ToInt32(100.0 * (i + 1) / count));
                    }

                    if (workerCompleted != null)
                        workerCompleted.Invoke(false);

                    bgt = null;
                }
            );

            bgt.Start();
        }

        private Image ResizeImage(Image original, int width, int height)
        {
            Image result = new Bitmap(width, height);

            //соблюдение пропорций
            Rectangle canvas;

            if (original.Width > width || original.Height > height)
            {
                if (original.Width > original.Height)
                {
                    float ratio = 1.0f * original.Height / original.Width;
                    int scaledHeight = Convert.ToInt32(height * ratio);
                    canvas = new Rectangle(0, height / 2 - scaledHeight / 2, width, scaledHeight);
                }
                else
                {
                    float ratio = 1.0f * original.Width / original.Height;
                    int scaledWidth = Convert.ToInt32(width * ratio);
                    canvas = new Rectangle(width / 2 - scaledWidth / 2, 0, scaledWidth, height);
                }
            }
            else
                canvas = new Rectangle(width / 2 - original.Width / 2, height / 2 - original.Height / 2, original.Width, original.Height);

            Graphics g = Graphics.FromImage(result);
            g.DrawImage(original, canvas, new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);

            g.Dispose();
            g = null;
            original.Dispose();
            original = null;

            return result;
        }

        public void OpenFile(int id)
        {
            Process.Start(files[id].Path);
        }

        public void DeleteFiles(int[] ids, DProgressChanged progressChanged, DWorkerCompleted workerCompleted)
        {
            Cancel = false;

            BackgroundWorker bw = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            bw.DoWork += (ss, ee) =>
            {
                BackgroundWorker worker = ss as BackgroundWorker;

                int length = ids.Length;
                for (int i = 0; i < length; i++)
                {
                    if (Cancel)
                    {
                        worker.CancelAsync();
                        break;
                    }

                    int _id = ids[i];

                    try
                    {
                        FileSystem.DeleteFile(files[_id].Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
                    }
                    catch (OperationCanceledException oce)
                    {
                        worker.ReportProgress(Convert.ToInt32(100.0 * (i + 1) / length));
                        continue;
                    }

                    files.Remove(_id);

                    worker.ReportProgress(Convert.ToInt32(100.0 * (i + 1) / length));
                }
            };

            bw.ProgressChanged += (ss, ee) =>
            {
                if (progressChanged != null)
                    progressChanged.Invoke(ee.ProgressPercentage);
            };

            bw.RunWorkerCompleted += (ss, ee) =>
            {
                if (workerCompleted != null)
                    workerCompleted.Invoke(!ee.Cancelled);

                bw.Dispose();
                bw = null;
            };

            bw.RunWorkerAsync();
        }

        public int GetFolderIdByFileId(int id)
        {
            return files[id].FolderID;
        }

        public IEnumerable<string> GetMetadata(int id)
        {
            foreach (var data in ImageMetadataReader.ReadMetadata(files[id].Path))
                foreach (var tag in data.Tags)
                    yield return string.Format("[{0}] {1}: {2}", data.Name, tag.Name, tag.Description.Replace("\0", ""));
        }

        public Tuple<string, string>[] GetMetadata(int id, CPattern[] patterns)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            try
            {
                var directories = ImageMetadataReader.ReadMetadata(files[id].Path);

                for (int i = 0; i < patterns.Length; i++)
                {
                    CPattern pattern = patterns[i];

                    MetadataExtractor.Directory directory = directories.FirstOrDefault(d => d.Name == pattern.DirectoryName);
                    if (directory == null)
                        continue;

                    IEnumerable<Tag> tags = directory.Tags;
                    Tag tag = tags.FirstOrDefault(t => t.Name == pattern.TagName);
                    if (tag == null)
                        continue;

                    result.Add(new Tuple<string, string>(pattern.Pattern, tag.Description.Replace("\0", "")));
                }
            }
            catch (ImageProcessingException ipe)
            {
                return null;
            }

            return result.ToArray();
        }

        public int[] GetFileIdsByFolderId(int folderId)
        {
            return files.Values.Where(f => f.FolderID == folderId && !f.BadFile).Select(f => f.ID).ToArray();
        }

        public void SetMetadata(int id, string year, string month, string day, string hour, string minute, string seconds)
        {
            CFile file = files[id];

            file.Year = year;
            file.Month = month;
            file.Day = day;
            file.Hour = hour;
            file.Minute = minute;
            file.Seconds = seconds;
        }

        public void SetSortedFolderId(int id, int sortedFolderId)
        {
            files[id].SortedFolderID = sortedFolderId;
        }

        public int GetFileAmountBySortedFolderId(int sortedFolderId)
        {
            return files.Values.Count(f => f.SortedFolderID == sortedFolderId);
        }

        public IEnumerable<CFile> GetFiles()
        {
            foreach (CFile file in files.Values)
                yield return file;
        }

        public void OperateFiles(CDestinationManager destinationManager, CSortedFolderManager sortedFolderManager, bool copy, bool renaming, DProgressChanged progressChanged, DWorkerCompletedExtended workerCompleted, DErrorOccured errorOccured)
        {
            List<int> failedFileIDs = new List<int>();

            BackgroundWorker bw = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            bw.DoWork += (ss, ee) =>
            {
                BackgroundWorker worker = ss as BackgroundWorker;

                List<int> checkedSortedFolders = new List<int>(sortedFolderManager.GetEnabledSortedFolderIDs());

                int total = 0;
                for (int i = 0; i < checkedSortedFolders.Count; i++)
                    if (GetFileAmountBySortedFolderId(checkedSortedFolders[i]) == 0)
                        checkedSortedFolders.RemoveAt(i);

                var seededDestinations = destinationManager.Destinations.Where(d => d.Actual).ToList();
                var seededFiles = files.Values.Where(f => checkedSortedFolders.Contains(f.SortedFolderID)).ToList();
                
                total = seededFiles.Count * seededDestinations.Count;

                for (int d = 0; d < seededDestinations.Count; d++)
                {
                    var destination = seededDestinations[d];

                    string destinationPath = destination.Path;

                    for (int f = 0; f < seededFiles.Count; f++)
                    {
                        var file = seededFiles[f];

                        int sortedFolderId = file.SortedFolderID;

                        string outputPath = destinationPath + "\\" + sortedFolderManager.GetPathById(sortedFolderId);

                        //создаем директорию, если такой нет
                        if (!System.IO.Directory.Exists(outputPath))
                            System.IO.Directory.CreateDirectory(outputPath);

                        string fileName;
                        if (renaming)
                        {
                            fileName = Properties.Settings.Default.RenamingTemplate;

                            fileName = fileName.Replace("YYYY", file.Year);
                            fileName = fileName.Replace("MM", file.Month);
                            fileName = fileName.Replace("DD", file.Day);
                            fileName = fileName.Replace("hh", file.Hour);
                            fileName = fileName.Replace("mm", file.Minute);
                            fileName = fileName.Replace("ss", file.Seconds);

                            fileName += file.Extension;
                        }
                        else
                            fileName = file.Name;

                        string outputFilePath = outputPath + "\\" + fileName;

                        int tries = 0;
                        bool copySuccess = false;
                        bool fileExists = false;
                        do
                        {
                            try
                            {
                                File.Copy(file.Path, outputFilePath);
                            }
                            catch (IOException ioe)
                            {
                                byte[] original = GetFileMD5(file.Path);
                                byte[] copyFile = GetFileMD5(outputFilePath);

                                fileExists = Equals(original, copyFile);

                                //если такой же файл существует, то пропускаем его
                                if (fileExists)
                                    copySuccess = true;
                                //если имена одинаковые, но файлы разные
                                else
                                {
                                    //TODO функция добавления порядкового номера разным фотографиям с одинаковым именем

                                    //считаем, сколько таких же файлов
                                    int count = 0;
                                    string[] suspiciousFiles = System.IO.Directory.GetFiles(outputPath);
                                    for (int i = 0; i < suspiciousFiles.Length; i++)
                                    {
                                        byte[] bytes = GetFileMD5(suspiciousFiles[i]);

                                        if (Equals(original, bytes))
                                        {
                                            copySuccess = true;
                                            break;
                                        }
                                        else if (suspiciousFiles[i].Contains(Path.GetFileNameWithoutExtension(fileName)))
                                            count++;

                                        bytes = null;
                                    }

                                    if (!copySuccess && count > 0)
                                    {
                                        //меняем имя файла и путь
                                        fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + count.ToString() + file.Extension;
                                        outputFilePath = outputPath + "\\" + fileName;
                                        //tries++;
                                    }

                                    suspiciousFiles = null;
                                }

                                copyFile = null;
                                original = null;

                                continue;
                            }

                            //если файл скопирован неудачно, то удаляем его
                            copySuccess = CheckFilesMD5(file.Path, outputFilePath);
                            if (!copySuccess)
                            {
                                File.Delete(outputFilePath);
                                tries++;
                            }
                        }
                        while (!copySuccess && tries < 5);

                        worker.ReportProgress(Convert.ToInt32(100.0 * (d * f + f + 1) / total));

                        if (fileExists)
                            continue;

                        if (tries == 5)
                        {
                            failedFileIDs.Add(file.ID);
                            //throw new IOException("Не удалось корректно скопировать файл " + file.Path);
                        }

                        if (!copy)
                        {
                            if (d == seededDestinations.Count - 1)
                            {
                                File.Delete(file.Path);
                                files.Remove(file.ID);
                                file = null;
                            }
                        }
                    }
                }

                checkedSortedFolders = null;
            };

            bw.ProgressChanged += (ss, ee) =>
            {
                if (progressChanged != null)
                    progressChanged.Invoke(ee.ProgressPercentage);
            };

            bw.RunWorkerCompleted += (ss, ee) =>
            {
                bool cancelled = ee.Cancelled;

                if (ee.Error != null)
                {
                    if (errorOccured != null)
                        errorOccured.Invoke(ee.Error.Message);

                    cancelled = true;
                }

                if (workerCompleted != null)
                {
                    if (failedFileIDs.Count > 0)
                        workerCompleted.Invoke(cancelled, failedFileIDs.ToArray());
                    else
                        workerCompleted.Invoke(cancelled, null);
                }

                failedFileIDs.Clear();
                failedFileIDs = null;

                bw.Dispose();
                bw = null;
            };

            bw.RunWorkerAsync();
        }

        private byte[] GetFileMD5(string path)
        {
            byte[] result = null;

            using (Stream stream1 = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (MD5 md5 = MD5.Create())
                    result = md5.ComputeHash(stream1);

            return result;
        }

        private bool CheckFilesMD5(string file1, string file2)
        {
            bool result = false;

            using (Stream stream1 = new FileStream(file1, FileMode.Open, FileAccess.Read))
            {
                using (Stream stream2 = new FileStream(file2, FileMode.Open, FileAccess.Read))
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] bytes1 = md5.ComputeHash(stream1);
                        byte[] bytes2 = md5.ComputeHash(stream2);

                        result = Equals(bytes1, bytes2);

                        bytes1 = null;
                        bytes2 = null;
                    }
                }
            }

            return result;
        }

        private bool Equals(byte[] arr1, byte[] arr2)
        {
            bool result = true;

            if (arr1.Length != arr2.Length)
                return false;

            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i])
                {
                    result = false;
                    break;
                }

            return result;
        }

        public void ClearSortedFolderIDs()
        {
            for (int i = 0; i < files.Values.Count; i++)
                files.Values.ElementAt(i).SortedFolderID = -2;
        }

        public string GetPath(int id)
        {
            return files[id].Path;
        }

        public void ResetSortedFolderID(int sortedFolderId)
        {
            for (int i = 0; i < files.Count; i++)
                if (files[i].SortedFolderID == sortedFolderId)
                    files[i].SortedFolderID = -2;
        }
    }
}
