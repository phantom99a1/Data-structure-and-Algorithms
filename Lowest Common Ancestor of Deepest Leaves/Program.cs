namespace Lowest_Common_Ancestor_of_Deepest_Leaves
{
    /*Given the root of a binary tree, return the lowest common ancestor of its deepest leaves.
    Recall that:
    The node of a binary tree is a leaf if and only if it has no children
    The depth of the root of the tree is 0. if the depth of a node is d, the depth of each of its children is d + 1.
    The lowest common ancestor of a set S of nodes, is the node A with the largest depth such that every node in S is 
    in the subtree with root A.
    
    Constraint:
    The number of nodes in the tree will be in the range [1, 1000].
    0 <= Node.val <= 1000
    The values of the nodes in the tree are unique.
     */
    using System;
    using System.Collections.Generic;

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

    class Program
    {
        static int ValidateInput()
        {
            int input;
            while (true)
            {
                Console.Write("Enter a node value (0 <= val <= 1000): ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out input) && input >= 0 && input <= 1000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number in range [0, 1000].");
                }
            }
            return input;
        }

        static (TreeNode, int) Helper(TreeNode node)
        {
            if (node == null) return (null, 0);
            var (leftNode, leftDepth) = Helper(node.left);
            var (rightNode, rightDepth) = Helper(node.right);
            if (leftDepth == rightDepth) return (node, leftDepth + 1);
            return leftDepth > rightDepth ? (leftNode, leftDepth + 1) : (rightNode, rightDepth + 1);
        }

        static TreeNode LcaDeepestLeaves(TreeNode root)
        {
            return Helper(root).Item1;
        }

        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(ValidateInput());
            root.left = new TreeNode(ValidateInput());
            root.right = new TreeNode(ValidateInput());
            Console.WriteLine("Lowest Common Ancestor of Deepest Leaves: " + LcaDeepestLeaves(root).val);
        }
    }
}
