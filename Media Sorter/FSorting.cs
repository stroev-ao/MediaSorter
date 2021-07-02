using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Media_Sorter
{
    public partial class FSorting : Form
    {
        public delegate void DSetProgress(int progress);
        public delegate void DSetStatePaused();
        public delegate void DSetStateError();

        DSetProgress setProgress;
        DSetStatePaused setStatePaused;
        DSetStateError setStateError;

        private enum EState { Default = 0, Working = 1, Cancelled = 2 };

        const string TITLE = "Media Sorter";

        CDestinationManager destinationManager;
        CFileManager fileManager;
        CSortedFolderManager sortedFolderManager;
        CFolderManager folderManager;

        bool copy = true;
        bool renaming = false;

        int lastProgress;

        Font progressBarFont;

        public FSorting(CDestinationManager destinationManager, CFileManager fileManager,
            CSortedFolderManager sortedFolderManager, CFolderManager folderManager,
            DSetProgress setProgress, DSetStatePaused setStatePaused, DSetStateError setStateError)
        {
            InitializeComponent();

            this.destinationManager = destinationManager;
            this.fileManager = fileManager;
            this.sortedFolderManager = sortedFolderManager;
            this.folderManager = folderManager;

            this.setProgress += setProgress;
            this.setStatePaused += setStatePaused;
            this.setStateError += setStateError;
        }

        private void FSorting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < destinationManager.Destinations.Count; i++)
                lb_Destinations.Items.Add(destinationManager.Destinations[i].Path);

            l_RenamingTemplate.Text = "Шаблон: " + Properties.Settings.Default.RenamingTemplate;

            pb_Progress.Image = Properties.Resources.progressbar;

            SetState(EState.Default);

            cb_Renaming.Checked = Properties.Settings.Default.Renaming;

            progressBarFont = new Font("Courier New", 10, FontStyle.Bold);
        }

        private void FSorting_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

            if (!destinationManager.CheckDestinations())
                MessageBox.Show("Один или несколько путей назначения не существуют. При сортировке файлов они будут проигнорированы", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool value1 = destinationManager.Destinations.Count > 0;
            if (!value1)
                MessageBox.Show("Задайте пути назначения в разделе Настройки", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);

            bool value2 = sortedFolderManager.Folders.Length > 0;
            if (!value2)
                MessageBox.Show("Перед сортировкой необходимо выполнить Анализ медиафайлов", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);

            b_Start.Enabled = value1 & value2;
        }

        private void FSorting_FormClosing(object sender, FormClosingEventArgs e)
        {
            setProgress = null;
            setStatePaused = null;
            setStateError = null;

            destinationManager = null;
            fileManager = null;
            sortedFolderManager = null;
            folderManager = null;

            progressBarFont.Dispose();

            this.Tag = !copy;
        }

        private void SetProgress(int progress, Color begin, Color end)
        {
            lastProgress = progress;

            int width = pb_Progress.Width;
            int height = pb_Progress.Height;

            int readyWidth = width * progress / 100;
            readyWidth = (readyWidth > 0) ? readyWidth : 1;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            LinearGradientMode direction = LinearGradientMode.Horizontal;
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, readyWidth, height), begin, end, direction);

            g.FillRectangle(new SolidBrush(pb_Progress.Parent.BackColor), readyWidth, 0, width - readyWidth, height);
            g.FillRectangle(brush, 0, 0, readyWidth, height);

            string text = progress.ToString() + "%";
            SizeF size = g.MeasureString(text, progressBarFont);
            g.DrawString(text, progressBarFont, Brushes.Black, width / 2 - size.Width / 2, height / 2 - size.Height / 2);

            pb_Progress.BackgroundImage = bmp;
            pb_Progress.Image = Properties.Resources.progressbar;

            g.Dispose();
        }

        private void b_Start_Click(object sender, EventArgs e)
        {
            SetState(EState.Working);

            fileManager.OperateFiles(destinationManager, sortedFolderManager, copy, renaming, ProgressChangedHandler, WorkerCompletedHandler, ErrorOccuredHandler);
        }

        private void b_Stop_Click(object sender, EventArgs e)
        {
            fileManager.Cancel = true;

            SetState(EState.Cancelled);
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetState(EState newState)
        {
            bool value = newState == EState.Default;

            groupBox0.Enabled = value;
            groupBox1.Enabled = value;
            groupBox2.Enabled = value;

            this.ControlBox = value;
            b_Close.Enabled = value;

            b_Start.Enabled = b_Start.Visible = value;
            b_Stop.Enabled = b_Stop.Visible = newState == EState.Working;
        }

        private void rb_Copy_CheckedChanged(object sender, EventArgs e)
        {
            copy = rb_Copy.Checked;
        }

        private void cb_Renaming_CheckedChanged(object sender, EventArgs e)
        {
            renaming = cb_Renaming.Checked;

            Properties.Settings.Default.Renaming = renaming;
        }

        private void ProgressChangedHandler(int progress)
        {
            SetProgress(progress, Color.FromArgb(255, 71, 173, 104), Color.FromArgb(255, 0, 255, 0));

            if (setProgress != null)
                setProgress.Invoke(progress);
        }

        private void WorkerCompletedHandler(bool cancelled, int[] failedFileIDs)
        {
            SetState(EState.Default);

            if (destinationManager.Destinations.Count == 1)
            {
                string message = copy ? "Копирование файлов " : "Перемещение файлов ";
                message += cancelled ? "отменено" : "выполнено успешно. Открыть папку назначения?";

                if (cancelled)
                {
                    SetProgress(lastProgress, Color.FromArgb(173, 173, 71), Color.Yellow);

                    if (setStatePaused != null)
                        setStatePaused.Invoke();

                    MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show(message, TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        folderManager.OpenFolder(destinationManager.Destinations[0].Path);

                    if (setProgress != null)
                        setProgress.Invoke(0);

                    this.Close();
                }
            }
            else
            {
                string message = copy ? "Копирование файлов " : "Перемещение файлов ";
                message += cancelled ? "отменено" : "выполнено успешно";

                if (cancelled)
                {
                    SetProgress(lastProgress, Color.FromArgb(173, 173, 71), Color.Yellow);

                    ResetTaskbar();

                    MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetTaskbar();

                    this.Close();
                }
            }

            if (failedFileIDs != null)
            {
                string msg = "Не удалось ";
                msg += copy ? "скопировать " : "переместить ";
                msg += "следующие файлы:";

                for (int i = 0; i < failedFileIDs.Length; i++)
                    msg += "\n" + fileManager.GetFileName(failedFileIDs[i]);
            }
        }

        private void ErrorOccuredHandler(string message)
        {
            SetProgress(lastProgress, Color.FromArgb(173, 71, 71), Color.Red);

            if (setStateError != null)
                setStateError.Invoke();

            MessageBox.Show(message, TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ResetTaskbar()
        {
            if (setProgress != null)
                setProgress.Invoke(0);
        }
    }
}
