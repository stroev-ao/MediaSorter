namespace Media_Sorter
{
    partial class FProcess
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
            this.pb_Main = new System.Windows.Forms.ProgressBar();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_Main
            // 
            this.pb_Main.Location = new System.Drawing.Point(12, 12);
            this.pb_Main.Name = "pb_Main";
            this.pb_Main.Size = new System.Drawing.Size(280, 23);
            this.pb_Main.TabIndex = 0;
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(217, 41);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 1;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // FProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 76);
            this.ControlBox = false;
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.pb_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FProcess";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FProcess";
            this.Load += new System.EventHandler(this.FProcess_Load);
            this.Shown += new System.EventHandler(this.FProcess_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Main;
        private System.Windows.Forms.Button b_Cancel;
    }
}