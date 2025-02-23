namespace Construct_Binary_Tree_from_Preorder_and_Postorder_Traversal
{
    /*Given two integer arrays, preorder and postorder where preorder is the preorder traversal of a binary tree of 
    distinct values and postorder is the postorder traversal of the same tree, reconstruct and return the binary tree.
    If there exist multiple answers, you can return any of them.
    
    Constraint:
    1 <= preorder.length <= 30
    1 <= preorder[i] <= preorder.length
    All the values of preorder are unique.
    postorder.length == preorder.length
    1 <= postorder[i] <= postorder.length
    All the values of postorder are unique.
    It is guaranteed that preorder and postorder are the preorder traversal and postorder traversal of the same binary tree.
     */
    
    public class TreeNode(int x)
    {
        public int val = x;
        public TreeNode? left;
        public TreeNode? right;
    }

    public class Solution
    {
        private int _preIndex;
        private int _posIndex;

        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            var root = new TreeNode(preorder[_preIndex++]);

            if (root.val != postorder[_posIndex])
            {
                root.left = ConstructFromPrePost(preorder, postorder);
            }

            if (root.val != postorder[_posIndex])
            {
                root.right = ConstructFromPrePost(preorder, postorder);
            }

            _posIndex++;

            return root;
        }
    }

    public class Program
    {
        private const int minLengh = 1;
        private const int maxLength = 30;
        private const int minColumnLength = 1;
        public static void Main()
        {
            Solution solution = new();
            int[] preorder = GetValidInput("Enter preorder traversal (comma separated): ");
            int[] postorder = GetValidInput("Enter postorder traversal (comma separated): ");

            if (preorder.Length != postorder.Length)
            {
                Console.WriteLine("Preorder and postorder lengths do not match.");
                return;
            }

            TreeNode root = solution.ConstructFromPrePost(preorder, postorder);
            Console.WriteLine("Constructed Tree:");
            List<int> result = LevelOrderTraversal(root);
            Console.WriteLine("[" + string.Join(",", result) + "]");
            Console.ReadKey();
        }

        public static int[] GetValidInput(string prompt)
        {
            int[] input;
            while (true)
            {
                Console.Write(prompt);
                string inputLine = Console.ReadLine() ?? "";
                try
                {
                    input = inputLine.Split(',').Select(int.Parse).ToArray();
                    if (ValidateInput(input)) break;
                    Console.WriteLine("Invalid input. Ensure it meets the constraints.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter comma-separated integers.");
                }
            }
            return input;
        }

        public static bool ValidateInput(int[] arr)
        {
            if (arr.Length < minLengh || arr.Length > maxLength) return false;
            var uniqueValues = new HashSet<int>(arr);
            return arr.Length == uniqueValues.Count && arr.All(val => val >= minColumnLength && val <= arr.Length);
        }

        public static List<int> LevelOrderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                result.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return result;
        }
    }
}
