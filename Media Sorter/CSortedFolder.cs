using System;

namespace Media_Sorter
{
    public class CSortedFolder : ICloneable
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Path { get; private set; }
        public bool Checked { get; set; }

        public CSortedFolder(int id, int parentId, string name, string path)
        {
            ID = id;
            ParentID = parentId;
            Name = name;
            Path = path;
            Checked = true;
        }

        public override string ToString()
        {
            return string.Format("ID={0}; ParentID={1}; Name={2}", ID, ParentID, Name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
