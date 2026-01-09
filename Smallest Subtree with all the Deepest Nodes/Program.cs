namespace Smallest_Subtree_with_all_the_Deepest_Nodes
{  
    public class Solution
    {
        public class Result
        {
            public TreeNode Node;
            public int Height;

            public Result(TreeNode node, int height)
            {
                Node = node;
                Height = height;
            }
        }

        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            return GetLcaAndHeight(root).Node;
        }

        public Result GetLcaAndHeight(TreeNode node)
        {

            //Base case : node null i.e height 0;
            if (node is null) return new Result(null, 0);

            //Post Order Traversal
            Result left = GetLcaAndHeight(node.left);
            Result right = GetLcaAndHeight(node.right);

            //Case 1 : Both sides have equal depth
            // hence deepest leaves are split on both sides from this node. 
            //hence this node is LCA
            if (left.Height == right.Height) return new Result(node, left.Height + 1);

            //Case 2 : Left side is deeper hence LCA must resides in the left side
            else if (left.Height > right.Height) return new Result(left.Node, left.Height + 1);

            //Case 3 : Hence Right Side is deeper, So LCA must reside in the right side of the tree.
            else return new Result(right.Node, right.Height + 1);

        }
    }

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
}
