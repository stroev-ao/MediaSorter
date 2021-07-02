using System;
using System.Drawing;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FMetadata : Form
    {
        const string TITLE = "Метаданные";
        CFileManager fileManager;
        int fileId;

        public FMetadata(CFileManager fileManager, int fileId, Size parentSize, Point parentLocation)
        {
            InitializeComponent();

            this.fileManager = fileManager;
            this.fileId = fileId;

            this.Location = new Point(parentLocation.X + parentSize.Width / 2 - this.Width / 2, parentLocation.Y + parentSize.Height / 2 - this.Height / 2);
        }

        private void FMetadata_Load(object sender, EventArgs e)
        {
            string name = fileManager.GetFileName(fileId);
            this.Text = name + " – " + TITLE;

            pb_Preview.Image = fileManager.GetImage(fileId);
            tb_Name.Text = name;

            string data = string.Empty;
            foreach (string line in fileManager.GetMetadata(fileId))
                data += line + "\n";

            richTextBox1.Text = data;
        }

        private void FMetadata_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void FMetadata_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileManager = null;

            this.Dispose();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
