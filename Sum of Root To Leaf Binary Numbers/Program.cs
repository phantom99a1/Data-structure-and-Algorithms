namespace Sum_of_Root_To_Leaf_Binary_Numbers
{
    
    // Definition for a binary tree node.
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
      public int val = val;
      public TreeNode? left = left;
      public TreeNode? right = right;
    }

    public class Solution
    {
        public static int SumRootToLeaf(TreeNode root)
        {
            var sum = 0;
            Helper(root, 0, ref sum);
            return sum;
        }

        private static void Helper(TreeNode? node, int current, ref int sum)
        {
            if (node == null) return;

            current = current * 2 + node.val;
            if (node.left == null && node.right == null)
            {
                sum += current;
                return;
            }

            Helper(node.left, current, ref sum);
            Helper(node.right, current, ref sum);
        }
    }
}
