using System.Windows.Forms;

namespace Media_Sorter
{
    public static class CTreeNodeCollectionExtension
    {
        public delegate void DTreeNodeAmountChanged(int count);

        public static TreeNode AddAndNotifiy(this TreeNodeCollection treeNodeCollection, string key, string text, DTreeNodeAmountChanged nodeAmountChanged)
        {
            TreeNode node = treeNodeCollection.Add(key, text);

            if (nodeAmountChanged != null)
                nodeAmountChanged.Invoke(treeNodeCollection.Count);

            return node;
        }

        public static void ClearAndNotify(this TreeNodeCollection treeNodeCollection, DTreeNodeAmountChanged nodeAmountChanged)
        {
            treeNodeCollection.Clear();

            if (nodeAmountChanged != null)
                nodeAmountChanged.Invoke(treeNodeCollection.Count);
        }
    }
}
