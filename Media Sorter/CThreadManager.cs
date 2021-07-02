using System.Collections.Generic;

namespace Media_Sorter
{
    public class CThreadManager
    {
        List<int> threads;

        public int Count { get { return threads.Count; } }

        public CThreadManager()
        {
            threads = new List<int>();
        }

        ~CThreadManager()
        {
            threads.Clear();
            threads = null;
        }

        public void Clear()
        {
            threads.Clear();
        }

        public void AddThread(int code)
        {
            if (threads.Contains(code))
                return;

            threads.Add(code);
        }

        public void RemoveThread(int code)
        {
            if (!threads.Contains(code))
                return;

            threads.Remove(code);
        }

        public int GetLastThread()
        {
            return threads[threads.Count - 1];
        }
    }
}
