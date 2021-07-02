using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Media_Sorter
{
    public class CPatternManager
    {
        bool changed;
        List<CPattern> patterns;

        public List<CPattern> Patterns { get { return patterns; } }
        public bool Changed { set { changed = value; } }

        public CPatternManager()
        {
            patterns = new List<CPattern>();

            string path = Properties.Settings.Default.PatternsPath;

            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("[]");
                    sw.Flush();
                }
            }
        }

        ~CPatternManager()
        {
            patterns.Clear();
            patterns = null;
        }

        public void LoadPattenrs()
        {
            string path = Properties.Settings.Default.PatternsPath;

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();

                patterns = JsonConvert.DeserializeObject<List<CPattern>>(text);
            }
        }

        public void SavePatterns()
        {
            if (!changed)
                return;

            string path = Properties.Settings.Default.PatternsPath;

            using (StreamWriter sw = new StreamWriter(path))
            {
                string text = JsonConvert.SerializeObject(patterns);

                sw.Write(text);
                sw.Flush();
            }
        }

        public CPattern[] GetPatternsByExtension(string extension)
        {
            if (patterns.Count(p => p.Extension == extension) == 0)
                return null;

            return patterns.Where(p => p.Extension == extension).ToArray();
        }
    }
}
