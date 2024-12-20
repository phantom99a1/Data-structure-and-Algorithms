namespace Reverse_Odd_Levels_of_Binary_Tree
{
    /*Given the root of a perfect binary tree, reverse the node values at each odd level of the tree.

    For example, suppose the node values at level 3 are [2,1,3,4,7,11,29,18], then it should become [18,29,11,7,4,3,1,2].
    Return the root of the reversed tree.

    A binary tree is perfect if all parent nodes have two children and all leaves are on the same level.

    The level of a node is the number of edges along the path between it and the root node.
    
    Constraints:

    The number of nodes in the tree is in the range [1, 2^14].
    0 <= Node.val <= 10^5
    root is a perfect binary tree.
     */
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }

    public class Program
    {
        public static void Main()
        {
            TreeNode? root = null;

            // Read and validate input
            while (true)
            {
                Console.Write("Enter the tree elements as space-separated integers (use 'null' for missing nodes): ");
                var input = Console.ReadLine() ?? "";

                try
                {
                    var arr = input.Split(' ').Select(val => val == "null" ? (int?)null : int.Parse(val)).ToArray();
                    if (arr.Length > 0 && arr.Length <= Math.Pow(2,14) && arr.All(val => val == null || val >= 0 && val <= Math.Pow(10,5)))
                    {
                        root = BuildTreeFromArray(arr);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a list of space-separated integers or 'null' for missing nodes.");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a list of space-separated integers.");
                    Console.ReadKey();
                }
            }

            // Process and print the tree
            root = ReverseOddLevels(root);
            PrintTree(root);
        }

        public static TreeNode? BuildTreeFromArray(int?[] arr)
        {
            if (arr.Length == 0 || arr[0] == null) return null;
            TreeNode root = new(arr[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (i < arr.Length)
            {
                TreeNode node = queue.Dequeue();
                if (i < arr.Length && arr[i] != null)
                {
                    node.Left = new TreeNode(arr[i].Value);
                    queue.Enqueue(node.Left);
                }
                i++;
                if (i < arr.Length && arr[i] != null)
                {
                    node.Right = new TreeNode(arr[i].Value);
                    queue.Enqueue(node.Right);
                }
                i++;
            }
            return root;
        }

        public static TreeNode ReverseOddLevels(TreeNode root)
        {
            if (root == null) return root;
            int level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<TreeNode> levelNodes = new List<TreeNode>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (level % 2 != 0)
                    {
                        levelNodes.Add(node);
                    }
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                if (level % 2 != 0)
                {
                    int l = 0, r = levelNodes.Count - 1;
                    while (l < r)
                    {
                        int temp = levelNodes[l].Val;
                        levelNodes[l].Val = levelNodes[r].Val;
                        levelNodes[r].Val = temp;
                        l++;
                        r--;
                    }
                }
                level++;
            }
            return root;
        }

        public static void PrintTree(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<int> result = new List<int>();
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                result.Add(node.Val);
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
            Console.WriteLine(string.Join(" ", result));
            Console.ReadKey();
        }
    }
}
