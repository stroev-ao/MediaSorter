namespace Media_Sorter
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_SelectRoot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Analyze = new System.Windows.Forms.ToolStripButton();
            this.tsb_Sort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Settings = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Exit = new System.Windows.Forms.ToolStripButton();
            this.sc_Left = new System.Windows.Forms.SplitContainer();
            this.tv_Explorer = new System.Windows.Forms.TreeView();
            this.cms_Explorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.il_Icons = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_OpenFolder = new System.Windows.Forms.ToolStripButton();
            this.sc_Right = new System.Windows.Forms.SplitContainer();
            this.lv_Files = new System.Windows.Forms.ListView();
            this.cms_File = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Metadata = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.il_Images = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsb_SelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Open = new System.Windows.Forms.ToolStripButton();
            this.tsb_OpenLocation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Metadata = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_DeleteFiles = new System.Windows.Forms.ToolStripButton();
            this.tb_Statistics = new System.Windows.Forms.TextBox();
            this.tv_Sorting = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.tsb_CollapseAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_CheckAll = new System.Windows.Forms.ToolStripButton();
            this.tsb_UncheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_AddSortedFolder = new System.Windows.Forms.ToolStripButton();
            this.tsb_DeleteSortedFolder = new System.Windows.Forms.ToolStripButton();
            this.tsb_DeleteSortedFolders = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_Main = new System.Windows.Forms.ProgressBar();
            this.l_Status = new System.Windows.Forms.Label();
            this.pb_Progress = new System.Windows.Forms.PictureBox();
            this.ts_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_Left)).BeginInit();
            this.sc_Left.Panel1.SuspendLayout();
            this.sc_Left.Panel2.SuspendLayout();
            this.sc_Left.SuspendLayout();
            this.cms_Explorer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_Right)).BeginInit();
            this.sc_Right.Panel1.SuspendLayout();
            this.sc_Right.Panel2.SuspendLayout();
            this.sc_Right.SuspendLayout();
            this.cms_File.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_Main
            // 
            this.ts_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_SelectRoot,
            this.toolStripSeparator1,
            this.tsb_Analyze,
            this.tsb_Sort,
            this.toolStripSeparator2,
            this.tsb_Settings,
            this.tsb_About,
            this.toolStripSeparator3,
            this.tsb_Exit});
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts_Main.Size = new System.Drawing.Size(784, 38);
            this.ts_Main.TabIndex = 1;
            this.ts_Main.Text = "toolStrip1";
            // 
            // tsb_SelectRoot
            // 
            this.tsb_SelectRoot.Image = global::Media_Sorter.Properties.Resources.source;
            this.tsb_SelectRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SelectRoot.Name = "tsb_SelectRoot";
            this.tsb_SelectRoot.Size = new System.Drawing.Size(65, 35);
            this.tsb_SelectRoot.Text = "Источник";
            this.tsb_SelectRoot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_SelectRoot.Click += new System.EventHandler(this.tsb_SelectRoot_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsb_Analyze
            // 
            this.tsb_Analyze.Image = global::Media_Sorter.Properties.Resources.sort;
            this.tsb_Analyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Analyze.Name = "tsb_Analyze";
            this.tsb_Analyze.Size = new System.Drawing.Size(51, 35);
            this.tsb_Analyze.Text = "Анализ";
            this.tsb_Analyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Analyze.Click += new System.EventHandler(this.tsb_Analyze_Click);
            // 
            // tsb_Sort
            // 
            this.tsb_Sort.Image = global::Media_Sorter.Properties.Resources.sort1;
            this.tsb_Sort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Sort.Name = "tsb_Sort";
            this.tsb_Sort.Size = new System.Drawing.Size(77, 35);
            this.tsb_Sort.Text = "Сортировка";
            this.tsb_Sort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Sort.Click += new System.EventHandler(this.tsb_Sort_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsb_Settings
            // 
            this.tsb_Settings.Image = global::Media_Sorter.Properties.Resources.settings;
            this.tsb_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Settings.Name = "tsb_Settings";
            this.tsb_Settings.Size = new System.Drawing.Size(71, 35);
            this.tsb_Settings.Text = "Настройки";
            this.tsb_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Settings.Click += new System.EventHandler(this.tsb_Settings_Click);
            // 
            // tsb_About
            // 
            this.tsb_About.Image = global::Media_Sorter.Properties.Resources.about;
            this.tsb_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_About.Name = "tsb_About";
            this.tsb_About.Size = new System.Drawing.Size(86, 35);
            this.tsb_About.Text = "О программе";
            this.tsb_About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_About.Click += new System.EventHandler(this.tsb_About_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // tsb_Exit
            // 
            this.tsb_Exit.Image = global::Media_Sorter.Properties.Resources.exit;
            this.tsb_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Exit.Name = "tsb_Exit";
            this.tsb_Exit.Size = new System.Drawing.Size(45, 35);
            this.tsb_Exit.Text = "Выход";
            this.tsb_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Exit.Click += new System.EventHandler(this.tsb_Exit_Click);
            // 
            // sc_Left
            // 
            this.sc_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Left.Location = new System.Drawing.Point(0, 38);
            this.sc_Left.Name = "sc_Left";
            // 
            // sc_Left.Panel1
            // 
            this.sc_Left.Panel1.Controls.Add(this.tv_Explorer);
            this.sc_Left.Panel1.Controls.Add(this.toolStrip2);
            // 
            // sc_Left.Panel2
            // 
            this.sc_Left.Panel2.Controls.Add(this.sc_Right);
            this.sc_Left.Size = new System.Drawing.Size(784, 502);
            this.sc_Left.SplitterDistance = 268;
            this.sc_Left.TabIndex = 2;
            // 
            // tv_Explorer
            // 
            this.tv_Explorer.ContextMenuStrip = this.cms_Explorer;
            this.tv_Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Explorer.ImageIndex = 0;
            this.tv_Explorer.ImageList = this.il_Icons;
            this.tv_Explorer.Location = new System.Drawing.Point(0, 25);
            this.tv_Explorer.Name = "tv_Explorer";
            this.tv_Explorer.SelectedImageIndex = 2;
            this.tv_Explorer.Size = new System.Drawing.Size(266, 475);
            this.tv_Explorer.TabIndex = 1;
            this.tv_Explorer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_Explorer_BeforeExpand);
            this.tv_Explorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Explorer_AfterSelect);
            this.tv_Explorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Explorer_NodeMouseClick);
            this.tv_Explorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tv_Explorer_KeyDown);
            // 
            // cms_Explorer
            // 
            this.cms_Explorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Refresh,
            this.toolStripMenuItem6,
            this.tsmi_OpenFolder});
            this.cms_Explorer.Name = "cms_Explorer";
            this.cms_Explorer.Size = new System.Drawing.Size(200, 54);
            this.cms_Explorer.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Explorer_Opening);
            // 
            // tsmi_Refresh
            // 
            this.tsmi_Refresh.Name = "tsmi_Refresh";
            this.tsmi_Refresh.Size = new System.Drawing.Size(199, 22);
            this.tsmi_Refresh.Text = "Обновить";
            this.tsmi_Refresh.Click += new System.EventHandler(this.tsmi_Refresh_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(196, 6);
            // 
            // tsmi_OpenFolder
            // 
            this.tsmi_OpenFolder.Name = "tsmi_OpenFolder";
            this.tsmi_OpenFolder.Size = new System.Drawing.Size(199, 22);
            this.tsmi_OpenFolder.Text = "Открыть в проводнике";
            this.tsmi_OpenFolder.Click += new System.EventHandler(this.tsmi_OpenFolder_Click);
            // 
            // il_Icons
            // 
            this.il_Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_Icons.ImageStream")));
            this.il_Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.il_Icons.Images.SetKeyName(0, "folder.png");
            this.il_Icons.Images.SetKeyName(1, "folder_closed.png");
            this.il_Icons.Images.SetKeyName(2, "folder_opened.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Refresh,
            this.toolStripSeparator9,
            this.tsb_OpenFolder});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(266, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsb_Refresh
            // 
            this.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Refresh.Image = global::Media_Sorter.Properties.Resources.refresh;
            this.tsb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Refresh.Name = "tsb_Refresh";
            this.tsb_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tsb_Refresh.Text = "Обновить";
            this.tsb_Refresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_OpenFolder
            // 
            this.tsb_OpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_OpenFolder.Image = global::Media_Sorter.Properties.Resources.open_folder;
            this.tsb_OpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenFolder.Name = "tsb_OpenFolder";
            this.tsb_OpenFolder.Size = new System.Drawing.Size(23, 22);
            this.tsb_OpenFolder.Text = "Открыть в проводнике";
            this.tsb_OpenFolder.Click += new System.EventHandler(this.tsb_OpenFolder_Click);
            // 
            // sc_Right
            // 
            this.sc_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Right.Location = new System.Drawing.Point(0, 0);
            this.sc_Right.Name = "sc_Right";
            // 
            // sc_Right.Panel1
            // 
            this.sc_Right.Panel1.Controls.Add(this.lv_Files);
            this.sc_Right.Panel1.Controls.Add(this.toolStrip3);
            this.sc_Right.Panel1.Controls.Add(this.tb_Statistics);
            // 
            // sc_Right.Panel2
            // 
            this.sc_Right.Panel2.Controls.Add(this.tv_Sorting);
            this.sc_Right.Panel2.Controls.Add(this.toolStrip1);
            this.sc_Right.Size = new System.Drawing.Size(512, 502);
            this.sc_Right.SplitterDistance = 260;
            this.sc_Right.TabIndex = 0;
            // 
            // lv_Files
            // 
            this.lv_Files.ContextMenuStrip = this.cms_File;
            this.lv_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Files.HideSelection = false;
            this.lv_Files.LargeImageList = this.il_Images;
            this.lv_Files.Location = new System.Drawing.Point(0, 25);
            this.lv_Files.Name = "lv_Files";
            this.lv_Files.Size = new System.Drawing.Size(258, 455);
            this.lv_Files.TabIndex = 0;
            this.lv_Files.UseCompatibleStateImageBehavior = false;
            this.lv_Files.ItemActivate += new System.EventHandler(this.lv_Images_ItemActivate);
            this.lv_Files.SelectedIndexChanged += new System.EventHandler(this.lv_Files_SelectedIndexChanged);
            this.lv_Files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_Files_KeyDown);
            this.lv_Files.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_Files_MouseDown);
            this.lv_Files.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lv_Files_MouseMove);
            this.lv_Files.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lv_Files_MouseUp);
            // 
            // cms_File
            // 
            this.cms_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Open,
            this.tsmi_OpenLocation,
            this.toolStripMenuItem1,
            this.tsmi_Metadata,
            this.toolStripMenuItem5,
            this.tsmi_Delete});
            this.cms_File.Name = "cms_File";
            this.cms_File.Size = new System.Drawing.Size(195, 104);
            this.cms_File.Opening += new System.ComponentModel.CancelEventHandler(this.cms_File_Opening);
            // 
            // tsmi_Open
            // 
            this.tsmi_Open.Name = "tsmi_Open";
            this.tsmi_Open.Size = new System.Drawing.Size(194, 22);
            this.tsmi_Open.Text = "Открыть";
            this.tsmi_Open.Click += new System.EventHandler(this.tsmi_Open_Click);
            // 
            // tsmi_OpenLocation
            // 
            this.tsmi_OpenLocation.Name = "tsmi_OpenLocation";
            this.tsmi_OpenLocation.Size = new System.Drawing.Size(194, 22);
            this.tsmi_OpenLocation.Text = "Расположение файла";
            this.tsmi_OpenLocation.Click += new System.EventHandler(this.tsmi_OpenLocation_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // tsmi_Metadata
            // 
            this.tsmi_Metadata.Name = "tsmi_Metadata";
            this.tsmi_Metadata.Size = new System.Drawing.Size(194, 22);
            this.tsmi_Metadata.Text = "Метаданные";
            this.tsmi_Metadata.Click += new System.EventHandler(this.tsmi_Metadata_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(191, 6);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.Size = new System.Drawing.Size(194, 22);
            this.tsmi_Delete.Text = "Удалить";
            this.tsmi_Delete.Click += new System.EventHandler(this.tsmi_Delete_Click);
            // 
            // il_Images
            // 
            this.il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.il_Images.ImageSize = new System.Drawing.Size(64, 64);
            this.il_Images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_SelectAll,
            this.toolStripSeparator6,
            this.tsb_Open,
            this.tsb_OpenLocation,
            this.toolStripSeparator7,
            this.tsb_Metadata,
            this.toolStripSeparator8,
            this.tsb_DeleteFiles});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(258, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsb_SelectAll
            // 
            this.tsb_SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SelectAll.Image = global::Media_Sorter.Properties.Resources.select_all;
            this.tsb_SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SelectAll.Name = "tsb_SelectAll";
            this.tsb_SelectAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_SelectAll.Text = "Выбрать все";
            this.tsb_SelectAll.Click += new System.EventHandler(this.tsb_SelectAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Open
            // 
            this.tsb_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Open.Image = global::Media_Sorter.Properties.Resources.picture;
            this.tsb_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Open.Name = "tsb_Open";
            this.tsb_Open.Size = new System.Drawing.Size(23, 22);
            this.tsb_Open.Text = "Открыть";
            this.tsb_Open.Click += new System.EventHandler(this.tsb_Open_Click);
            // 
            // tsb_OpenLocation
            // 
            this.tsb_OpenLocation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_OpenLocation.Image = global::Media_Sorter.Properties.Resources.open_location;
            this.tsb_OpenLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenLocation.Name = "tsb_OpenLocation";
            this.tsb_OpenLocation.Size = new System.Drawing.Size(23, 22);
            this.tsb_OpenLocation.Text = "Расположение файла";
            this.tsb_OpenLocation.Click += new System.EventHandler(this.tsb_OpenLocation_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Metadata
            // 
            this.tsb_Metadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Metadata.Image = global::Media_Sorter.Properties.Resources.metadata;
            this.tsb_Metadata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Metadata.Name = "tsb_Metadata";
            this.tsb_Metadata.Size = new System.Drawing.Size(23, 22);
            this.tsb_Metadata.Text = "Метаданные";
            this.tsb_Metadata.Click += new System.EventHandler(this.tsb_Metadata_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_DeleteFiles
            // 
            this.tsb_DeleteFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_DeleteFiles.Image = global::Media_Sorter.Properties.Resources.delete_files;
            this.tsb_DeleteFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DeleteFiles.Name = "tsb_DeleteFiles";
            this.tsb_DeleteFiles.Size = new System.Drawing.Size(23, 22);
            this.tsb_DeleteFiles.Text = "Удалить";
            this.tsb_DeleteFiles.Click += new System.EventHandler(this.tsb_DeleteFiles_Click);
            // 
            // tb_Statistics
            // 
            this.tb_Statistics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_Statistics.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Statistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_Statistics.Enabled = false;
            this.tb_Statistics.Location = new System.Drawing.Point(0, 480);
            this.tb_Statistics.Name = "tb_Statistics";
            this.tb_Statistics.ReadOnly = true;
            this.tb_Statistics.Size = new System.Drawing.Size(258, 20);
            this.tb_Statistics.TabIndex = 0;
            this.tb_Statistics.TabStop = false;
            // 
            // tv_Sorting
            // 
            this.tv_Sorting.AllowDrop = true;
            this.tv_Sorting.CheckBoxes = true;
            this.tv_Sorting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Sorting.HideSelection = false;
            this.tv_Sorting.ImageIndex = 0;
            this.tv_Sorting.ImageList = this.il_Icons;
            this.tv_Sorting.Location = new System.Drawing.Point(0, 25);
            this.tv_Sorting.Name = "tv_Sorting";
            this.tv_Sorting.SelectedImageIndex = 2;
            this.tv_Sorting.Size = new System.Drawing.Size(246, 475);
            this.tv_Sorting.TabIndex = 0;
            this.tv_Sorting.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_Sorting_AfterCheck);
            this.tv_Sorting.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Sorting_AfterSelect);
            this.tv_Sorting.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Sorting_NodeMouseClick);
            this.tv_Sorting.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_Sorting_DragDrop);
            this.tv_Sorting.DragOver += new System.Windows.Forms.DragEventHandler(this.tv_Sorting_DragOver);
            this.tv_Sorting.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tv_Sorting_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_ExpandAll,
            this.tsb_CollapseAll,
            this.toolStripSeparator4,
            this.tsb_CheckAll,
            this.tsb_UncheckAll,
            this.toolStripSeparator5,
            this.tsb_AddSortedFolder,
            this.tsb_DeleteSortedFolder,
            this.tsb_DeleteSortedFolders});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(246, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_ExpandAll
            // 
            this.tsb_ExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ExpandAll.Image = global::Media_Sorter.Properties.Resources.expand;
            this.tsb_ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ExpandAll.Name = "tsb_ExpandAll";
            this.tsb_ExpandAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_ExpandAll.Text = "Развернуть все";
            this.tsb_ExpandAll.Click += new System.EventHandler(this.tsb_ExpandAll_Click);
            // 
            // tsb_CollapseAll
            // 
            this.tsb_CollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_CollapseAll.Image = global::Media_Sorter.Properties.Resources.collapse;
            this.tsb_CollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CollapseAll.Name = "tsb_CollapseAll";
            this.tsb_CollapseAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_CollapseAll.Text = "Свернуть все";
            this.tsb_CollapseAll.Click += new System.EventHandler(this.tsb_CollapseAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_CheckAll
            // 
            this.tsb_CheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_CheckAll.Image = global::Media_Sorter.Properties.Resources.check_all;
            this.tsb_CheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CheckAll.Name = "tsb_CheckAll";
            this.tsb_CheckAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_CheckAll.Text = "Выбрать все";
            this.tsb_CheckAll.Click += new System.EventHandler(this.tsb_CheckAll_Click);
            // 
            // tsb_UncheckAll
            // 
            this.tsb_UncheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_UncheckAll.Image = global::Media_Sorter.Properties.Resources.uncheck_all;
            this.tsb_UncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UncheckAll.Name = "tsb_UncheckAll";
            this.tsb_UncheckAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_UncheckAll.Text = "Снять все";
            this.tsb_UncheckAll.Click += new System.EventHandler(this.tsb_UncheckAll_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_AddSortedFolder
            // 
            this.tsb_AddSortedFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_AddSortedFolder.Image = global::Media_Sorter.Properties.Resources.add_sorted_folder;
            this.tsb_AddSortedFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AddSortedFolder.Name = "tsb_AddSortedFolder";
            this.tsb_AddSortedFolder.Size = new System.Drawing.Size(23, 22);
            this.tsb_AddSortedFolder.Text = "Добавить папку";
            this.tsb_AddSortedFolder.Click += new System.EventHandler(this.tsb_AddSortedFolder_Click);
            // 
            // tsb_DeleteSortedFolder
            // 
            this.tsb_DeleteSortedFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_DeleteSortedFolder.Image = global::Media_Sorter.Properties.Resources.delete_sorted_folder;
            this.tsb_DeleteSortedFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DeleteSortedFolder.Name = "tsb_DeleteSortedFolder";
            this.tsb_DeleteSortedFolder.Size = new System.Drawing.Size(23, 22);
            this.tsb_DeleteSortedFolder.Text = "Удалить папку";
            this.tsb_DeleteSortedFolder.Click += new System.EventHandler(this.tsb_DeleteSortedFolder_Click);
            // 
            // tsb_DeleteSortedFolders
            // 
            this.tsb_DeleteSortedFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_DeleteSortedFolders.Image = global::Media_Sorter.Properties.Resources.delete_sorted_folders;
            this.tsb_DeleteSortedFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DeleteSortedFolders.Name = "tsb_DeleteSortedFolders";
            this.tsb_DeleteSortedFolders.Size = new System.Drawing.Size(23, 22);
            this.tsb_DeleteSortedFolders.Text = "Очистить папки";
            this.tsb_DeleteSortedFolders.Click += new System.EventHandler(this.tsb_DeleteSortedFolders_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pb_Main);
            this.panel1.Controls.Add(this.l_Status);
            this.panel1.Controls.Add(this.pb_Progress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 540);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 22);
            this.panel1.TabIndex = 3;
            // 
            // pb_Main
            // 
            this.pb_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Main.Location = new System.Drawing.Point(681, 1);
            this.pb_Main.Margin = new System.Windows.Forms.Padding(1, 1, 3, 1);
            this.pb_Main.Name = "pb_Main";
            this.pb_Main.Size = new System.Drawing.Size(100, 20);
            this.pb_Main.TabIndex = 2;
            // 
            // l_Status
            // 
            this.l_Status.AutoSize = true;
            this.l_Status.Location = new System.Drawing.Point(27, 4);
            this.l_Status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.l_Status.Name = "l_Status";
            this.l_Status.Size = new System.Drawing.Size(35, 13);
            this.l_Status.TabIndex = 1;
            this.l_Status.Text = "label1";
            // 
            // pb_Progress
            // 
            this.pb_Progress.Location = new System.Drawing.Point(1, 1);
            this.pb_Progress.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pb_Progress.Name = "pb_Progress";
            this.pb_Progress.Size = new System.Drawing.Size(20, 20);
            this.pb_Progress.TabIndex = 0;
            this.pb_Progress.TabStop = false;
            this.pb_Progress.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Progress_Paint);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.sc_Left);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts_Main);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Shown += new System.EventHandler(this.FMain_Shown);
            this.Resize += new System.EventHandler(this.FMain_Resize);
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.sc_Left.Panel1.ResumeLayout(false);
            this.sc_Left.Panel1.PerformLayout();
            this.sc_Left.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_Left)).EndInit();
            this.sc_Left.ResumeLayout(false);
            this.cms_Explorer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.sc_Right.Panel1.ResumeLayout(false);
            this.sc_Right.Panel1.PerformLayout();
            this.sc_Right.Panel2.ResumeLayout(false);
            this.sc_Right.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_Right)).EndInit();
            this.sc_Right.ResumeLayout(false);
            this.cms_File.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.SplitContainer sc_Left;
        private System.Windows.Forms.SplitContainer sc_Right;
        private System.Windows.Forms.TreeView tv_Explorer;
        private System.Windows.Forms.ListView lv_Files;
        private System.Windows.Forms.ToolStripButton tsb_SelectRoot;
        private System.Windows.Forms.TreeView tv_Sorting;
        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.ImageList il_Icons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_Progress;
        private System.Windows.Forms.Label l_Status;
        private System.Windows.Forms.ProgressBar pb_Main;
        private System.Windows.Forms.ContextMenuStrip cms_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Open;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsb_Analyze;
        private System.Windows.Forms.ContextMenuStrip cms_Explorer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Refresh;
        private System.Windows.Forms.TextBox tb_Statistics;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Metadata;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton tsb_Settings;
        private System.Windows.Forms.ToolStripButton tsb_Sort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_Exit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_ExpandAll;
        private System.Windows.Forms.ToolStripButton tsb_CollapseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_CheckAll;
        private System.Windows.Forms.ToolStripButton tsb_UncheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsb_AddSortedFolder;
        private System.Windows.Forms.ToolStripButton tsb_DeleteSortedFolders;
        private System.Windows.Forms.ToolStripButton tsb_DeleteSortedFolder;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsb_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenFolder;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsb_SelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsb_Open;
        private System.Windows.Forms.ToolStripButton tsb_OpenLocation;
        private System.Windows.Forms.ToolStripButton tsb_Metadata;
        private System.Windows.Forms.ToolStripButton tsb_DeleteFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsb_OpenFolder;
    }
}

