namespace Minimum_Score_of_a_Path_Between_Two_Cities
{
    public class Solution
    {
        public int MinScore(int n, int[][] roads)
        {
            var graph = new Dictionary<int, List<int>>();

            foreach (int[] road in roads)
            {
                graph.TryAdd(road[0], new List<int>());
                graph[road[0]].Add(road[1]);

                graph.TryAdd(road[1], new List<int>());
                graph[road[1]].Add(road[0]);
            }

            bool[] visited = new bool[n + 1];
            DFS(1, graph, visited);

            int min = int.MaxValue;

            foreach (int[] road in roads)
            {
                if (visited[road[0]] || visited[road[1]])
                {
                    min = Math.Min(min, road[2]);
                }
            }

            return min;
        }

        private void DFS(int curr, Dictionary<int, List<int>> graph, bool[] visited)
        {
            if (visited[curr]) return;

            visited[curr] = true;

            if (graph.ContainsKey(curr))
            {
                foreach (int next in graph[curr])
                {
                    DFS(next, graph, visited);
                }
            }
        }
    }
}
