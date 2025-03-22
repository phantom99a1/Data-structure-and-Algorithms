namespace Count_the_Number_of_Complete_Components
{
    /*You are given an integer n. There is an undirected graph with n vertices, numbered from 0 to n - 1. You are given a 2D integer
    array edges where edges[i] = [ai, bi] denotes that there exists an undirected edge connecting vertices ai and bi.
    Return the number of complete connected components of the graph.
    A connected component is a subgraph of a graph in which there exists a path between any two vertices, and no vertex of the 
    subgraph shares an edge with a vertex outside of the subgraph.
    A connected component is said to be complete if there exists an edge between every pair of its vertices.
    
    Constraint:
    1 <= n <= 50
    0 <= edges.length <= n * (n - 1) / 2
    edges[i].length == 2
    0 <= ai, bi <= n - 1
    ai != bi
    There are no repeated edges.
     */
    class Program
    {
        static int CountCompleteComponents(int n, List<Tuple<int, int>> edges)
        {
            List<List<int>> adjList = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                adjList[edge.Item1].Add(edge.Item2);
                adjList[edge.Item2].Add(edge.Item1);
            }

            bool[] visited = new bool[n];
            int completeComponents = 0;

            void DFS(int node, List<int> component)
            {
                visited[node] = true;
                component.Add(node);
                foreach (int neighbor in adjList[node])
                {
                    if (!visited[neighbor]) DFS(neighbor, component);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    List<int> component = new List<int>();
                    DFS(i, component);

                    bool isComplete = true;
                    foreach (int node in component)
                    {
                        if (adjList[node].Count != component.Count - 1)
                        {
                            isComplete = false;
                            break;
                        }
                    }
                    if (isComplete) completeComponents++;
                }
            }
            return completeComponents;
        }

        static List<string> ValidateInput(int n, List<Tuple<int, int>> edges)
        {
            List<string> errors = new List<string>();
            if (n < 1 || n > 50)
            {
                errors.Add("The number of nodes 'n' must be between 1 and 50.");
            }
            if (edges.Count > n * (n - 1) / 2)
            {
                errors.Add($"The number of edges exceeds the maximum allowable for {n} nodes.");
            }
            foreach (var edge in edges)
            {
                if (edge.Item1 < 0 || edge.Item1 >= n || edge.Item2 < 0 || edge.Item2 >= n)
                {
                    errors.Add($"Edge nodes must be between 0 and {n - 1}.");
                }
                if (edge.Item1 == edge.Item2)
                {
                    errors.Add($"Edge {edge} cannot connect a node to itself.");
                }
            }
            return errors;
        }

        static void Main()
        {
            int n = 6;
            List<Tuple<int, int>> edges = [
            Tuple.Create(0, 1),
            Tuple.Create(1, 2),
            Tuple.Create(2, 0),
            Tuple.Create(3, 4),
            Tuple.Create(4, 5),
            Tuple.Create(5, 3)
        ];

            List<string> errors = ValidateInput(n, edges);
            if (errors.Count > 0)
            {
                Console.WriteLine("Input errors:");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                int result = CountCompleteComponents(n, edges);
                Console.WriteLine("Number of complete components: " + result);
            }
        }
    }
}
