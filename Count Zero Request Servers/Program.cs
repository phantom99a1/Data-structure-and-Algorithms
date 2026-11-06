namespace Count_Zero_Request_Servers
{
    public class Solution
    {
        private static IEnumerable<(int id, int at, int kind)> Events(int[][] logs, int x, int[] queries)
        {
            foreach (var log in logs)
            {
                yield return (log[0], log[1], 1);
                yield return (log[0], log[1] + x, -1);
            }

            for (int i = 0; i < queries.Length; ++i)
                yield return (i, queries[i], 0);
        }

        public int[] CountServers(int n, int[][] logs, int x, int[] queries)
        {
            int[] result = new int[queries.Length];
            int[] servers = new int[n + 1];

            int total = 0;

            var events = Events(logs, x, queries)
              .OrderBy(item => item.at)
              .ThenBy(item => -item.kind);

            foreach (var evt in events)
                if (evt.kind == 0)
                    result[evt.id] = n - total;
                else
                {
                    int before = servers[evt.id];

                    servers[evt.id] += evt.kind;

                    int after = servers[evt.id];

                    if (after == 0 && before > 0)
                        total -= 1;
                    else if (before == 0 && after > 0)
                        total += 1;
                }

            return result;
        }
    }
}
