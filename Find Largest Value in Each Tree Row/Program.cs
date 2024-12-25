namespace Find_Largest_Value_in_Each_Tree_Row
{
    /*Given the root of a binary tree, return an array of the largest value in each row of the tree (0-indexed).
     
    Constraint:
     The number of nodes in the tree will be in the range [0, 10^4].
    -2^31 <= Node.val <= 2^31 - 1
     */

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
 
    public class Solution
    {

        // Method to parse the input and create binary tree
        public static TreeNode? ParseInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var values = input.Split(',');
            if (values.Length == 0) return null;

            var root = new TreeNode(int.Parse(values[0]));
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                TreeNode node = queue.Dequeue();

                if (i < values.Length && values[i] != "null")
                {
                    node.left = new TreeNode(int.Parse(values[i]));
                    queue.Enqueue(node.left);
                }
                i++;

                if (i < values.Length && values[i] != "null")
                {
                    node.right = new TreeNode(int.Parse(values[i]));
                    queue.Enqueue(node.right);
                }
                i++;
            }

            return root;
        }

        // Method to find the largest values in each tree row
        public static IList<int> LargestValues(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                int maxVal = int.MinValue;

                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    if (node.val > maxVal)
                    {
                        maxVal = node.val;
                    }

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                result.Add(maxVal);
            }

            return result;
        }

        // Input validation
        public static bool ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var values = input.Split(',');

            if (values.Length > 10000) return false;  // Constraint: number of nodes <= 10^4
            foreach (var val in values)
            {
                if (val != "null" && (int.TryParse(val, out int num) == false || num < int.MinValue || num > int.MaxValue))
                {
                    return false; // Constraint: -2^31 <= Node.val <= 2^31 - 1
                }
            }

            return true;
        }

        // Main method to run the solution
        public static void Main()
        {
            Console.WriteLine("Enter the binary tree input (comma-separated, level order, 'null' for missing nodes):");
            string input = Console.ReadLine() ?? "";

            if (ValidateInput(input))
            {
                TreeNode? root = ParseInput(input);
                var result = LargestValues(root ?? new TreeNode());
                Console.WriteLine("Largest values in each row: [" + string.Join(", ", result) + "]");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
            }
        }
    }
}
