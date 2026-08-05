namespace Remove_Methods_From_Project
{
    public class Solution
    {
        public IList<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            List<int>[] edges = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                edges[i] = new List<int>();
            }
            int[] inDegree = new int[n];

            foreach (var inv in invocations)
            {
                edges[inv[0]].Add(inv[1]);
                inDegree[inv[1]]++;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(k);
            bool[] suspicious = new bool[n];
            suspicious[k] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in edges[u])
                {
                    inDegree[v]--;

                    if (!suspicious[v])
                    {
                        queue.Enqueue(v);
                        suspicious[v] = true;
                    }
                }
            }

            bool canRemoveAll = true;
            List<int> remaining = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (suspicious[i] && inDegree[i] > 0)
                {
                    canRemoveAll = false;
                    break;
                }
                else if (!suspicious[i])
                {
                    remaining.Add(i);
                }
            }

            if (!canRemoveAll)
            {
                List<int> allNodes = new List<int>(n);
                for (int i = 0; i < n; i++)
                {
                    allNodes.Add(i);
                }
                return allNodes;
            }

            return remaining;
        }
    }
}
