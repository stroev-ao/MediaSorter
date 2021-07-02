using System.ComponentModel;

namespace Media_Sorter
{
    public class CDestination
    {
        [DisplayName("Путь")]
        public string Path { get; set; }

        [Browsable(false)]
        public bool Actual { get; set; }

        public CDestination(string path)
        {
            Path = path;
            Actual = true;
        }
    }
}
