using System;
using System.Windows.Forms;

namespace Media_Sorter
{
    public static class CTreeViewExtension
    {
        public static TreeNode GetNodeWithTag(this TreeView treeView, int tag)
        {
            TreeNode result = null;

            for (int i = 0; result == null && i < treeView.Nodes.Count; i++)
                result = Search(treeView.Nodes[i], tag);

            return result;
        }

        private static TreeNode Search(TreeNode node, int tag)
        {
            TreeNode result = null;

            if (Convert.ToInt32(node.Tag) == tag)
                result = node;
            else
                for (int i = 0; result == null && i < node.Nodes.Count; i++)
                    result = Search(node.Nodes[i], tag);

            return result;
        }
    }
}
