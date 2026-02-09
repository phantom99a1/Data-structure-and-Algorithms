namespace Balance_a_Binary_Search_Tree
{
    /*
Title: 1382. Balance a Binary Search Tree
Solution:
Difficulty: Medium
Approach: In-Order Traversal + Divide and Conquer
Tags: Tree, Binary Search Tree, Depth-First Search, Divide and Conquer
1) Perform in-order traversal of the BST to get sorted array of values.
2) Use the sorted array to build a balanced BST recursively.
3) Choose the middle element as root to ensure balance.
4) Recursively build left subtree from left half and right subtree from right half.
5) This ensures the tree is height-balanced with minimal depth.

Time Complexity: O(n) where n = number of nodes (traversal + building)
Space Complexity: O(n) for storing the in-order traversal and recursion stack
Tip: The key insight is that in-order traversal of a BST gives a sorted array. Building a balanced BST from a sorted array is done by picking the middle element as root - this ensures the tree is balanced since both subtrees have equal (or nearly equal) number of nodes.
Similar Problems: 108. Convert Sorted Array to Binary Search Tree, 109. Convert Sorted List to Binary Search Tree, 426. Convert Binary Search Tree to Sorted Doubly Linked List
*/
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
        List<int> inOrderTraversal;                                     // List to store sorted values from BST

        public TreeNode BalanceBST(TreeNode root)
        {
            inOrderTraversal = new List<int>();                         // Initialize list for in-order values
            InOrderTraversal(root);                                     // Perform in-order traversal to get sorted array
            return BuildBST(0, inOrderTraversal.Count - 1);              // Build balanced BST from sorted array
        }

        private TreeNode BuildBST(int left, int right)
        {
            if (left > right)                                           // Base case: no elements to process
                return null;
            int mid = left + (right - left) / 2;                        // Find middle index to ensure balance
            TreeNode root = new TreeNode(inOrderTraversal[mid]);        // Create root node with middle element
            root.left = BuildBST(left, mid - 1);                          // Recursively build left subtree
            root.right = BuildBST(mid + 1, right);                        // Recursively build right subtree
            return root;                                                // Return constructed balanced subtree
        }

        private void InOrderTraversal(TreeNode root)
        {
            if (root == null)                                           // Base case: null node
                return;
            InOrderTraversal(root.left);                                // Traverse left subtree first
            inOrderTraversal.Add(root.val);                             // Add current node value (in sorted order)
            InOrderTraversal(root.right);                               // Traverse right subtree last
        }
    }
}
