namespace Divide_Nodes_Into_the_Maximum_Number_of_Groups
{
    /*You are given a positive integer n representing the number of nodes in an undirected graph. 
     * The nodes are labeled from 1 to n.
    You are also given a 2D integer array edges, where edges[i] = [ai, bi] indicates that there is a 
    bidirectional edge between nodes ai and bi. Notice that the given graph may be disconnected.
    Divide the nodes of the graph into m groups (1-indexed) such that:
    Each node in the graph belongs to exactly one group.
    For every pair of nodes in the graph that are connected by an edge [ai, bi], if ai belongs to the group with index x, 
    and bi belongs to the group with index y, then |y - x| = 1.
    Return the maximum number of groups (i.e., maximum m) into which you can divide the nodes. 
    Return -1 if it is impossible to group the nodes with the given conditions.
    
    Constraint:
    1 <= n <= 500
    1 <= edges.length <= 10^4
    edges[i].length == 2
    1 <= ai, bi <= n
    ai != bi
    There is at most one edge between any pair of vertices.
     */
    
    public class Solution
    {
        private const int minValue = 1;
        private const int maxValue = 500;
        private const int minLength = 1;
        private const int maxLength = 10000;
        private const int minLevel = 1;
        public static int MagnificentSets(int n, int[][] edges)
        {
            // Initialize graph
            var graph = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
            {
                graph[i] = [];
            }

            // Build graph
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            // Find connected components using DFS
            var visited = new HashSet<int>();
            var components = new List<List<int>>();

            void DFS(int node, List<int> component)
            {
                if (visited.Contains(node)) return;
                visited.Add(node);
                component.Add(node);
                foreach (var neighbor in graph[node])
                {
                    DFS(neighbor, component);
                }
            }

            // Get all components
            for (int i = 1; i <= n; i++)
            {
                if (!visited.Contains(i))
                {
                    var component = new List<int>();
                    DFS(i, component);
                    components.Add(component);
                }
            }

            // BFS to find max groups for a component starting from a specific node
            int BFS(int start)
            {
                var dist = new int[n + 1];
                Array.Fill(dist, -1);
                var queue = new Queue<int>();
                queue.Enqueue(start);
                dist[start] = 0;
                int maxGroup = 1;

                // Check bipartite property and find max group
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    maxGroup = Math.Max(maxGroup, dist[node] + 1);

                    foreach (int neighbor in graph[node])
                    {
                        if (dist[neighbor] == -1)
                        {
                            dist[neighbor] = dist[node] + 1;
                            queue.Enqueue(neighbor);
                        }
                        else if (Math.Abs(dist[neighbor] - dist[node]) != 1)
                        {
                            return -1;
                        }
                    }
                }

                return maxGroup;
            }

            // Process each component
            int totalGroups = 0;

            foreach (var component in components)
            {
                int maxComponentGroups = -1;

                // Try each node as starting point
                foreach (int node in component)
                {
                    int groups = BFS(node);
                    if (groups == -1) return -1;
                    maxComponentGroups = Math.Max(maxComponentGroups, groups);
                }

                totalGroups += maxComponentGroups;
            }

            return totalGroups;
        }

        public static void Main()
        {
            int n;
            int[][]? edges;
            List<string> errors;

            do
            {
                (n, edges, errors) = GetValidInput("Enter the number of nodes and edges (format: n a1,b1|a2,b2|...): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = MagnificentSets(n, edges ?? []);
            Console.WriteLine("Maximum number of groups: " + result);
            Console.ReadKey();
        }

        public static (int, int[][]?, List<string>) GetValidInput(string prompt)
        {
            List<string> errors = [];
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(' ');
            if (parts.Length != 2)
            {
                errors.Add("Invalid input format. Expected format: n a1,b1|a2,b2|...");
                return (0, null, errors);
            }

            if (!int.TryParse(parts[0], out int n) || n < minValue || n > maxValue)
            {
                errors.Add($"The number of nodes must be between {minValue} and {maxValue}.");
                return (0, null, errors);
            }

            string[] edgeStrings = parts[1].Split('|');
            int[][] edges = new int[edgeStrings.Length][];

            if (edges.Length < minLength || edges.Length > maxLength)
            {
                errors.Add($"The number of edges must be between {minLength} and {maxLength}.");
                return (0, null, errors);
            }

            for (int i = 0; i < edgeStrings.Length; i++)
            {
                string[] nodes = edgeStrings[i].Split(',');
                if (nodes.Length != 2 || !int.TryParse(nodes[0], out int u) || !int.TryParse(nodes[1], out int v) || u < minLevel || u > n || v < minLevel || v > n || u == v)
                {
                    errors.Add($"Edge {i + 1} is invalid.");
                    continue;
                }
                edges[i] = [u, v];
            }

            return (n, edges, errors);
        }
    }
}
