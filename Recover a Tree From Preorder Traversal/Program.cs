namespace Recover_a_Tree_From_Preorder_Traversal
{
    /*We run a preorder depth-first search (DFS) on the root of a binary tree.
    At each node in this traversal, we output D dashes (where D is the depth of this node), then we output the value of this node. 
    If the depth of a node is D, the depth of its immediate child is D + 1.  The depth of the root node is 0.
    If a node has only one child, that child is guaranteed to be the left child.
    Given the output traversal of this traversal, recover the tree and return its root.

    Constraint:
    The number of nodes in the original tree is in the range [1, 1000].
    1 <= Node.val <= 10^9
    */
    
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        private const int minValue = 1;
        private const int maxValue = 1000000000;
        public static TreeNode RecoverFromPreorder(string traversal)
        {
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < traversal.Length;)
            {
                int level = 0;
                while (i < traversal.Length && traversal[i] == '-')
                {
                    level++;
                    i++;
                }
                int val = 0;
                while (i < traversal.Length && traversal[i] != '-')
                {
                    val = val * 10 + (traversal[i] - '0');
                    i++;
                }
                if (val < minValue || val > maxValue)
                {
                    throw new ArgumentException($"Node value must be in the range [{minValue}, {maxValue}]");
                }
                while (stack.Count > level)
                {
                    stack.Pop();
                }
                var node = new TreeNode(val);
                if (stack.Count > 0)
                {
                    if (stack.Peek().left == null)
                    {
                        stack.Peek().left = node;
                    }
                    else
                    {
                        stack.Peek().right = node;
                    }
                }
                stack.Push(node);
            }
            return stack.Peek();
        }

        public static void Main()
        {
            Console.WriteLine("Enter the preorder traversal string:");
            string traversal = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(traversal))
            {
                Console.WriteLine("Error: The input string cannot be empty.");
                return;
            }

            foreach (char c in traversal)
            {
                if (c != '-' && !char.IsDigit(c))
                {
                    Console.WriteLine("Error: The input string contains invalid characters.");
                    return;
                }
            }

            if (!IsValidPreorderTraversal(traversal))
            {
                Console.WriteLine("Error: Invalid preorder traversal format.");
                return;
            }

            Console.WriteLine("Valid input. Recovering the tree...");
            try
            {
                TreeNode root = RecoverFromPreorder(traversal);
                PrintTree(root);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool IsValidPreorderTraversal(string traversal)
        {
            // Implement additional validations if needed
            return traversal.Length >= minLength && traversal.Length <= maxLength;
        }

        public static void PrintTree(TreeNode node, string indent = "")
        {
            if (node != null)
            {
                Console.WriteLine(indent + node.val);
                PrintTree(node.left!, indent + "  ");
                PrintTree(node.right!, indent + "  ");
            }
        }
    }
}
