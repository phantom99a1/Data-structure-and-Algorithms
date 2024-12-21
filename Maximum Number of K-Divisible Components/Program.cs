namespace Maximum_Number_of_K_Divisible_Components
{
    /*There is an undirected tree with n nodes labeled from 0 to n - 1. 
     * You are given the integer n and a 2D integer array edges of length n - 1, 
     * where edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi in the tree.

    You are also given a 0-indexed integer array values of length n, 
    where values[i] is the value associated with the ith node, and an integer k.

    A valid split of the tree is obtained by removing any set of edges, possibly empty, 
    from the tree such that the resulting components all have values that are divisible by k, 
    where the value of a connected component is the sum of the values of its nodes.

    Return the maximum number of components in any valid split.
    
    Constraints:

    1 <= n <= 3 * 10^4
    edges.length == n - 1
    edges[i].length == 2
    0 <= ai, bi < n
    values.length == n
    0 <= values[i] <= 10^9
    1 <= k <= 10^9
    Sum of values is divisible by k.
    The input is generated such that edges represents a valid tree.


    Explanation:
    The maxKDivisibleComponents function builds the graph from the given edges and then uses DFS to traverse the tree.
    The dfs function calculates the sum of each subtree and checks if it is divisible by k.
    The main function handles input from the keyboard, validates it, and processes the tree.
     */

    public class Solution
    {
        public static int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int componentCount = 0;

            long DFS(int node, int parent)
            {
                long subtreeSum = values[node];
                foreach (int neighbor in graph[node])
                {
                    if (neighbor != parent)
                    {
                        subtreeSum += DFS(neighbor, node);
                    }
                }

                if (subtreeSum % k == 0)
                {
                    componentCount++;
                    return 0;
                }

                return subtreeSum;
            }

            DFS(0, -1);
            return componentCount; // Subtract 1 because the root is considered a component but should not be counted as a separate component.
        }

        public static void Main()
        {
            int n;
            int k;
            int[] values;
            int[][] edges;

            int max_value = 1000000000;
            int max_length = 30000;
            // Read and validate input
            while (true)
            {
                try
                {
                    Console.Write("Enter the number of nodes (n): ");
                    n = int.Parse(Console.ReadLine() ?? "");
                    if (n < 1 || n > max_length)
                    {
                        Console.WriteLine($"Invalid input. n must be between 1 and {max_length}.");
                        continue;
                    }

                    Console.Write("Enter the value of k: ");
                    k = int.Parse(Console.ReadLine() ?? "");
                    if (k < 1 || k > max_value)
                    {
                        Console.WriteLine($"Invalid input. K must be between 1 and {max_value}.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Enter the values of the nodes as space-separated integers: ");
                    values = Array.ConvertAll((Console.ReadLine() ?? "").Split(' '), int.Parse);
                    if (values.Length != n || values.Any(v => v < 0 || v > max_value))
                    {
                        Console.WriteLine($"Invalid input. Ensure the number of values is equal to n and each value is between 0 and {max_value}.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Enter the edges as space-separated pairs (e.g., '0 1 1 2'): ");
                    edges = ParseEdges(Console.ReadLine() ?? "", n);
                    if (edges.Length != n - 1 || edges.Any(e => e.Length != 2 || e[0] < 0 || e[0] >= n || e[1] < 0 || e[1] >= n))
                    {
                        Console.WriteLine("Invalid input. Ensure there are n-1 edges and each edge is a valid pair of node indices.");
                        Console.ReadKey();
                        continue;
                    }

                    long totalSum = values.Sum(v => (long)v);
                    if (totalSum % k != 0)
                    {
                        Console.WriteLine($"Invalid input. The sum of values must be divisible by {k}.");
                        Console.ReadKey();
                        continue;
                    }

                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter valid integers.");
                    Console.ReadKey();
                }
            }
            
            // Calculate the result using the method
            int result = MaxKDivisibleComponents(n, edges, values, k);
            Console.WriteLine("Maximum Number of K-Divisible Components: " + result);
            Console.ReadKey();
        }

        private static int[][] ParseEdges(string input, int n)
        {
            string[] parts = input.Split(' ');
            int[][] edges = new int[n - 1][];
            for (int i = 0; i < parts.Length; i += 2)
            {
                edges[i / 2] = [int.Parse(parts[i]), int.Parse(parts[i + 1])];
            }
            return edges;
        }
    }
}
