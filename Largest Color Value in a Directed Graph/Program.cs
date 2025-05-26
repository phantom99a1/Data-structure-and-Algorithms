namespace Largest_Color_Value_in_a_Directed_Graph
{
    /*There is a directed graph of n colored nodes and m edges. The nodes are numbered from 0 to n - 1.
    You are given a string colors where colors[i] is a lowercase English letter representing the color of the ith node in this
    graph (0-indexed). You are also given a 2D array edges where edges[j] = [aj, bj] indicates that there is a directed edge 
    from node aj to node bj. A valid path in the graph is a sequence of nodes x1 -> x2 -> x3 -> ... -> xk such that there is a 
    directed edge from xi to xi+1 for every 1 <= i < k. The color value of the path is the number of nodes that are colored the 
    most frequently occurring color along that path. 
    Return the largest color value of any valid path in the given graph, or -1 if the graph contains a cycle.
    
     Constraint:
    n == colors.length
    m == edges.length
    1 <= n <= 10^5
    0 <= m <= 10^5
    colors consists of lowercase English letters.
    0 <= aj, bj < n
     */
    public class Solution
    {
        public int LargestPathValue(string colors, int[][] edges)
        {
            int n = colors.Length;
            List<int>[] graph = new List<int>[n];
            int[] inDegrees = new int[n];
            int[,] dp = new int[n, 26];

            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                inDegrees[edge[1]]++;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (inDegrees[i] == 0) queue.Enqueue(i);
            }

            int processed = 0, maxColorValue = 0;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                processed++;
                maxColorValue = Math.Max(maxColorValue, ++dp[node, colors[node] - 'a']);

                foreach (int neighbor in graph[node])
                {
                    for (int i = 0; i < 26; i++)
                    {
                        dp[neighbor, i] = Math.Max(dp[neighbor, i], dp[node, i]);
                    }
                    if (--inDegrees[neighbor] == 0) queue.Enqueue(neighbor);
                }
            }

            return processed == n ? maxColorValue : -1;
        }
    }
}
