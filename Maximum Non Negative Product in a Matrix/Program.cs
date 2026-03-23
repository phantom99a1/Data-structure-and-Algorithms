namespace Maximum_Non_Negative_Product_in_a_Matrix
{
    public class Solution
    {
        public int MaxProductPath(int[][] g)
        {
            const int MOD = 1_000_000_007;
            int m = g.Length, n = g[0].Length;

            // Span keeps DP contiguous and allocation-free
            // We only need the previous row, so O(n) space.
            Span<long> max = stackalloc long[n];
            Span<long> min = stackalloc long[n];

            max[0] = min[0] = g[0][0];

            // First row: only reachable from the left
            for (int j = 1; j < n; j++) max[j] = min[j] = max[j - 1] * g[0][j];

            for (int i = 1; i < m; i++)
            {
                // First column: only reachable from the top
                max[0] = min[0] = max[0] * g[i][0];

                for (int j = 1; j < n; j++)
                {
                    long v = g[i][j];

                    // unchecked for overflow being ok
                    // correctness depends only on sign and final modulo.
                    unchecked
                    {
                        long a = v * max[j];     // from top
                        long b = v * min[j];
                        long c = v * max[j - 1]; // from left
                        long d = v * min[j - 1];

                        // Track both max and min because negatives can flip later
                        max[j] = Math.Max(Math.Max(a, b), Math.Max(c, d));
                        min[j] = Math.Min(Math.Min(a, b), Math.Min(c, d));
                    }
                }
            }

            long res = max[n - 1];
            return res < 0 ? -1 : (int)(res % MOD);
        }
    }
}
