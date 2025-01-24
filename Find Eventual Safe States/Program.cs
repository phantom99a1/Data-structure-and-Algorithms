namespace Find_Eventual_Safe_States
{
    /*There is a directed graph of n nodes with each node labeled from 0 to n - 1. 
    The graph is represented by a 0-indexed 2D integer array graph where graph[i] is an integer array of nodes 
    adjacent to node i, meaning there is an edge from node i to each node in graph[i].
    A node is a terminal node if there are no outgoing edges. A node is a safe node if every possible 
    path starting from that node leads to a terminal node (or another safe node).
    Return an array containing all the safe nodes of the graph. The answer should be sorted in ascending order.
    
    Constraint:
    n == graph.length
    1 <= n <= 10^4
    0 <= graph[i].length <= n
    0 <= graph[i][j] <= n - 1
    graph[i] is sorted in a strictly increasing order.
    The graph may contain self-loops.
    The number of edges in the graph will be in the range [1, 4 * 10^4]
     */
    
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 10000;
        private const int minEgdes = 1;
        private const int maxEdges = 40000;
        private const int minValue = 0;
        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            int[] color = new int[n]; // 0: white, 1: gray, 2: black

            bool Dfs(int node)
            {
                if (color[node] > 0) return color[node] == 2;
                color[node] = 1; // Mark node as visiting (gray)
                foreach (var neighbor in graph[node])
                {
                    if (color[neighbor] == 2) continue;
                    if (color[neighbor] == 1 || !Dfs(neighbor)) return false;
                }
                color[node] = 2; // Mark node as safe (black)
                return true;
            }

            var result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (Dfs(i)) result.Add(i);
            }
            return result;
        }

        public static void Main()
        {
            int[][] graph;
            List<string> errors;

            do
            {
                (graph, errors) = GetValidInput("Enter the graph (rows separated by ';', cells by ','): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = EventualSafeNodes(graph);
            Console.WriteLine("Eventual Safe States: [" + string.Join(",", result) + "]");
            Console.ReadKey();
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split(';');

            int[][] graph;
            try
            {
                graph = rows.Select(row => string.IsNullOrWhiteSpace(row) ?
                [] : row.Split(',').Select(int.Parse).ToArray()).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in input.");
                return (Array.Empty<int[]>(), errors);
            }

            int n = graph.Length;
            int edgeCount = graph.Sum(row => row.Length);

            if (n < minLength || n > maxEdges)
            {
                errors.Add($"Graph length must be between {minLength} and {maxLength}.");
            }
            if (graph.Any(row => row.Length > n))
            {
                errors.Add($"Each graph[i].length must be <= {n}.");
            }
            if (graph.Any(row => row.Any(cell => cell < 0 || cell > n - 1)))
            {
                errors.Add($"Each graph[i][j] must be between {minValue} and {n-1}.");
            }
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].Length > 1)
                {
                    for (int j = 1; j < graph[i].Length; j++)
                    {
                        if (graph[i][j] <= graph[i][j - 1])
                        {
                            errors.Add("graph[i] must be sorted in strictly increasing order.");
                            break;
                        }
                    }
                }
            }
            if (edgeCount < minEgdes || edgeCount > maxEdges)
            {
                errors.Add($"The number of edges in the graph must be between {minEgdes} and {maxEdges}.");
            }

            return (graph, errors);
        }
    }
}
