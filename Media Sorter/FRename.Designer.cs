namespace Media_Sorter
{
    partial class FRename
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
            this.label1 = new System.Windows.Forms.Label();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.dtp_Main = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите дату:";
            // 
            // b_OK
            // 
            this.b_OK.Location = new System.Drawing.Point(56, 51);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 2;
            this.b_OK.Text = "Создать";
            this.b_OK.UseVisualStyleBackColor = true;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(137, 51);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 3;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // dtp_Main
            // 
            this.dtp_Main.Location = new System.Drawing.Point(12, 25);
            this.dtp_Main.Name = "dtp_Main";
            this.dtp_Main.Size = new System.Drawing.Size(200, 20);
            this.dtp_Main.TabIndex = 4;
            // 
            // FRename
            // 
            this.AcceptButton = this.b_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(224, 86);
            this.Controls.Add(this.dtp_Main);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRename";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание папки";
            this.Shown += new System.EventHandler(this.FRename_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.DateTimePicker dtp_Main;
    }
}