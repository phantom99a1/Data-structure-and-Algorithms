namespace Maximum_Number_of_K_Divisible_Components_2
{
    public class Solution
    {
        private List<int>[] graph;
        private long[] values;
        private int k;
        private int result;

        public int MaxKDivisibleComponents(int n, int[][] edges, int[] vals, int k)
        {
            this.k = k;
            this.values = vals.Select(v => (long)v).ToArray();
            this.graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            result = 0;
            Dfs(0, -1);
            return result;
        }

        private long Dfs(int node, int parent)
        {
            long sum = values[node];
            foreach (var nei in graph[node])
            {
                if (nei == parent) continue;
                sum += Dfs(nei, node);
            }

            if (sum % k == 0)
            {
                result++;
                return 0; // reset sum since this component is valid
            }
            return sum;
        }
    }
}
