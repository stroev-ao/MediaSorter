using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Media_Sorter
{
    public class CFolderManager
    {
        int id;
        Dictionary<int, CFolder> folders;
        string[] filter;

        public CFolderManager(string[] filter = null)
        {
            folders = new Dictionary<int, CFolder>();
            this.filter = filter;
        }

        ~CFolderManager()
        {
            filter = null;
            folders.Clear();
            folders = null;
        }

        public int AddFolder(int parentId, string name, string path)
        {
            folders.Add(id, new CFolder(id, parentId, name, path));

            return id++;
        }

        public string GetPath(int id)
        {
            if (!folders.ContainsKey(id))
                throw new ArgumentException();

            return folders[id].Path;
        }

        public string[] ScanFolder(int id)
        {
            if (!folders.ContainsKey(id))
                throw new ArgumentException();

            var folder = folders[id];
            if (folder.Scanned)
                return null;

            string path = folder.Path;

            string[] files = null;
            try
            {
                files = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw new UnauthorizedAccessException(uae.Message);
            }

            return files.Where(f => filter.Contains(Path.GetExtension(f).ToLower())).ToArray();
        }

        public void Clear()
        {
            id = 0;
            folders.Clear();
        }

        public void OpenLocation(int id, string filePath)
        {
            Process.Start("explorer.exe", string.Format("/select, \"{0}\"", filePath));
        }

        public void OpenFolder(int id)
        {
            OpenFolder(folders[id].Path);
        }

        public void OpenFolder(string path)
        {
            Process.Start(path);
        }

        public bool CheckFolder(string path)
        {
            return Directory.Exists(path);
        }
    }
}
