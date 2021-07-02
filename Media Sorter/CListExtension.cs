using System.Collections.Generic;

namespace Media_Sorter
{
    public static class CListExtension
    {
        public delegate void DCollectionChanged();

        public static void AddAndNotify<T>(this List<T> list, T item, DCollectionChanged collectionChanged)
        {
            list.Add(item);

            if (collectionChanged != null)
                collectionChanged.Invoke();
        }

        public static void RemoveAtAndNotify<T>(this List<T> list, int index, DCollectionChanged collectionChanged)
        {
            list.RemoveAt(index);

            if (collectionChanged != null)
                collectionChanged.Invoke();
        }
    }
}
