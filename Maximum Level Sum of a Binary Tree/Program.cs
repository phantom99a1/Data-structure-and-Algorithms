namespace Maximum_Level_Sum_of_a_Binary_Tree
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
        public int MaxLevelSum(TreeNode root)
        {

            if (root is null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int maxLevel = 1;
            long maxSum = long.MinValue; //for preventing overflow
            int currentLevel = 1;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count; //no of nodes in the current level
                long currentLevelSum = 0;

                //Process all nodes in the current level
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    currentLevelSum += node.val;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                //Check if this level is new maximum, use strictly greater as if sum equal , we use smallest level number
                if (currentLevelSum > maxSum)
                {
                    maxSum = currentLevelSum;
                    maxLevel = currentLevel;
                }

                currentLevel++;

            }

            return maxLevel;

        }
    }
}
