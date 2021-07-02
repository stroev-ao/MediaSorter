namespace Media_Sorter
{
    partial class FSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Paths = new System.Windows.Forms.DataGridView();
            this.cms_Paths = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_DeletePath = new System.Windows.Forms.ToolStripMenuItem();
            this.b_AddPath = new System.Windows.Forms.Button();
            this.b_Browse = new System.Windows.Forms.Button();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.b_Patterns = new System.Windows.Forms.Button();
            this.b_Close = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_RenamingTemplate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Paths)).BeginInit();
            this.cms_Paths.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_Paths);
            this.groupBox1.Controls.Add(this.b_AddPath);
            this.groupBox1.Controls.Add(this.b_Browse);
            this.groupBox1.Controls.Add(this.tb_Path);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пути назначения";
            // 
            // dgv_Paths
            // 
            this.dgv_Paths.AllowUserToAddRows = false;
            this.dgv_Paths.AllowUserToDeleteRows = false;
            this.dgv_Paths.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Paths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Paths.ContextMenuStrip = this.cms_Paths;
            this.dgv_Paths.Location = new System.Drawing.Point(6, 45);
            this.dgv_Paths.Name = "dgv_Paths";
            this.dgv_Paths.RowHeadersVisible = false;
            this.dgv_Paths.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Paths.Size = new System.Drawing.Size(428, 166);
            this.dgv_Paths.TabIndex = 3;
            this.dgv_Paths.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_Paths_CellBeginEdit);
            this.dgv_Paths.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Paths_CellEndEdit);
            // 
            // cms_Paths
            // 
            this.cms_Paths.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DeletePath});
            this.cms_Paths.Name = "cms_Paths";
            this.cms_Paths.Size = new System.Drawing.Size(119, 26);
            this.cms_Paths.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Paths_Opening);
            // 
            // tsmi_DeletePath
            // 
            this.tsmi_DeletePath.Name = "tsmi_DeletePath";
            this.tsmi_DeletePath.Size = new System.Drawing.Size(118, 22);
            this.tsmi_DeletePath.Text = "Удалить";
            this.tsmi_DeletePath.Click += new System.EventHandler(this.tsmi_DeletePath_Click);
            // 
            // b_AddPath
            // 
            this.b_AddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_AddPath.Location = new System.Drawing.Point(359, 17);
            this.b_AddPath.Name = "b_AddPath";
            this.b_AddPath.Size = new System.Drawing.Size(75, 23);
            this.b_AddPath.TabIndex = 2;
            this.b_AddPath.Text = "Добавить";
            this.b_AddPath.UseVisualStyleBackColor = true;
            this.b_AddPath.Click += new System.EventHandler(this.b_AddPath_Click);
            // 
            // b_Browse
            // 
            this.b_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Browse.Location = new System.Drawing.Point(278, 17);
            this.b_Browse.Name = "b_Browse";
            this.b_Browse.Size = new System.Drawing.Size(75, 23);
            this.b_Browse.TabIndex = 1;
            this.b_Browse.Text = "Обзор...";
            this.b_Browse.UseVisualStyleBackColor = true;
            this.b_Browse.Click += new System.EventHandler(this.b_Browse_Click);
            // 
            // tb_Path
            // 
            this.tb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Path.Location = new System.Drawing.Point(6, 19);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(266, 20);
            this.tb_Path.TabIndex = 0;
            this.tb_Path.TextChanged += new System.EventHandler(this.tb_Path_TextChanged);
            // 
            // b_Patterns
            // 
            this.b_Patterns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Patterns.Location = new System.Drawing.Point(12, 286);
            this.b_Patterns.Name = "b_Patterns";
            this.b_Patterns.Size = new System.Drawing.Size(75, 23);
            this.b_Patterns.TabIndex = 2;
            this.b_Patterns.Text = "Паттерны...";
            this.b_Patterns.UseVisualStyleBackColor = true;
            this.b_Patterns.Click += new System.EventHandler(this.b_Patterns_Click);
            // 
            // b_Close
            // 
            this.b_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Close.Location = new System.Drawing.Point(377, 286);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 3;
            this.b_Close.Text = "Закрыть";
            this.b_Close.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_RenamingTemplate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 45);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Переименование";
            // 
            // tb_RenamingTemplate
            // 
            this.tb_RenamingTemplate.Location = new System.Drawing.Point(61, 19);
            this.tb_RenamingTemplate.Name = "tb_RenamingTemplate";
            this.tb_RenamingTemplate.Size = new System.Drawing.Size(373, 20);
            this.tb_RenamingTemplate.TabIndex = 1;
            this.tb_RenamingTemplate.Leave += new System.EventHandler(this.tb_RenamingTemplate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Шаблон:";
            // 
            // FSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Close;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.b_Patterns);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "FSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSettings_FormClosing);
            this.Load += new System.EventHandler(this.FSettings_Load);
            this.Shown += new System.EventHandler(this.FSettings_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Paths)).EndInit();
            this.cms_Paths.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_AddPath;
        private System.Windows.Forms.Button b_Browse;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Button b_Patterns;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.ContextMenuStrip cms_Paths;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeletePath;
        private System.Windows.Forms.DataGridView dgv_Paths;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_RenamingTemplate;
        private System.Windows.Forms.Label label1;
    }
}