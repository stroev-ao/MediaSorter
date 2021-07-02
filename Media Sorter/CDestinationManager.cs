using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Media_Sorter
{
    public class CDestinationManager
    {
        bool changed;
        List<CDestination> destinations;

        public List<CDestination> Destinations { get { return destinations; } }
        public bool Changed { set { changed = value; } }

        public CDestinationManager()
        {
            LoadDestinations();

            CheckDestinations();
        }

        ~CDestinationManager()
        {
            destinations.Clear();
            destinations = null;
        }

        private void LoadDestinations()
        {
            string path = Properties.Settings.Default.DestinationsPath;
            if (path == "")
                path = "destinations.cfg";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("[]");
                    sw.Flush();
                }
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();

                destinations = JsonConvert.DeserializeObject<List<CDestination>>(text);
            }
        }

        public void SaveDestinations()
        {
            if (!changed)
                return;

            string path = Properties.Settings.Default.DestinationsPath;

            using (StreamWriter sw = new StreamWriter(path))
            {
                string text = JsonConvert.SerializeObject(destinations);

                sw.Write(text);
                sw.Flush();
            }
        }

        public bool CheckFolder(string path)
        {
            return Directory.Exists(path);
        }

        public bool CheckDestinations()
        {
            for (int i = 0; i < destinations.Count; i++)
                destinations[i].Actual = CheckFolder(destinations[i].Path);

            return destinations.Count(d => !d.Actual) == 0;
        }
    }
}
