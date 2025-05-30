namespace Find_Closest_Node_to_Given_Two_Nodes
{
    public class Solution
    {
        public int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            int[] bfs(int start)
            {
                int n = edges.Length;
                int[] dist = new int[n];
                Array.Fill(dist, int.MaxValue);
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                dist[start] = 0;
                int step = 0;

                while (queue.Count > 0)
                {
                    int size = queue.Count;
                    for (int i = 0; i < size; i++)
                    {
                        int node = queue.Dequeue();
                        int neighbor = edges[node];
                        if (neighbor != -1 && dist[neighbor] == int.MaxValue)
                        {
                            dist[neighbor] = step + 1;
                            queue.Enqueue(neighbor);
                        }
                    }
                    step++;
                }
                return dist;
            }

            int[] dist1 = bfs(node1);
            int[] dist2 = bfs(node2);
            int minDist = int.MaxValue, result = -1;

            for (int i = 0; i < edges.Length; i++)
            {
                int maxDist = Math.Max(dist1[i], dist2[i]);
                if (maxDist < minDist)
                {
                    minDist = maxDist;
                    result = i;
                }
            }

            return result;
        }
    }
}
