using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FPatterns : Form
    {
        const string TITLE = "Media Sorter";
        CPatternManager patternManager;
        BindingSource source;

        public FPatterns(CPatternManager patternManager)
        {
            InitializeComponent();

            this.patternManager = patternManager;
        }

        private void FPatterns_Load(object sender, EventArgs e)
        {
            source = new BindingSource();
            source.DataSource = patternManager.Patterns;
            dgv_Patterns.DataSource = source;

            dgv_Patterns_SelectionChanged(dgv_Patterns, new EventArgs());

            tsb_DeletePattern.Enabled = false;
        }

        private void FPatterns_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void FPatterns_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgv_Patterns.DataSource = null;
            source.Dispose();
            source = null;
        }

        private void tsb_AddPattern_Click(object sender, EventArgs e)
        {
            (source.DataSource as List<CPattern>).AddAndNotify(new CPattern(), CollectionChangedHandler);

            source.ResetBindings(false);
        }

        private void tsb_DeletePattern_Click(object sender, EventArgs e)
        {
            int count = dgv_Patterns.SelectedRows.Count;

            if (count == 0)
                return;

            string question = (count > 1) ? "Вы действительно хотите удалить выбранные паттерны?" : "Вы действительно хотите удалить выбранный паттерн?";

            if (MessageBox.Show(question, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            for (int i = 0; i < count; i++)
            {
                int idx = dgv_Patterns.SelectedRows[i].Index;

                (source.DataSource as List<CPattern>).RemoveAtAndNotify(idx, CollectionChangedHandler);
            }

            source.ResetBindings(false);
        }

        private void dgv_Patterns_SelectionChanged(object sender, EventArgs e)
        {
            int count = dgv_Patterns.SelectedRows.Count;

            string text = string.Empty;
            if (count > 0)
                text = string.Format("Выбрано элементов: {0}", count);

            l_Status.Text = text;

            tsb_DeletePattern.Enabled = count > 0;
        }

        private void CollectionChangedHandler()
        {
            patternManager.Changed = true;
        }
    }
}
