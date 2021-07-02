namespace Media_Sorter
{
    public class CFolder
    {
        public int ID { get; private set; }
        public int ParentID { get; private set; }
        public string Name { get; set; }
        public string Path { get; private set; }
        public bool Scanned { get; set; }

        public CFolder(int id, int parentId, string name, string path)
        {
            ID = id;
            ParentID = parentId;
            Name = name;
            Path = path;
            Scanned = false;
        }
    }
}
