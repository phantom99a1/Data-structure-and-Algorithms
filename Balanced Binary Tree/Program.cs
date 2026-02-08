namespace Balanced_Binary_Tree
{
    public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        public int val = val;
        public TreeNode left = left;
        public TreeNode right = right;
    }

    public class Solution
    {
        public bool IsBalanced(TreeNode root)
        {
            return DfsHeight(root) != -1;
        }

        private int DfsHeight(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = DfsHeight(node.left);
            if (leftHeight == -1) return -1;

            int rightHeight = DfsHeight(node.right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}
