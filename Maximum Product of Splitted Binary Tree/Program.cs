namespace Maximum_Product_of_Splitted_Binary_Tree
{
    public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        public int val = val;
        public TreeNode left = left;
        public TreeNode right = right;
    }
    public class Solution
    {
        long total = 0, best = 0;
        const int MOD = 1000000007;

        long Sum(TreeNode node)
        {
            if (node == null) return 0;
            return node.val + Sum(node.left) + Sum(node.right);
        }

        long Dfs(TreeNode node)
        {
            if (node == null) return 0;
            long s = node.val + Dfs(node.left) + Dfs(node.right);
            best = Math.Max(best, s * (total - s));
            return s;
        }

        public int MaxProduct(TreeNode root)
        {
            total = Sum(root);
            Dfs(root);
            return (int)(best % MOD);
        }
    }
}
