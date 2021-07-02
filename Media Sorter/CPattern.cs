using System.ComponentModel;

namespace Media_Sorter
{
    public class CPattern
    {
        [DisplayName("Расширение файла")]
        public string Extension { get; set; }

        [DisplayName("Категория метаданных")]
        public string DirectoryName { get; set; }

        [DisplayName("Параметр")]
        public string TagName { get; set; }

        [DisplayName("Паттерн")]
        public string Pattern { get; set; }
    }
}
