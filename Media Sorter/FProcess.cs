using System;
using System.Threading;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FProcess : Form
    {
        int[] ids;
        CFileManager fileManager;
        const string TITLE = "Media Sorter";
        const string TEXT = "Удаление ";

        public FProcess(CFileManager fileManager, int[] ids)
        {
            InitializeComponent();

            this.fileManager = fileManager;
            this.ids = ids;
        }

        private void FProcess_Load(object sender, EventArgs e)
        {
            this.Text = TEXT;
        }

        private void FProcess_Shown(object sender, EventArgs e)
        {
            try
            {
                bool done = false;
                fileManager.DeleteFiles(ids, (int progress) => { pb_Main.Value = progress; this.Text = string.Format("{0} ({1}%)", TEXT, progress); }, (bool value) => { done = value; this.Close(); });

                while (!done)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            fileManager.Cancel = true;
            b_Cancel.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
        }
    }
}
