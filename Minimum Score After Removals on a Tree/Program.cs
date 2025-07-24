namespace Minimum_Score_After_Removals_on_a_Tree
{
    public class Solution
    {
        private List<int>[] tree;
        private int[] xor;
        private int[] parent;
        public int MinimumScore(int[] nums, int[][] edges)
        {
            int n = nums.Length;

            tree = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                tree[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int a = edge[0], b = edge[1];
                tree[a].Add(b);
                tree[b].Add(a);
            }

            xor = new int[n];
            parent = new int[n];
            Array.Fill(parent, -1);

            DFS(0, -1, nums);

            int totalXor = xor[0];
            int minScore = int.MaxValue;

            for (int u = 1; u < n; u++)
            {
                for (int v = u + 1; v < n; v++)
                {
                    int a = xor[u], b = xor[v], c;

                    if (IsAncestor(u, v))
                    {
                        c = totalXor ^ a;
                        a ^= b;
                    }
                    else if (IsAncestor(v, u))
                    {
                        c = totalXor ^ b;
                        b ^= a;
                    }
                    else
                    {
                        c = totalXor ^ a ^ b;
                    }

                    int max = Math.Max(a, Math.Max(b, c));
                    int min = Math.Min(a, Math.Min(b, c));
                    minScore = Math.Min(minScore, max - min);
                }
            }

            return minScore;
        }
        private int DFS(int node, int par, int[] nums)
        {
            xor[node] = nums[node];
            parent[node] = par;

            foreach (var nei in tree[node])
            {
                if (nei != par)
                {
                    xor[node] ^= DFS(nei, node, nums);
                }
            }

            return xor[node];
        }
        private bool IsAncestor(int u, int v)
        {
            while (v != -1)
            {
                if (v == u) return true;
                v = parent[v];
            }
            return false;
        }
    }
}
