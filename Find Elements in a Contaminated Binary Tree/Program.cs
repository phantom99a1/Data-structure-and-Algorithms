namespace Find_Elements_in_a_Contaminated_Binary_Tree
{
    /*Given a binary tree with the following rules:
    root.val == 0
    For any treeNode:
    If treeNode.val has a value x and treeNode.left != null, then treeNode.left.val == 2 * x + 1
    If treeNode.val has a value x and treeNode.right != null, then treeNode.right.val == 2 * x + 2
    Now the binary tree is contaminated, which means all treeNode.val have been changed to -1.
    Implement the FindElements class:
    FindElements(TreeNode* root) Initializes the object with a contaminated binary tree and recovers it.
    bool find(int target) Returns true if the target value exists in the recovered binary tree.
    
    Constraint:
    TreeNode.val == -1
    The height of the binary tree is less than or equal to 20
    The total number of nodes is between [1, 10^4]
    Total calls of find() is between [1, 10^4]
    0 <= target <= 10^6
     */
    
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    public class FindElements
    {
        private readonly TreeNode root;
        private readonly HashSet<int> values;

        public FindElements(TreeNode root)
        {
            this.root = Recover(root, 0);
            this.values = [];
            CollectValues(this.root);
        }

        private TreeNode Recover(TreeNode node, int val)
        {
            if (node == null) return null;
            node.val = val;
            node.left = Recover(node.left!, 2 * val + 1);
            node.right = Recover(node.right!, 2 * val + 2);
            return node;
        }

        private void CollectValues(TreeNode node)
        {
            if (node == null) return;
            values.Add(node.val);
            CollectValues(node.left!);
            CollectValues(node.right!);
        }

        public bool Find(int target)
        {
            return values.Contains(target);
        }
    }

    public class Program
    {
        public static void Main()
        {
            TreeNode root = new(-1);
            // Assume we build the contaminated binary tree here

            FindElements finder = new FindElements(root);

            while (true)
            {
                Console.WriteLine("Enter target value: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int target) && target >= 0 && target <= 1000000)
                {
                    bool result = finder.Find(target);
                    Console.WriteLine("Target value found: " + result);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid target value between 0 and 1000000.");
                }
            }
        }
    }
}
