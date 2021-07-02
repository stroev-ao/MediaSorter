using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Media_Sorter
{
    public class CSortedFolderManager
    {
        public delegate void DWorkerCompleted();

        int id;
        Dictionary<int, CSortedFolder> folders;

        Dictionary<string, string> monthsRus;
        Dictionary<string, string> monthsEng;

        public CSortedFolder[] Folders { get { return folders.Values.ToArray(); } }

        public CSortedFolderManager()
        {
            folders = new Dictionary<int, CSortedFolder>();

            monthsRus = new Dictionary<string, string>();
            monthsRus.Add("янв", "01");
            monthsRus.Add("фев", "02");
            monthsRus.Add("мар", "03");
            monthsRus.Add("апр", "04");
            monthsRus.Add("май", "05");
            monthsRus.Add("июн", "06");
            monthsRus.Add("июл", "07");
            monthsRus.Add("авг", "08");
            monthsRus.Add("сен", "09");
            monthsRus.Add("окт", "10");
            monthsRus.Add("ноя", "11");
            monthsRus.Add("дек", "12");

            monthsEng = new Dictionary<string, string>();
            monthsEng.Add("jan", "01");
            monthsEng.Add("feb", "02");
            monthsEng.Add("mar", "03");
            monthsEng.Add("apr", "04");
            monthsEng.Add("may", "05");
            monthsEng.Add("jun", "06");
            monthsEng.Add("jul", "07");
            monthsEng.Add("aug", "08");
            monthsEng.Add("sep", "09");
            monthsEng.Add("oct", "10");
            monthsEng.Add("nov", "11");
            monthsEng.Add("dec", "12");
        }

        ~CSortedFolderManager()
        {
            monthsRus.Clear();
            monthsRus = null;

            monthsEng.Clear();
            monthsEng = null;

            folders.Clear();
            folders = null;
        }

        public void Clear()
        {
            id = 0;
            folders.Clear();
        }

        public int AddFolder(int parentId, string name, string path)
        {
            folders.Add(id, new CSortedFolder(id, parentId, name, path));

            return id++;
        }

        private int GetSortedFolderId(string name, int parentId)
        {
            var folder = folders.Values.FirstOrDefault(f => f.Name == name && f.ParentID == parentId);
            if (folder == null)
                return -1;

            return folders.FirstOrDefault(f => f.Value == folder).Key;
        }

        public bool CreateFolder(string name, CFileManager fileManager)
        {
            if (folders.Values.Count(f => f.Name == name) > 0)
                return false;

            int lastId = folders.Values.Count > 0 ? folders.Values.Max(f => f.ID) + 1 : 0;
            string year = name.Substring(0, 4);
            string month = name.Substring(5, 2);

            var parentYear = folders.Values.FirstOrDefault(f => f.Name == year);
            if (parentYear == null)
            {
                folders.Add(lastId, new CSortedFolder(lastId++, -1, year, year));
                parentYear = folders.Values.Last();
            }

            var parentMonth = folders.Values.FirstOrDefault(f => f.Name == month);
            if (parentMonth == null)
            {
                folders.Add(lastId, new CSortedFolder(lastId++, parentYear.ID, month, year + "\\" + month));
                parentMonth = folders.Values.Last();
            }

            folders.Add(lastId, new CSortedFolder(lastId++, parentMonth.ID, name, year + "\\" + month + "\\" + name));

            id = lastId;

            //сортировка папок
            SortFolders(fileManager);

            return true;
        }

        public void DeleteFolder(int id, CFileManager fileManager)
        {
            var folder = folders.Values.FirstOrDefault(f => f.ID == id);
            if (folder == null)
                return;

            int[] childs = folders.Values.Where(f => f.ParentID == folder.ID).Select(f => f.ID).ToArray();
            for (int i = 0; i < childs.Length; i++)
                DeleteFolderChilds(childs[i], fileManager);

            folders.Remove(id);

            fileManager.ResetSortedFolderID(id);

            //сортировка папок
            SortFolders(fileManager);
        }

        private void DeleteFolderChilds(int id, CFileManager fileManager)
        {
            var folder = folders.Values.FirstOrDefault(f => f.ID == id);
            if (folder == null)
                return;

            int[] childs = folders.Values.Where(f => f.ParentID == folder.ID).Select(f => f.ID).ToArray();
            for (int i = 0; i < childs.Length; i++)
                DeleteFolderChilds(childs[i], fileManager);

            fileManager.ResetSortedFolderID(id);

            folders.Remove(id);
        }

        public void Analyze(int folderId, CFileManager fileManager, CPatternManager patternManager, DWorkerCompleted workerCompleted)
        {
            Thread thread = new Thread
            (
                () =>
                {
                    int[] fileIds = fileManager.GetFileIdsByFolderId(folderId);

                    CSortedFolder unknownDates = null;
                    if (!folders.ContainsKey(int.MaxValue))
                        unknownDates = new CSortedFolder(int.MaxValue, -1, "Неизвестные даты", "Неизвестные даты");
                    else
                        unknownDates = folders[int.MaxValue];

                    for (int i = 0; i < fileIds.Length; i++)
                    {
                        int id = fileIds[i];

                        string extensioin = fileManager.GetExtension(id);

                        CPattern[] patterns = patternManager.GetPatternsByExtension(extensioin);

                        if (patterns == null || patterns.Length == 0)
                            continue;

                        Tuple<string, string>[] values = fileManager.GetMetadata(id, patterns);

                        if (values == null || values.Length == 0)
                        {
                            fileManager.SetSortedFolderId(id, unknownDates.ID);
                            continue;
                        }

                        for (int j = 0; j < values.Length; j++)
                        {
                            string pattern = values[j].Item1;
                            string value = values[j].Item2;

                            string year = value.Substring(pattern.IndexOf("YYYY"), 4);

                            string month;
                            int idx = pattern.IndexOf("MMM");
                            if (idx < 0)
                                month = value.Substring(pattern.IndexOf("MM"), 2);
                            else
                            {
                                month = value.Substring(idx, 3).ToLower();

                                if (monthsRus.ContainsKey(month))
                                    month = monthsRus[month];
                                else if (monthsEng.ContainsKey(month))
                                    month = monthsEng[month];
                            }

                            string day = value.Substring(pattern.IndexOf("DD"), 2);
                            string hour = value.Substring(pattern.IndexOf("hh"), 2);
                            string minute = value.Substring(pattern.IndexOf("mm"), 2);
                            string seconds = value.Substring(pattern.IndexOf("ss"), 2);

                            fileManager.SetMetadata(id, year, month, day, hour, minute, seconds);

                            int sortedFolderIdYear = GetSortedFolderId(year, -1);
                            if (sortedFolderIdYear < 0)
                                sortedFolderIdYear = AddFolder(-1, year, year);

                            int sortedFolderIdMonth = GetSortedFolderId(month, sortedFolderIdYear);
                            if (sortedFolderIdMonth < 0)
                                sortedFolderIdMonth = AddFolder(sortedFolderIdYear, month, year + "\\" + month);

                            string dayFolderName = string.Format("{0}.{1}.{2}", year, month, day);
                            int sortedFolderIdDay = GetSortedFolderId(dayFolderName, sortedFolderIdMonth);
                            if (sortedFolderIdDay < 0)
                                sortedFolderIdDay = AddFolder(sortedFolderIdMonth, dayFolderName, year + "\\" + month + "\\" + dayFolderName);

                            fileManager.SetSortedFolderId(id, sortedFolderIdDay);

                            break;
                        }

                        values = null;
                        patterns = null;
                    }


                    if (fileManager.GetFileAmountBySortedFolderId(int.MaxValue) > 0)
                        folders.Add(int.MaxValue, unknownDates);
                    
                    unknownDates = null;

                    //перестановка индексов в алфавитном порядке
                    SortFolders(fileManager);

                    if (workerCompleted != null)
                        workerCompleted.Invoke();
                }
            );

            thread.Start();
        }

        private void SortFolders(CFileManager fileManager)
        {
            int counter = 0;
            List<CSortedFolder> sorted = new List<CSortedFolder>();
            Dictionary<int, int> idConcordance = new Dictionary<int, int>();

            var years = folders.Values.Where(f => f.ParentID == -1).OrderBy(f => f.Name).ToList();
            for (int i = 0; i < years.Count; i++)
            {
                var year = years[i];
                sorted.Add((CSortedFolder)year.Clone());
                year = sorted.Last();

                int oldId = year.ID;
                year.ID = counter++;
                idConcordance.Add(oldId, year.ID);

                var months = folders.Values.Where(f => f.ParentID == oldId).OrderBy(f => f.Name).ToList();
                for (int j = 0; j < months.Count; j++)
                {
                    var month = months[j];
                    sorted.Add((CSortedFolder)month.Clone());
                    month = sorted.Last();

                    int oldMonthId = month.ID;
                    month.ID = counter++;
                    month.ParentID = year.ID;
                    idConcordance.Add(oldMonthId, month.ID);

                    var days = folders.Values.Where(f => f.ParentID == oldMonthId).OrderBy(f => f.Name).ToList();
                    for (int k = 0; k < days.Count; k++)
                    {
                        var day = days[k];
                        sorted.Add((CSortedFolder)day.Clone());
                        day = sorted.Last();

                        int oldDayId = day.ID;
                        day.ID = counter++;
                        day.ParentID = month.ID;
                        idConcordance.Add(oldDayId, day.ID);
                    }
                }
            }

            folders.Clear();
            for (int i = 0; i < sorted.Count; i++)
                folders.Add(sorted[i].ID, sorted[i]);
            sorted.Clear();
            sorted = null;

            //перебиваем id сортированных папок для файлов
            foreach (CFile file in fileManager.GetFiles())
            {
                int fileId = file.SortedFolderID;

                if (idConcordance.ContainsKey(fileId))
                    file.SortedFolderID = idConcordance[fileId];
            }
            idConcordance.Clear();
            idConcordance = null;
        }

        public void SetCheckState(int id, bool state)
        {
            folders[id].Checked = state;
        }

        public int[] GetChildIDs(int id, bool forName = false)
        {
            if (forName)
                return folders.Values.Where(f => f.ParentID == id).Select(f => f.ID).ToArray();
            else
                return folders.Values.Where(f => f.ParentID == id && f.Checked).Select(f => f.ID).ToArray();
        }

        public int[] GetEnabledSortedFolderIDs()
        {
            return folders.Values.Where(f => f.Checked).Select(f => f.ID).ToArray();
        }

        public string GetPathById(int id)
        {
            return folders[id].Path;
        }
    }
}
