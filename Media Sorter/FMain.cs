using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Media_Sorter
{
    public partial class FMain : Form
    {
        private enum EState { Default = 0, Process = 1 };
        const string TITLE = "Media Sorter";
        CPatternManager patternManager;
        CFolderManager folderManager;
        CFileManager fileManager;
        CThreadManager threadManager;
        CSortedFolderManager sortedFolderManager;
        CDestinationManager destinationManager;
        System.Windows.Forms.Timer timerProcess;
        CImageBuffer imageBuffer;

        const int THREAD_LOAD_IMAGES = 0;
        const int THREAD_ANALYZING_FILES = 1;
        //const int THREAD_DELETE_FILES = 2;

        bool checkWork;
        bool initialization;
        bool inRightTree;
        bool readyToDragDrop;
        bool dragDrop;
        int[] draggedFileIDs;
        TreeNode lastSortedNode;

        Dictionary<int, string> threadText;

        public FMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            initialization = true;

            if (!File.Exists("Media Sorter.exe.config"))
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Не найден файл конфигурации. Работа приложения будет завершена", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                this.Close();
                return;
            }

            threadText = new Dictionary<int, string>();
            threadText.Add(THREAD_LOAD_IMAGES, "Загрузка миниатюр...");
            threadText.Add(THREAD_ANALYZING_FILES, "Анализ файлов...");

            threadManager = new CThreadManager();
            folderManager = new CFolderManager(new string[] { ".jpg", ".jpeg", ".png", ".mov", ".mp4" });
            fileManager = new CFileManager();
            patternManager = new CPatternManager();
            patternManager.LoadPattenrs();
            sortedFolderManager = new CSortedFolderManager();
            destinationManager = new CDestinationManager();

            imageBuffer = new CImageBuffer();
            imageBuffer.AddFrame(Properties.Resources.l0, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l1, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l2, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l3, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l4, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l5, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l6, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l7, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l8, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l9, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l10, 20, 20);
            imageBuffer.AddFrame(Properties.Resources.l11, 20, 20);

            timerProcess = new System.Windows.Forms.Timer() { Interval = 50 };
            timerProcess.Tick += (ss, ee) =>
            {
                pb_Progress.Invalidate();
            };

            this.Text = TITLE;
            ResizeSplitContainers();
            SetState(EState.Default);

            TreeNodeAmountChangedHandler(0);

            string lastPath = Properties.Settings.Default.LastPath;
            if (lastPath == "")
            {
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Properties.Settings.Default.LastPath = lastPath;
            }
            if (folderManager.CheckFolder(lastPath))
                SetRoot(lastPath);
        }

        private void FMain_Shown(object sender, EventArgs e)
        {
            initialization = false;
            Cursor.Current = Cursors.Default;
        }

        private void FMain_Resize(object sender, EventArgs e)
        {
            ResizeSplitContainers();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (initialization)
                return;

            Cursor.Current = Cursors.WaitCursor;

            Properties.Settings.Default.Save();

            patternManager.SavePatterns();
            patternManager = null;

            threadManager.Clear();
            threadManager = null;

            fileManager.Clear();
            fileManager = null;

            folderManager = null;

            sortedFolderManager = null;

            destinationManager = null;

            imageBuffer.Clear();
            imageBuffer = null;

            threadText.Clear();
            threadText = null;

            Cursor.Current = Cursors.Default;
        }

        private void tsb_SelectRoot_Click(object sender, EventArgs e)
        {
            string selectedPath = Properties.Settings.Default.LastPath;
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                SelectedPath = selectedPath
            };
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            selectedPath = fbd.SelectedPath;
            Properties.Settings.Default.LastPath = selectedPath;
            Properties.Settings.Default.Save();

            SetRoot(selectedPath);

            fbd.Dispose();
            fbd = null;

            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void SetRoot(string path)
        {
            fileManager.Clear();
            folderManager.Clear();

            tv_Explorer.Nodes.Clear();

            ClearSortedFolders();

            this.AddNode(null, path);
            tv_Explorer.Nodes[0].Expand();
            tv_Explorer.SelectedNode = tv_Explorer.Nodes[0];
            tv_Explorer_NodeMouseClick(tv_Explorer, new TreeNodeMouseClickEventArgs(tv_Explorer.Nodes[0], MouseButtons.Left, 1, 0, 0));
        }

        private void tv_Explorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "null")
            {
                e.Node.Nodes.RemoveAt(0);

                string path = folderManager.GetPath(Convert.ToInt32(e.Node.Tag));
                string[] subDirs = Directory.GetDirectories(path);
                for (int i = 0; i < subDirs.Length; i++)
                    AddNode(e.Node, subDirs[i]);
            }
        }

        private void tv_Explorer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tv_Explorer_NodeMouseClick(tv_Explorer, new TreeNodeMouseClickEventArgs(tv_Explorer.SelectedNode, MouseButtons.Left, 1, 0, 0));
                    break;
            }
        }

        private void tv_Explorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (e.Node == null || e.Node.Tag == null)
                return;

            inRightTree = false;
            tv_Explorer.HideSelection = inRightTree;
            tv_Sorting.HideSelection = !inRightTree;
            tv_Sorting.SelectedNode = null;
            tv_Sorting_AfterSelect(tv_Sorting, new TreeViewEventArgs(tv_Sorting.SelectedNode));

            bool value = false;
            tsb_Open.Enabled = value;
            tsb_OpenLocation.Enabled = value;
            tsb_Metadata.Enabled = value;
            tsb_DeleteFiles.Enabled = value;

            int folderId = Convert.ToInt32(e.Node.Tag);

            LoadFiles(folderId);
        }

        private void lv_Images_ItemActivate(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            var item = listView.SelectedItems[0];
            int id = Convert.ToInt32(item.Tag);

            try
            {
                fileManager.OpenFile(id);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

                listView.Items.Remove(item);
            }
        }

        private void pb_Progress_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(imageBuffer.GetFrame(), 0, 0);
        }

        private void ResizeSplitContainers()
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            sc_Left.SplitterDistance = sc_Left.Width / 4;
            sc_Right.SplitterDistance = 2 * sc_Right.Width / 3;
        }

        private void AddNode(TreeNode node, string path)
        {
            tv_Explorer.BeginUpdate();

            DirectoryInfo info = new DirectoryInfo(path);

            int parentId = -1;
            if (node == null)
                node = tv_Explorer.Nodes.Add(info.Name);
            else
            {
                parentId = Convert.ToInt32(node.Tag);
                node = node.Nodes.Add(info.Name);
            }

            int id = folderManager.AddFolder(parentId, info.Name, path);
            node.Tag = id;

            try
            {
                if (info.GetDirectories().Length > 0)
                    node.Nodes.Add("null");
            }
            catch (UnauthorizedAccessException uae)
            {
                node.ImageIndex = 1;
            }

            info = null;

            tv_Explorer.EndUpdate();
        }

        private void LoadFiles(int folderId)
        {
            threadManager.AddThread(THREAD_LOAD_IMAGES);
            SetState(EState.Process);

            string[] files = null;

            try
            {
                CHelper.StopControlUpdating(lv_Files.Handle);

                lv_Files.Items.Clear();
                il_Images.Images.Clear();
                il_Images.Images.Add(Properties.Resources.image);

                //если папка не просканирована, то сканируем файлы в ней
                SetStateText("Сканирование файлов...");
                files = folderManager.ScanFolder(folderId);
                if (files != null)
                {
                    fileManager.Cancel = true;

                    for (int i = 0; i < files.Length; i++)
                    {
                        string file = files[i];
                        fileManager.AddFile(folderId, Path.GetFileName(file), file, Path.GetExtension(file).ToLower());
                    }
                }

                //добавляем файлы
                SetStateText("Загрузка списка файлов...");
                foreach (var file in fileManager.GetFileNames(folderId))
                    lv_Files.Items.Add(new ListViewItem(file.Item2) { ImageIndex = 0, Tag = file.Item1 });
                tb_Statistics.Text = string.Format("Элементов: {0}", lv_Files.Items.Count);

                //загружаем миниатюры
                SetStateText(threadText[THREAD_LOAD_IMAGES]);
                fileManager.LoadImages(folderId, ImageReadyHandler, WorkerCompletedHandler);
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CHelper.ResumeControlUpdating(lv_Files.Handle);
                files = null;
            }
        }

        private void ImageReadyHandler(int id, Image img, int progress)
        {
            il_Images.Images.Add(img);

            int count = il_Images.Images.Count;
            if (lv_Files.Items.Count > count - 2)
                lv_Files.Items[count - 2].ImageIndex = count - 1;

            pb_Main.Value = progress;
        }

        private void WorkerCompletedHandler(bool cancel)
        {
            RemoveThread(THREAD_LOAD_IMAGES);
            SetState(EState.Default);
        }

        private void SetState(EState state)
        {
            if (state == EState.Default && threadManager.Count > 0)
                return;

            pb_Progress.Visible = state == EState.Process;
            l_Status.Visible = pb_Progress.Visible;
            pb_Main.Visible = pb_Progress.Visible;

            switch (state)
            {
                case EState.Process:
                    timerProcess.Start();
                    break;
                case EState.Default:
                    {
                        timerProcess.Stop();
                        pb_Main.Value = 0;

                        break;
                    }
            }
        }

        private void SetStateText(string text)
        {
            l_Status.Text = text;
        }

        private void cms_File_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lv_Files.SelectedItems.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            var cms = (sender as ContextMenuStrip);
            bool value = lv_Files.SelectedItems.Count == 1;
            cms.Items[0].Enabled = value;
            cms.Items[1].Enabled = value;
            cms.Items[3].Enabled = value;
        }

        private void tsmi_Open_Click(object sender, EventArgs e)
        {
            lv_Images_ItemActivate(lv_Files, new EventArgs());
        }

        private void tsmi_OpenLocation_Click(object sender, EventArgs e)
        {
            int fileId = Convert.ToInt32(lv_Files.SelectedItems[0].Tag);
            int id = fileManager.GetFolderIdByFileId(fileId);
            string path = fileManager.GetPath(fileId);

            try
            {
                folderManager.OpenLocation(id, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            int count = lv_Files.SelectedItems.Count;
            if (count == 0)
                return;

            int[] ids = new int[count];
            for (int i = 0; i < count; i++)
                ids[i] = Convert.ToInt32(lv_Files.SelectedItems[i].Tag);

            string question = count > 1 ?
                "Вы действительно хотите переместить эти объекты (" + count + " шт.) в корзину?" :
                "Вы действительно хотите переместить выбранный файл в корзину?";
            if (MessageBox.Show(question, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            
            using (FProcess form = new FProcess(fileManager, ids))
                form.ShowDialog();
            Cursor.Current = Cursors.Default;

            tv_Explorer_NodeMouseClick(tv_Explorer, new TreeNodeMouseClickEventArgs(tv_Explorer.SelectedNode, MouseButtons.Left, 1, 0, 0));
        }

        private void tsmi_Metadata_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lv_Files.SelectedItems[0].Tag);

            Cursor.Current = Cursors.WaitCursor;
            FMetadata form = new FMetadata(fileManager, id, this.Size, this.Location);
            form.FormClosed += (ss, ee) =>
            {
                form = null;

                GC.WaitForPendingFinalizers();
                GC.Collect();
            };
            form.Show();
        }

        private void lv_Files_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Modifiers == Keys.Control)
                        SelectAllFiles();
                    break;
                case Keys.Delete:
                    tsmi_Delete_Click(tsmi_Delete, new EventArgs());
                    break;
            }
        }

        private void SelectAllFiles()
        {
            foreach (ListViewItem item in lv_Files.Items)
                item.Selected = true;
        }

        private void lv_Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = lv_Files.Items.Count;
            int selectedCount = lv_Files.SelectedItems.Count;

            if (selectedCount > 0)
                tb_Statistics.Text = string.Format("Элементов: {0}  |  Выбрано элементов: {1}", count, selectedCount);
            else
                tb_Statistics.Text = string.Format("Элементов: {0}", count);

            bool value = selectedCount == 1;
            tsb_Open.Enabled = value;
            tsb_OpenLocation.Enabled = value;
            tsb_Metadata.Enabled = value;
            tsb_DeleteFiles.Enabled = selectedCount > 0;
        }

        private void tsb_Analyze_Click(object sender, EventArgs e)
        {
            if (tv_Explorer.SelectedNode == null)
                return;

            threadManager.AddThread(THREAD_ANALYZING_FILES);
            SetState(EState.Process);
            SetStateText(threadText[THREAD_ANALYZING_FILES]);

            bool done = false;
            int folderId = Convert.ToInt32(tv_Explorer.SelectedNode.Tag);
            sortedFolderManager.Analyze(folderId, fileManager, patternManager, () => { done = true; });

            while (!done)
            {
                Application.DoEvents();
                Thread.Sleep(50);
            }

            LoadSortedFolders();

            RemoveThread(THREAD_ANALYZING_FILES);
            SetState(EState.Default);
        }

        private void LoadSortedFolders()
        {
            tv_Sorting.Nodes.Clear();

            var roots = sortedFolderManager.Folders.Where(f => f.ParentID < 0).ToArray();
            int rootCount = roots.Length;

            initialization = true;

            for (int i = 0; i < rootCount; i++)
            {
                var folder = roots[i];
                AddSortedNode(null, folder);
            }

            initialization = false;

            tv_Sorting.ExpandAll();
        }

        private void AddSortedNode(TreeNode _node, CSortedFolder folder)
        {
            TreeNode node = null;

            string name = GetSortedFolderName(folder);

            //if (_node == null)
            //    node = tv_Sorting.Nodes.Add(name, name);
            //else
            //    node = _node.Nodes.Add(name, name);

            if (_node == null)
                node = tv_Sorting.Nodes.AddAndNotifiy(name, name, TreeNodeAmountChangedHandler);
            else
                node = _node.Nodes.AddAndNotifiy(name, name, TreeNodeAmountChangedHandler);

            node.Tag = folder.ID;
            node.Checked = folder.Checked;

            var childs = sortedFolderManager.Folders.Where(f => f.ParentID == folder.ID).ToArray();
            int childAmount = childs.Length;
            if (childAmount > 0)
                for (int i = 0; i < childs.Length; i++)
                    AddSortedNode(node, childs[i]);

            childs = null;
            node = null;
        }

        private string GetSortedFolderName(CSortedFolder folder)
        {
            string name = string.Empty;
            int count = fileManager.GetFileAmountBySortedFolderId(folder.ID);
            if (count == 0)
            {
                int[] subFolders = sortedFolderManager.GetChildIDs(folder.ID, true);

                for (int i = 0; i < subFolders.Length; i++)
                {
                    int subFolderId = subFolders[i];

                    count += fileManager.GetFileAmountBySortedFolderId(subFolderId);

                    int[] subSubFolders = sortedFolderManager.GetChildIDs(subFolderId, true);
                    for (int j = 0; j < subSubFolders.Length; j++)
                    {
                        int subSubFolderId = subSubFolders[j];

                        count += fileManager.GetFileAmountBySortedFolderId(subSubFolderId);
                    }

                    subSubFolders = null;
                }

                subFolders = null;
            }
            name = string.Format("{0} ({1})", folder.Name, count);

            return name;
        }

        private void tsb_Sort_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (FSorting form = new FSorting(destinationManager, fileManager, sortedFolderManager, folderManager, TaskbarSetProgressHandler, TaskbarSetStatePausedHandler, TaskbarSetStateErrorHandler))
            {
                form.ShowDialog();

                if (form.Tag != null && Convert.ToBoolean(form.Tag))
                {
                    LoadSortedFolders();
                    tv_Sorting.SelectedNode = tv_Sorting.Nodes[0];
                    tv_Sorting_NodeMouseClick(tv_Sorting, new TreeNodeMouseClickEventArgs(tv_Sorting.SelectedNode, MouseButtons.Left, 1, 0, 0));
                }
            }
        }

        private void tsb_Settings_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            using (FSettings form = new FSettings(destinationManager, patternManager))
                form.ShowDialog();
        }

        private void tsb_About_Click(object sender, EventArgs e)
        {
            using (FAbout form = new FAbout())
                form.ShowDialog();
        }

        private void tsb_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tv_Sorting_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (e.Node == null || e.Node.Tag == null)
                return;

            inRightTree = true;
            tv_Explorer.HideSelection = inRightTree;
            tv_Explorer.SelectedNode = null;
            tv_Sorting.HideSelection = !inRightTree;
            lastSortedNode = e.Node;

            int sortedFolderId = Convert.ToInt32(e.Node.Tag);

            LoadFiles1(sortedFolderId);
        }

        private void LoadFiles1(int sortedFolderId)
        {
            threadManager.AddThread(THREAD_LOAD_IMAGES);
            SetState(EState.Process);

            try
            {
                CHelper.StopControlUpdating(lv_Files.Handle);

                lv_Files.Items.Clear();
                il_Images.Images.Clear();
                il_Images.Images.Add(Properties.Resources.image);

                //добавляем файлы
                SetStateText("Загрузка списка файлов...");
                foreach (var file in fileManager.GetFileNames1(sortedFolderId))
                    lv_Files.Items.Add(new ListViewItem(file.Item2) { ImageIndex = 0, Tag = file.Item1 });

                List<int> subFolderIDs = new List<int>();
                if (lv_Files.Items.Count == 0)
                {
                    int[] subFolders = sortedFolderManager.GetChildIDs(sortedFolderId);

                    for (int i = 0; i < subFolders.Length; i++)
                    {
                        int subFolderId = subFolders[i];

                        subFolderIDs.Add(subFolderId);

                        foreach (var file in fileManager.GetFileNames1(subFolderId))
                            lv_Files.Items.Add(new ListViewItem(file.Item2) { ImageIndex = 0, Tag = file.Item1 });

                        int[] subSubFolders = sortedFolderManager.GetChildIDs(subFolderId);
                        for (int j = 0; j < subSubFolders.Length; j++)
                        {
                            int subSubFolderId = subSubFolders[j];

                            subFolderIDs.Add(subSubFolderId);

                            foreach (var file in fileManager.GetFileNames1(subSubFolderId))
                                lv_Files.Items.Add(new ListViewItem(file.Item2) { ImageIndex = 0, Tag = file.Item1 });
                        }

                        subSubFolders = null;
                    }

                    subFolders = null;

                    fileManager.LoadImages1(subFolderIDs.ToArray(), ImageReadyHandler, WorkerCompletedHandler);
                }
                else
                {
                    //загружаем миниатюры
                    SetStateText(threadText[THREAD_LOAD_IMAGES]);
                    fileManager.LoadImages1(new int[] { sortedFolderId }, ImageReadyHandler, WorkerCompletedHandler);
                }
                subFolderIDs.Clear();
                subFolderIDs = null;

                tb_Statistics.Text = string.Format("Элементов: {0}", lv_Files.Items.Count);


            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CHelper.ResumeControlUpdating(lv_Files.Handle);
            }
        }

        private void tv_Sorting_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tv_Sorting_NodeMouseClick(tv_Sorting, new TreeNodeMouseClickEventArgs(tv_Sorting.SelectedNode, MouseButtons.Left, 1, 0, 0));
                    break;
            }
        }

        private void tv_Sorting_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (initialization)
                return;

            AfterCheck(e.Node);
        }

        
        private void lv_Files_MouseDown(object sender, MouseEventArgs e)
        {
            int count = lv_Files.SelectedItems.Count;
            if (count == 0)
                return;

            draggedFileIDs = new int[count];
            int counter = 0;
            foreach (ListViewItem item in lv_Files.SelectedItems)
                draggedFileIDs[counter++] = Convert.ToInt32(item.Tag);
            readyToDragDrop = true;
        }

        private void lv_Files_MouseMove(object sender, MouseEventArgs e)
        {
            if (readyToDragDrop && draggedFileIDs != null)
            {
                lv_Files.DoDragDrop(draggedFileIDs, DragDropEffects.Move);
                readyToDragDrop = false;
                dragDrop = true;
            }
        }

        private void lv_Files_MouseUp(object sender, MouseEventArgs e)
        {
            if (readyToDragDrop || dragDrop)
            {
                readyToDragDrop = false;
                dragDrop = false;
                draggedFileIDs = null;
            }
        }

        private void tv_Sorting_DragOver(object sender, DragEventArgs e)
        {
            var p = tv_Sorting.PointToClient(Cursor.Position);
            var node = tv_Sorting.GetNodeAt(p.X, p.Y);
            if (node == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            
            e.Effect = DragDropEffects.Move;

            tv_Sorting.SelectedNode = node;

            tv_Sorting.SelectedNode.Expand();
        }

        private void tv_Sorting_DragDrop(object sender, DragEventArgs e)
        {
            var p = tv_Sorting.PointToClient(Cursor.Position);
            var targetNode = tv_Sorting.GetNodeAt(p.X, p.Y);
            if (targetNode == null)
                return;

            int sortedFolderId = Convert.ToInt32(targetNode.Tag);

            int[] ids = (int[])e.Data.GetData(typeof(int[]));
            for (int i = 0; i < ids.Length; i++)
                fileManager.SetSortedFolderId(ids[i], sortedFolderId);

            RenameSortedFolders();

            if (inRightTree)
            {
                int lastDeleted = 0;
                for (int i = 0; i < lv_Files.Items.Count; i++)
                {
                    int id = Convert.ToInt32(lv_Files.Items[i].Tag);
                    if (ids.Contains(id))
                    {
                        lv_Files.Items.RemoveAt(i);
                        lastDeleted = i--;
                    }
                }

                if (lv_Files.Items.Count > 0)
                {
                    if (--lastDeleted < 0)
                        lv_Files.Items[0].Selected = true;
                    else if (lv_Files.Items.Count > lastDeleted)
                        lv_Files.Items[lastDeleted].Selected = true;
                }

                tv_Sorting.SelectedNode = lastSortedNode;
            }
            else
            {
                tv_Sorting.SelectedNode = null;
                tv_Sorting_AfterSelect(tv_Sorting, new TreeViewEventArgs(tv_Sorting.SelectedNode));
            }

            dragDrop = false;
            ids = null;
        }

        private void RenameSortedFolders()
        {
            for (int i = 0; i < tv_Sorting.Nodes.Count; i++)
                RenameSortedFolder(tv_Sorting.Nodes[i]);
        }

        private void RenameSortedFolder(TreeNode node)
        {
            int id = Convert.ToInt32(node.Tag);

            var folder = sortedFolderManager.Folders.First(f => f.ID == id);

            node.Text = GetSortedFolderName(folder);

            for (int i = 0; i < node.Nodes.Count; i++)
                RenameSortedFolder(node.Nodes[i]);
        }

        private void tsb_ExpandAll_Click(object sender, EventArgs e)
        {
            if (tv_Sorting.Nodes.Count == 0)
                return;

            tv_Sorting.ExpandAll();
        }

        private void tsb_CollapseAll_Click(object sender, EventArgs e)
        {
            if (tv_Sorting.Nodes.Count == 0)
                return;

            tv_Sorting.CollapseAll();
        }

        private void tsb_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv_Sorting.Nodes.Count; i++)
                tv_Sorting.Nodes[i].Checked = true;
        }

        private void tsb_UncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv_Sorting.Nodes.Count; i++)
                tv_Sorting.Nodes[i].Checked = false;
        }

        private void AfterCheck(TreeNode node)
        {
            // при изменении чека проверяем есть ли в него вложенные - если есть то изменяем их статус
            //сначала идем вниз - потом идем вверх анализируем и выставляем
            if (checkWork == true)
                return;

            checkWork = true;

            CheckChilds(node);
            CheckParents(node);

            checkWork = false;
        }

        private void CheckChilds(TreeNode _node)
        {
            int id = Convert.ToInt32(_node.Tag);
            bool value = _node.Checked;
            sortedFolderManager.SetCheckState(id, value);

            foreach (TreeNode child in _node.Nodes)
            {
                child.Checked = value;

                CheckChilds(child);
            }
        }

        private void CheckParents(TreeNode _node)
        {
            TreeNode parent = _node.Parent;

            //обрабатываем отцов
            if (parent == null)
                return;

            bool value = false;
            foreach (TreeNode _parent in parent.Nodes)
                if (_parent.Checked)
                {
                    value = true;
                    break;
                }

            parent.Checked = value;

            int id = Convert.ToInt32(parent.Tag);
            sortedFolderManager.SetCheckState(id, value);

            CheckParents(parent);
        }

        private void tsb_AddSortedFolder_Click(object sender, EventArgs e)
        {
            string name = string.Empty;

            using (FRename form = new FRename())
            {
                form.ShowDialog();

                if (form.Tag != null)
                    name = form.Tag.ToString();
            }

            if (name == string.Empty)
                return;

            if (sortedFolderManager.CreateFolder(name, fileManager))
                LoadSortedFolders();
            else
                MessageBox.Show("Папка с именем \"" + name + "\" уже существует", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsb_DeleteSortedFolder_Click(object sender, EventArgs e)
        {
            if (tv_Sorting.SelectedNode == null)
                return;

            if (MessageBox.Show("Вы действительно хотите удалить папку \"" + tv_Sorting.SelectedNode.Text + "\"?", TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            int id = Convert.ToInt32(tv_Sorting.SelectedNode.Tag);

            sortedFolderManager.DeleteFolder(id, fileManager);
            LoadSortedFolders();

            TreeNode previousNode = tv_Sorting.GetNodeWithTag(id - 1);
            if (previousNode == null)
                return;

            tv_Sorting.SelectedNode = previousNode;
            tv_Sorting_NodeMouseClick(tv_Sorting, new TreeNodeMouseClickEventArgs(tv_Sorting.SelectedNode, MouseButtons.Left, 1, 0, 0));
        }

        private void tsb_DeleteSortedFolders_Click(object sender, EventArgs e)
        {
            if (tv_Sorting.Nodes.Count == 0)
                return;

            if (MessageBox.Show("Вы действительно хотите очистить все папки?", TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;

            Cursor.Current = Cursors.WaitCursor;

            ClearSortedFolders();

            Cursor.Current = Cursors.Default;

            inRightTree = false;
            tv_Explorer.HideSelection = inRightTree;
            tv_Explorer.SelectedNode = tv_Explorer.Nodes[0];
            tv_Sorting.HideSelection = !inRightTree;
            tv_Explorer_NodeMouseClick(tv_Explorer, new TreeNodeMouseClickEventArgs(tv_Explorer.SelectedNode, MouseButtons.Left, 1, 0, 0));
        }

        private void ClearSortedFolders()
        {
            sortedFolderManager.Clear();
            fileManager.ClearSortedFolderIDs();
            tv_Sorting.Nodes.ClearAndNotify(TreeNodeAmountChangedHandler);
        }

        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            RefreshLastPath();
        }

        private void RefreshLastPath()
        {
            Cursor.Current = Cursors.WaitCursor;

            ClearSortedFolders();

            string lastPath = Properties.Settings.Default.LastPath;
            if (lastPath != "" && folderManager.CheckFolder(lastPath))
                SetRoot(lastPath);

            Cursor.Current = Cursors.Default;
        }

        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            RefreshLastPath();
        }

        private void cms_Explorer_Opening(object sender, CancelEventArgs e)
        {
            var cms = (sender as ContextMenuStrip);
            bool value = tv_Explorer.SelectedNode != null;
            cms.Items[1].Visible = value;
            cms.Items[2].Visible = value;
        }

        private void tsmi_OpenFolder_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tv_Explorer.SelectedNode.Tag);

            try
            {
                folderManager.OpenFolder(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsb_SelectAll_Click(object sender, EventArgs e)
        {
            lv_Files.Focus();

            SelectAllFiles();
        }

        private void tsb_Open_Click(object sender, EventArgs e)
        {
            tsmi_Open_Click(tsmi_Open, new EventArgs());
        }

        private void tsb_OpenLocation_Click(object sender, EventArgs e)
        {
            tsmi_OpenLocation_Click(tsmi_OpenLocation, new EventArgs());
        }

        private void tsb_Metadata_Click(object sender, EventArgs e)
        {
            tsmi_Metadata_Click(tsmi_Metadata, new EventArgs());
        }

        private void tsb_DeleteFiles_Click(object sender, EventArgs e)
        {
            tsmi_Delete_Click(tsmi_Delete, new EventArgs());
        }

        private void tv_Explorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tsb_OpenFolder.Enabled = tv_Explorer.SelectedNode != null;
        }

        private void tsb_OpenFolder_Click(object sender, EventArgs e)
        {
            tsmi_OpenFolder_Click(tsmi_OpenFolder, new EventArgs());
        }

        private void tv_Sorting_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool value = tv_Sorting.Nodes.Count > 0 && tv_Sorting.SelectedNode != null;
            
            tsb_DeleteSortedFolder.Enabled = value;
        }

        private void TreeNodeAmountChangedHandler(int count)
        {
            bool value = count > 0;

            tsb_ExpandAll.Enabled = value;
            tsb_CollapseAll.Enabled = value;
            tsb_CheckAll.Enabled = value; ;
            tsb_UncheckAll.Enabled = value;
            tsb_DeleteSortedFolders.Enabled = value;

            if (!value)
                tsb_DeleteSortedFolder.Enabled = value;
        }

        private void TaskbarSetProgressHandler(int progress)
        {
            TaskbarManager.Instance.SetProgressValue(progress, 100);

            if (progress == 0)
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            else
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
        }

        private void TaskbarSetStatePausedHandler()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);
        }

        private void TaskbarSetStateErrorHandler()
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
        }

        private void RemoveThread(int thread)
        {
            threadManager.RemoveThread(thread);

            if (threadManager.Count > 0)
                SetStateText(threadText[threadManager.GetLastThread()]);
        }
    }
}
