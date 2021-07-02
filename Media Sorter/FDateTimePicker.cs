using System;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FDateTimePicker : Form
    {
        bool dtpChecked = true;

        public FDateTimePicker()
        {
            InitializeComponent();
        }

        private void FDateTimePicker_Load(object sender, EventArgs e)
        {
            tb_Name.Enabled = false;
        }

        private void FDateTimePicker_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void dtp_Main_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_Main.Checked != dtpChecked)
            {
                dtpChecked = dtp_Main.Checked;
                b_OK.Enabled = dtpChecked;

                tb_Name.Enabled = !dtpChecked;
                label2.Enabled = !dtpChecked;

                if (!dtpChecked)
                {
                    tb_Name_TextChanged(tb_Name, new EventArgs());
                    tb_Name.Focus();
                }
            }
        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            if (!dtpChecked)
                b_OK.Enabled = tb_Name.Text.Length > 0;
        }

        private void b_OK_Click(object sender, EventArgs e)
        {
            this.Tag = dtpChecked ? string.Format("{0}.{1}.{2}", dtp_Main.Value.Year, GetValue(dtp_Main.Value.Month), GetValue(dtp_Main.Value.Day)) : tb_Name.Text;
            this.Close();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetValue(int value)
        {
            string result = value.ToString();
            return result.Length > 1 ? result : "0" + result;
        }
    }
}
