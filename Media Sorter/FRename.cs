using System;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FRename : Form
    {
        public FRename()
        {
            InitializeComponent();
        }

        private void FRename_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void b_OK_Click(object sender, EventArgs e)
        {
            this.Tag = string.Format("{0}.{1}.{2}", dtp_Main.Value.Year, GetValue(dtp_Main.Value.Month), GetValue(dtp_Main.Value.Day));
            Close();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.Tag = null;
            this.Close();
        }

        string GetValue(int value)
        {
            string result = value.ToString();
            return result.Length > 1 ? result : "0" + result;
        }
    }
}
