namespace Redundant_Connection
{
    /*In this problem, a tree is an undirected graph that is connected and has no cycles

    You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added. 
    The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. 
    The graph is represented as an array edges of length n where edges[i] = [ai, bi] indicates that there is an edge 
    between nodes ai and bi in the graph.
    Return an edge that can be removed so that the resulting graph is a tree of n nodes. 
    If there are multiple answers, return the answer that occurs last in the input.
    
    Constraint:
    n == edges.length
    3 <= n <= 1000
    edges[i].length == 2
    1 <= ai < bi <= edges.length
    ai != bi
    There are no repeated edges.
    The given graph is connected.
     */
    
    public class Solution
    {
        public static int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            var uf = new UnionFind(n + 1);

            foreach (var edge in edges)
            {
                if (!uf.Union(edge[0], edge[1]))
                {
                    return edge;
                }
            }

            return [];
        }

        public static void Main()
        {
            int[][] edges;
            List<string> errors;

            do
            {
                (edges, errors) = GetValidInput("Enter the edges (format: a1,b1;a2,b2;...): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = FindRedundantConnection(edges);
            Console.WriteLine("Redundant connection: " + string.Join(",", result));
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] edgeStrings = input.Split(';');
            int[][] edges = new int[edgeStrings.Length][];

            if (edges.Length < 3 || edges.Length > 1000)
            {
                errors.Add("The number of edges must be between 3 and 1000.");
            }

            for (int i = 0; i < edges.Length; i++)
            {
                string[] nodes = edgeStrings[i].Split(',');
                if (nodes.Length != 2 || !int.TryParse(nodes[0], out int u) || !int.TryParse(nodes[1], out int v) || u < 1 || u >= edges.Length || v <= u || v > edges.Length)
                {
                    errors.Add($"Edge {i + 1} is invalid.");
                    continue;
                }
                edges[i] = [u, v];
            }

            return (edges, errors);
        }
    }

    public class UnionFind
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
                return true;
            }
            return false;
        }
    }
}
