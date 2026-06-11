using System.Numerics;

namespace Number_of_Ways_to_Assign_Edge_Weights_I
{
    public class Solution
    {
        public int AssignEdgeWeights(int[][] edges)
        {
            Dictionary<int, List<int>> nodes = new();
            foreach (int[] edge in edges)
            {
                if (!nodes.TryAdd(edge[0], [edge[1]]))
                {
                    nodes[edge[0]].Add(edge[1]);
                }

                if (!nodes.TryAdd(edge[1], [edge[0]]))
                {
                    nodes[edge[1]].Add(edge[0]);
                }
            }

            int maxDepth = 0;
            void DFS(int node, int depth, HashSet<int> visited)
            {
                visited.Add(node);
                foreach (int neighbor in nodes[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFS(neighbor, depth + 1, visited);
                    }
                }

                maxDepth = Math.Max(maxDepth, depth);
            }

            DFS(1, 0, new());

            return (int)(BigInteger.ModPow(2, maxDepth - 1, 1_000_000_007));
        }
    }
}
