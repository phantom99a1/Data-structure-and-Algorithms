namespace Minimum_Number_of_Operations_to_Sort_a_Binary_Tree_by_Level
{
    /*You are given the root of a binary tree with unique values.

    In one operation, you can choose any two nodes at the same level and swap their values.

    Return the minimum number of operations needed to make the values at each level sorted in a strictly increasing order.

    The level of a node is the number of edges along the path between it and the root node.
    
    Constraints:
    The number of nodes in the tree is in the range [1, 10^5].
    1 <= Node.val <= 10^5
    All the values of the tree are unique.
     */    
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    public class Solution
    {
        public static int MinOperationsToSortByLevel(TreeNode root)
        {
            if (root == null) return 0;

            var levels = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                var level = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                levels.Add(level);
            }

            int operations = 0;

            foreach (var level in levels)
            {
                operations += MinSwapsToSort(level);
            }

            return operations;
        }

        private static int MinSwapsToSort(List<int> arr)
        {
            int n = arr.Count;
            var arrPos = arr.Select((value, index) => new KeyValuePair<int, int>(value, index)).ToList();
            arrPos.Sort((a, b) => a.Key.CompareTo(b.Key));

            var visited = new bool[n];
            int swaps = 0;

            for (int i = 0; i < n; i++)
            {
                if (visited[i] || arrPos[i].Value == i) continue;

                int cycleSize = 0;
                int x = i;

                while (!visited[x])
                {
                    visited[x] = true;
                    x = arrPos[x].Value;
                    cycleSize++;
                }

                if (cycleSize > 0)
                {
                    swaps += cycleSize - 1;
                }
            }

            return swaps;
        }

        public static bool ValidateInput(int?[] values)
        {
            int max_length = 100000;
            int max_value = 100000;
            int n = values.Length;
            var uniqueValues = new HashSet<int?>();

            foreach (var val in values)
            {
                if (val.HasValue && (val < 1 || val > max_value))
                {
                    return false;
                }
                if (val.HasValue && !uniqueValues.Add(val))
                {
                    return false;
                }
            }

            if (n < 1 || n > max_length)
            {
                return false;
            }

            return true;
        }

        public static void Main()
        {
            Console.Write("Enter the binary tree as a space-separated list of integers (use null for empty nodes): ");
            string input = Console.ReadLine() ??"";

            int?[] values = input.Split(' ').Select(v => v == "null" ? (int?)null : int.Parse(v)).ToArray();

            if (ValidateInput(values))
            {
                TreeNode root = BuildTree(values);
                int result = MinOperationsToSortByLevel(root);
                Console.WriteLine($"Minimum number of operations: {result}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please ensure the tree meets the constraints.");
                Console.ReadKey();
            }
        }

        private static TreeNode? BuildTree(int?[] values)
        {
            if (values.Length == 0) return null;

            var root = new TreeNode(values[0].GetValueOrDefault());
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                var node = queue.Dequeue();

                if (values[i].HasValue)
                {
                    node.left = new TreeNode(values[i].Value);
                    queue.Enqueue(node.left);
                }
                i++;

                if (i < values.Length && values[i].HasValue)
                {
                    node.right = new TreeNode(values[i].Value);
                    queue.Enqueue(node.right);
                }
                i++;
            }

            return root;
        }
    }
}
