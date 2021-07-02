using System.Drawing;

namespace Media_Sorter
{
    public class CFile
    {
        public int ID { get; private set; }
        public int FolderID { get; private set; }
        public int SortedFolderID { get; set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Extension { get; private set; }
        public Image Image { get; private set; }
        public bool ImageScanned { get { return Image != null; } }
        public bool BadFile { get; set; }

        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Seconds { get; set; }

        public CFile(int id, int folderId, string name, string path, string extension)
        {
            ID = id;
            FolderID = folderId;
            Name = name;
            Path = path;
            Extension = extension;
            Image = null;
            SortedFolderID = -2;
        }

        ~CFile()
        {
            if (Image != null)
                Image.Dispose();
            Image = null;
        }

        public void SetImage(Image image)
        {
            Image = image;
        }
    }
}
