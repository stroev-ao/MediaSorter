using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FSettings : Form
    {
        const string TITLE = "Media Sorter";
        CPatternManager patternManager;
        CDestinationManager destinationManager;
        BindingSource source;
        string tempPath;
        ToolTip toolTip;
        string[] parts;

        public FSettings(CDestinationManager destinationManager, CPatternManager patternManager)
        {
            InitializeComponent();

            this.destinationManager = destinationManager;
            this.patternManager = patternManager;
        }

        private void FSettings_Load(object sender, EventArgs e)
        {
            parts = new string[] { "YYYY", "MM", "DD", "hh", "mm", "ss" };

            source = new BindingSource();
            source.DataSource = destinationManager.Destinations;
            dgv_Paths.DataSource = source;

            b_AddPath.Enabled = false;

            tb_RenamingTemplate.Text = Properties.Settings.Default.RenamingTemplate;
        }

        private void FSettings_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

            CheckPaths();
        }

        private void FSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!CheckRenamingTemplate())
            {
                Cursor.Current = Cursors.Default;
                e.Cancel = true;
                tb_RenamingTemplate_Leave(tb_RenamingTemplate, new EventArgs());
                return;
            }

            Properties.Settings.Default.RenamingTemplate = tb_RenamingTemplate.Text;

            patternManager = null;

            dgv_Paths.DataSource = null;
            source.Dispose();
            source = null;

            destinationManager.SaveDestinations();
            destinationManager = null;

            if (toolTip != null)
            {
                toolTip.Dispose();
                toolTip = null;
            }

            parts = null;

            Cursor.Current = Cursors.Default;
        }

        private void tb_Path_TextChanged(object sender, EventArgs e)
        {
            b_AddPath.Enabled = tb_Path.Text.Length > 0;
        }

        private void b_Browse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { RootFolder = Environment.SpecialFolder.Desktop })
            {
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                tb_Path.Text = fbd.SelectedPath;
            }
        }

        private void b_AddPath_Click(object sender, EventArgs e)
        {
            string path = tb_Path.Text;

            if (!destinationManager.CheckFolder(path))
            {
                MessageBox.Show("Путь \"" + path + "\" не существует", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                tb_Path.Text = "";
                tb_Path.Focus();
                
                return;
            }

            (source.DataSource as List<CDestination>).AddAndNotify(new CDestination(path), CollectionChangedHandler);
            source.ResetBindings(false);
        }

        private void dgv_Paths_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object value = dgv_Paths.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (value == null)
            {
                MessageBox.Show("Путь не может быть нулевой длины", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv_Paths.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempPath;
                return;
            }

            string path = value.ToString();
            if (!destinationManager.CheckFolder(path))
            {
                MessageBox.Show("Путь \"" + path + "\" не существует", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv_Paths.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempPath;

                dgv_Paths.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                dgv_Paths.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
            }
            else
            {
                dgv_Paths.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Paths.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void dgv_Paths_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempPath = dgv_Paths.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void tb_RenamingTemplate_Leave(object sender, EventArgs e)
        {
            bool success = CheckRenamingTemplate();
            b_Close.Enabled = success;
            this.ControlBox = success;

            if (!success)
            {

                if (toolTip == null)
                {
                    toolTip = new ToolTip();
                    toolTip.ToolTipTitle = "Внимание";
                }

                string message = "Шаблон переименования должен содержать все перечисленные составляющие: ";
                for (int i = 0; i < parts.Length; i++)
                    message += i < parts.Length - 1 ? parts[i] + ", " : parts[i];

                toolTip.Show(message, tb_RenamingTemplate, 0, -36, 5000);
                tb_RenamingTemplate.Focus();
            }
        }

        private void b_Patterns_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            using (FPatterns form = new FPatterns(patternManager))
                form.ShowDialog();
        }

        private void cms_Paths_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgv_Paths.SelectedRows.Count == 0)
                e.Cancel = true;
        }

        private void tsmi_DeletePath_Click(object sender, EventArgs e)
        {
            int count = dgv_Paths.SelectedRows.Count;

            if (count == 0)
                return;

            string question = (count > 1) ? "Вы действительно хотите удалить выбранные пути назначения?" : "Вы действительно хотите удалить выбранный путь назначения?";

            if (MessageBox.Show(question, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            for (int i = 0; i < count; i++)
            {
                int idx = dgv_Paths.SelectedRows[i].Index;

                (source.DataSource as List<CDestination>).RemoveAtAndNotify(idx, CollectionChangedHandler);
            }

            source.ResetBindings(false);
        }

        private void CheckPaths()
        {
            bool badDestinationFounded = false;

            destinationManager.CheckDestinations();

            for (int i = 0; i < destinationManager.Destinations.Count; i++)
                if (!destinationManager.Destinations[i].Actual)
                {
                    dgv_Paths.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dgv_Paths.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;

                    badDestinationFounded = true;
                }
                else
                {
                    dgv_Paths.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    dgv_Paths.Rows[i].DefaultCellStyle.SelectionForeColor = Color.White;
                }

            if (badDestinationFounded)
                MessageBox.Show("Один или несколько путей назначения не существуют", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool CheckRenamingTemplate()
        {
            string text = tb_RenamingTemplate.Text;
            bool success = true;
            for (int i = 0; i < parts.Length; i++)
                if (!text.Contains(parts[i]))
                {
                    success = false;
                    break;
                }

            return success;
        }

        private void CollectionChangedHandler()
        {
            destinationManager.Changed = true;
        }
    }
}
