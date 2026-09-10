namespace Count_Nodes_Equal_to_Average_of_Subtree
{
 public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
                }
  }

    public class Solution
    {
        public int AverageOfSubtree(TreeNode root)
        {
            int result = 0;
            Traverse(root, ref result);
            return result;
        }

        private (int, int) Traverse(TreeNode node, ref int result)
        {
            if (node == null) return (0, 0);

            var (leftSum, leftCount) = Traverse(node.left, ref result);
            var (rightSum, rightCount) = Traverse(node.right, ref result);

            int currSum = node.val + leftSum + rightSum;
            int currCount = 1 + leftCount + rightCount;

            if (currSum / currCount == node.val) result++;

            return (currSum, currCount);
        }
    }
}
