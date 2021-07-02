namespace Media_Sorter
{
    partial class FDateTimePicker
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
            this.dtp_Main = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp_Main
            // 
            this.dtp_Main.Location = new System.Drawing.Point(12, 25);
            this.dtp_Main.Name = "dtp_Main";
            this.dtp_Main.ShowCheckBox = true;
            this.dtp_Main.Size = new System.Drawing.Size(280, 20);
            this.dtp_Main.TabIndex = 1;
            this.dtp_Main.ValueChanged += new System.EventHandler(this.dtp_Main_ValueChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите название:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(12, 64);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(280, 20);
            this.tb_Name.TabIndex = 3;
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // b_OK
            // 
            this.b_OK.Location = new System.Drawing.Point(136, 90);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 4;
            this.b_OK.Text = "Создать";
            this.b_OK.UseVisualStyleBackColor = true;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Cancel.Location = new System.Drawing.Point(217, 90);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 5;
            this.b_Cancel.Text = "Отмена";
            this.b_Cancel.UseVisualStyleBackColor = true;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // FDateTimePicker
            // 
            this.AcceptButton = this.b_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Cancel;
            this.ClientSize = new System.Drawing.Size(304, 125);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDateTimePicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание папки";
            this.Load += new System.EventHandler(this.FDateTimePicker_Load);
            this.Shown += new System.EventHandler(this.FDateTimePicker_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_Cancel;
    }
}