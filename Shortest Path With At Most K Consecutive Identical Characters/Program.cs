namespace Shortest_Path_With_At_Most_K_Consecutive_Identical_Characters
{
    public class Solution
    {
        public int ShortestPath(int n, int[][] edges, string labels, int k)
        {
            Dictionary<int, List<(int, int)>> dict = new();

            foreach (var ar in edges)
            {
                int x = ar[0];
                int y = ar[1];
                int z = ar[2];

                if (!dict.ContainsKey(x))
                {
                    dict.Add(x, new List<(int, int)>());
                }
                dict[x].Add((y, z));
            }

            var pq = new PriorityQueue<(int node, char label, int count, int wt), int>();

            pq.Enqueue((0, labels[0], 1, 0), 0);
            Dictionary<(int node, char label, int count), int> visit = new Dictionary<(int node, char label, int count), int>();
            visit[(0, labels[0], 1)] = 0;
            while (pq.Count > 0)
            {
                var temp = pq.Dequeue();

                if (temp.count > k)
                {
                    continue;
                }

                if (temp.node == n - 1)
                {
                    return temp.wt;
                }

                if (visit.TryGetValue((temp.node, temp.label, temp.count), out int best) && best < temp.wt)
                {
                    continue;
                }

                if (dict.ContainsKey(temp.node))
                {
                    foreach (var kvp in dict[temp.node])
                    {
                        int x1 = kvp.Item1;
                        int x2 = kvp.Item2;

                        int prevNodeLabelCount = temp.count;

                        int labelCount = temp.label == labels[x1] ? prevNodeLabelCount + 1 : 1;

                        if (labelCount > k)
                        {
                            continue;
                        }

                        int wt = temp.wt + x2;

                        if (!visit.TryGetValue((x1, labels[x1], labelCount), out int old) || wt < old)
                        {
                            visit[(x1, labels[x1], labelCount)] = wt;
                            pq.Enqueue((x1, labels[x1], labelCount, wt), wt);
                        }
                    }
                }
            }

            return -1;
        }
    }
}
