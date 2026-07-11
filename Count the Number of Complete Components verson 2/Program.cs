namespace Count_the_Number_of_Complete_Components_verson_2
{
    public class Solution
    {
        public int CountCompleteComponents(int n, int[][] edges)
        {
            var graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int completed = 0;
            bool[] visited = new bool[n];

            for (int vertex = 0; vertex < n; vertex++)
            {
                List<int> result = new List<int>(2) { 0, 0 };
                if (!visited[vertex])
                {
                    Dfs(vertex, graph, result, visited);
                    // Do not divide by 2 to n*(n-1)  because the edges will be counted twice in dfs like in and out
                    if (result[0] * (result[0] - 1) == result[1])
                    {
                        completed++;
                    }
                }
            }
            return completed;
        }

        public void Dfs(int curr, List<List<int>> graph, List<int> result, bool[] visited)
        {
            visited[curr] = true;
            result[0]++;
            result[1] += graph[curr].Count;

            foreach (int node in graph[curr])
            {
                if (!visited[node])
                {
                    Dfs(node, graph, result, visited);
                }
            }
        }
    }
}
