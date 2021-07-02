namespace Media_Sorter
{
    partial class FSorting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSorting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Move = new System.Windows.Forms.RadioButton();
            this.rb_Copy = new System.Windows.Forms.RadioButton();
            this.groupBox0 = new System.Windows.Forms.GroupBox();
            this.lb_Destinations = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.l_RenamingTemplate = new System.Windows.Forms.Label();
            this.cb_Renaming = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_Progress = new System.Windows.Forms.PictureBox();
            this.b_Start = new System.Windows.Forms.Button();
            this.b_Close = new System.Windows.Forms.Button();
            this.b_Stop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox0.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Move);
            this.groupBox1.Controls.Add(this.rb_Copy);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операция";
            // 
            // rb_Move
            // 
            this.rb_Move.AutoSize = true;
            this.rb_Move.Location = new System.Drawing.Point(6, 42);
            this.rb_Move.Name = "rb_Move";
            this.rb_Move.Size = new System.Drawing.Size(98, 17);
            this.rb_Move.TabIndex = 1;
            this.rb_Move.TabStop = true;
            this.rb_Move.Text = "Перемещение";
            this.rb_Move.UseVisualStyleBackColor = true;
            // 
            // rb_Copy
            // 
            this.rb_Copy.AutoSize = true;
            this.rb_Copy.Location = new System.Drawing.Point(6, 19);
            this.rb_Copy.Name = "rb_Copy";
            this.rb_Copy.Size = new System.Drawing.Size(92, 17);
            this.rb_Copy.TabIndex = 0;
            this.rb_Copy.TabStop = true;
            this.rb_Copy.Text = "Копирование";
            this.rb_Copy.UseVisualStyleBackColor = true;
            this.rb_Copy.CheckedChanged += new System.EventHandler(this.rb_Copy_CheckedChanged);
            // 
            // groupBox0
            // 
            this.groupBox0.Controls.Add(this.lb_Destinations);
            this.groupBox0.Location = new System.Drawing.Point(12, 12);
            this.groupBox0.Name = "groupBox0";
            this.groupBox0.Size = new System.Drawing.Size(280, 94);
            this.groupBox0.TabIndex = 0;
            this.groupBox0.TabStop = false;
            this.groupBox0.Text = "Пути назначения";
            // 
            // lb_Destinations
            // 
            this.lb_Destinations.Enabled = false;
            this.lb_Destinations.FormattingEnabled = true;
            this.lb_Destinations.Location = new System.Drawing.Point(6, 19);
            this.lb_Destinations.Name = "lb_Destinations";
            this.lb_Destinations.Size = new System.Drawing.Size(268, 69);
            this.lb_Destinations.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.l_RenamingTemplate);
            this.groupBox2.Controls.Add(this.cb_Renaming);
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительные опции";
            // 
            // l_RenamingTemplate
            // 
            this.l_RenamingTemplate.AutoSize = true;
            this.l_RenamingTemplate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.l_RenamingTemplate.Location = new System.Drawing.Point(6, 39);
            this.l_RenamingTemplate.Name = "l_RenamingTemplate";
            this.l_RenamingTemplate.Size = new System.Drawing.Size(35, 13);
            this.l_RenamingTemplate.TabIndex = 1;
            this.l_RenamingTemplate.Text = "label1";
            // 
            // cb_Renaming
            // 
            this.cb_Renaming.AutoSize = true;
            this.cb_Renaming.Location = new System.Drawing.Point(6, 19);
            this.cb_Renaming.Name = "cb_Renaming";
            this.cb_Renaming.Size = new System.Drawing.Size(144, 17);
            this.cb_Renaming.TabIndex = 0;
            this.cb_Renaming.Text = "Переименовать файлы";
            this.cb_Renaming.UseVisualStyleBackColor = true;
            this.cb_Renaming.CheckedChanged += new System.EventHandler(this.cb_Renaming_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 244);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Прогресс";
            // 
            // pb_Progress
            // 
            this.pb_Progress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Progress.Location = new System.Drawing.Point(10, 260);
            this.pb_Progress.Name = "pb_Progress";
            this.pb_Progress.Size = new System.Drawing.Size(282, 20);
            this.pb_Progress.TabIndex = 4;
            this.pb_Progress.TabStop = false;
            // 
            // b_Start
            // 
            this.b_Start.Location = new System.Drawing.Point(136, 286);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(75, 23);
            this.b_Start.TabIndex = 5;
            this.b_Start.Text = "Старт";
            this.b_Start.UseVisualStyleBackColor = true;
            this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
            // 
            // b_Close
            // 
            this.b_Close.Location = new System.Drawing.Point(217, 286);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 7;
            this.b_Close.Text = "Закрыть";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // b_Stop
            // 
            this.b_Stop.Location = new System.Drawing.Point(136, 286);
            this.b_Stop.Name = "b_Stop";
            this.b_Stop.Size = new System.Drawing.Size(75, 23);
            this.b_Stop.TabIndex = 6;
            this.b_Stop.Text = "Отмена";
            this.b_Stop.UseVisualStyleBackColor = true;
            this.b_Stop.Click += new System.EventHandler(this.b_Stop_Click);
            // 
            // FSorting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 321);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.b_Start);
            this.Controls.Add(this.pb_Progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox0);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_Stop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FSorting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сортировка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSorting_FormClosing);
            this.Load += new System.EventHandler(this.FSorting_Load);
            this.Shown += new System.EventHandler(this.FSorting_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox0.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Move;
        private System.Windows.Forms.RadioButton rb_Copy;
        private System.Windows.Forms.GroupBox groupBox0;
        private System.Windows.Forms.ListBox lb_Destinations;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label l_RenamingTemplate;
        private System.Windows.Forms.CheckBox cb_Renaming;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_Progress;
        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.Button b_Stop;
    }
}