namespace Media_Sorter
{
    partial class FPatterns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPatterns));
            this.dgv_Patterns = new System.Windows.Forms.DataGridView();
            this.b_Close = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_AddPattern = new System.Windows.Forms.ToolStripButton();
            this.tsb_DeletePattern = new System.Windows.Forms.ToolStripButton();
            this.l_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Patterns)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Patterns
            // 
            this.dgv_Patterns.AllowUserToAddRows = false;
            this.dgv_Patterns.AllowUserToDeleteRows = false;
            this.dgv_Patterns.AllowUserToResizeRows = false;
            this.dgv_Patterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Patterns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Patterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Patterns.Location = new System.Drawing.Point(12, 41);
            this.dgv_Patterns.Name = "dgv_Patterns";
            this.dgv_Patterns.Size = new System.Drawing.Size(600, 359);
            this.dgv_Patterns.TabIndex = 0;
            this.dgv_Patterns.SelectionChanged += new System.EventHandler(this.dgv_Patterns_SelectionChanged);
            // 
            // b_Close
            // 
            this.b_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Close.Location = new System.Drawing.Point(537, 406);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 1;
            this.b_Close.Text = "Закрыть";
            this.b_Close.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_AddPattern,
            this.tsb_DeletePattern});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_AddPattern
            // 
            this.tsb_AddPattern.Image = global::Media_Sorter.Properties.Resources.plus;
            this.tsb_AddPattern.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AddPattern.Name = "tsb_AddPattern";
            this.tsb_AddPattern.Size = new System.Drawing.Size(63, 35);
            this.tsb_AddPattern.Text = "Добавить";
            this.tsb_AddPattern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_AddPattern.Click += new System.EventHandler(this.tsb_AddPattern_Click);
            // 
            // tsb_DeletePattern
            // 
            this.tsb_DeletePattern.AutoSize = false;
            this.tsb_DeletePattern.Image = global::Media_Sorter.Properties.Resources.cross;
            this.tsb_DeletePattern.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DeletePattern.Name = "tsb_DeletePattern";
            this.tsb_DeletePattern.Size = new System.Drawing.Size(63, 35);
            this.tsb_DeletePattern.Text = "Удалить";
            this.tsb_DeletePattern.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_DeletePattern.Click += new System.EventHandler(this.tsb_DeletePattern_Click);
            // 
            // l_Status
            // 
            this.l_Status.AutoSize = true;
            this.l_Status.ForeColor = System.Drawing.SystemColors.GrayText;
            this.l_Status.Location = new System.Drawing.Point(12, 411);
            this.l_Status.Name = "l_Status";
            this.l_Status.Size = new System.Drawing.Size(35, 13);
            this.l_Status.TabIndex = 3;
            this.l_Status.Text = "label1";
            // 
            // FPatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Close;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.l_Status);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.dgv_Patterns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FPatterns";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Паттерны";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPatterns_FormClosing);
            this.Load += new System.EventHandler(this.FPatterns_Load);
            this.Shown += new System.EventHandler(this.FPatterns_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Patterns)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Patterns;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_AddPattern;
        private System.Windows.Forms.ToolStripButton tsb_DeletePattern;
        private System.Windows.Forms.Label l_Status;
    }
}