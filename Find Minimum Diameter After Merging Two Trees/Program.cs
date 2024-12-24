namespace Find_Minimum_Diameter_After_Merging_Two_Trees
{
    /*There exist two undirected trees with n and m nodes, numbered from 0 to n - 1 and from 0 to m - 1, respectively. 
    You are given two 2D integer arrays edges1 and edges2 of lengths n - 1 and m - 1, respectively, 
     where edges1[i] = [ai, bi] indicates that there is an edge between nodes ai and bi 
    in the first tree and edges2[i] = [ui, vi] indicates that there is an edge between nodes ui and vi in the second tree.
    You must connect one node from the first tree with another node from the second tree with an edge.
    Return the minimum possible diameter of the resulting tree.
    The diameter of a tree is the length of the longest path between any two nodes in the tree.
    
    Constraints:
    1 <= n, m <= 10^5
    edges1.length == n - 1
    edges2.length == m - 1
    edges1[i].length == edges2[i].length == 2
    edges1[i] = [ai, bi]
    0 <= ai, bi < n
    edges2[i] = [ui, vi]
    0 <= ui, vi < m
    The input is generated such that edges1 and edges2 represent valid trees.
     */
    
    public class Solution
    {
        public static int GetDiameter(int[][] edges)
        {
            if(edges.Length == 0) return 0;
            int n = edges.Length + 1;
            var map = new List<int>[n];
            for (int i = 0; i < n; i++) map[i] = [];

            foreach (var edge in edges)
            {
                map[edge[0]].Add(edge[1]);
                map[edge[1]].Add(edge[0]);
            }

            int res = 0;

            int Dfs(int node, int parent)
            {
                int maxDepth = 1;
                foreach (var neighbor in map[node])
                {
                    if (neighbor == parent) continue;
                    int depth = Dfs(neighbor, node);
                    res = Math.Max(res, maxDepth + depth);
                    maxDepth = Math.Max(maxDepth, 1 + depth);
                }
                return maxDepth;
            }

            Dfs(0, -1);

            return res;
        }

        public static int Max(int x, int y, int z)
        {
            return Math.Max(x, Math.Max(y, z));
        }

        public static int MinDiameterAfterMerging(int[][] edges1, int[][] edges2)
        {
            int d1 = GetDiameter(edges1);
            int d2 = GetDiameter(edges2);

            return Max(d1 - 1, d2 - 1, (int)Math.Floor((double)d1 / 2) + (int)Math.Floor((double)d2 / 2) + 1);
        }

        public static bool ValidateInput(int[][] edges1, int[][] edges2, int n, int m)
        {
            int max_length = 100000;
            if (n < 1 || n > max_length || m < 1 || m > max_length)
            {
                return false;
            }

            var nodesSet1 = new HashSet<int>();
            foreach (var edge in edges1)
            {
                if (edge[0] < 0 || edge[0] >= n || edge[1] < 0 || edge[1] >= n)
                {
                    return false;
                }
                nodesSet1.Add(edge[0]);
                nodesSet1.Add(edge[1]);
            }
            if (n == 1) nodesSet1.Add(0);

            var nodesSet2 = new HashSet<int>();
            foreach (var edge in edges2)
            {
                if (edge[0] < 0 || edge[0] >= m || edge[1] < 0 || edge[1] >= m)
                {
                    return false;
                }
                nodesSet2.Add(edge[0]);
                nodesSet2.Add(edge[1]);
            }
            if(m == 1) nodesSet2.Add(0);

            return nodesSet1.Count == n && nodesSet2.Count == m;
        }

        public static void Main()
        {
            Console.Write("Enter the number of nodes in the first tree (n): ");
            int n = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine($"Enter the {n - 1} edges for the first tree in the format 'a b':");
            var edges1List = new List<int[]>();
            for (int i = 0; i < n - 1; i++)
            {
                var edge = (Console.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
                edges1List.Add(edge);
            }

            Console.Write("Enter the number of nodes in the second tree (m): ");
            int m = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine($"Enter the {m - 1} edges for the second tree in the format 'u v':");
            var edges2List = new List<int[]>();
            for (int i = 0; i < m - 1; i++)
            {
                var edge = (Console.ReadLine() ?? "").Split().Select(int.Parse).ToArray();
                edges2List.Add(edge);
            }

            int[][] edges1 = [.. edges1List];
            int[][] edges2 = [.. edges2List];

            if (ValidateInput(edges1, edges2, n, m))
            {
                int result = MinDiameterAfterMerging(edges1, edges2);
                Console.WriteLine($"Minimum possible diameter after merging the trees: {result}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please ensure the trees meet the constraints.");
                Console.ReadKey();
            }
        }
    }

}
