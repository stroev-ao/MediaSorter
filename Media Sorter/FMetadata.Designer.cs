namespace Media_Sorter
{
    partial class FMetadata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMetadata));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pb_Preview = new System.Windows.Forms.PictureBox();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.tb_Name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(82, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(370, 548);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // pb_Preview
            // 
            this.pb_Preview.Location = new System.Drawing.Point(12, 12);
            this.pb_Preview.Name = "pb_Preview";
            this.pb_Preview.Size = new System.Drawing.Size(64, 64);
            this.pb_Preview.TabIndex = 1;
            this.pb_Preview.TabStop = false;
            // 
            // b_Cancel
            // 
            this.b_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(377, 566);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 2;
            this.b_Cancel.Text = "Закрыть";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // tb_Name
            // 
            this.tb_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Name.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Name.Enabled = false;
            this.tb_Name.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Name.Location = new System.Drawing.Point(12, 82);
            this.tb_Name.Multiline = true;
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.ReadOnly = true;
            this.tb_Name.Size = new System.Drawing.Size(64, 478);
            this.tb_Name.TabIndex = 3;
            this.tb_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.pb_Preview);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 640);
            this.Name = "FMetadata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Метаданные";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMetadata_FormClosing);
            this.Load += new System.EventHandler(this.FMetadata_Load);
            this.Shown += new System.EventHandler(this.FMetadata_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pb_Preview;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.TextBox tb_Name;
    }
}