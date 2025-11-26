namespace Paths_in_Matrix_Whose_Sum_Is_Divisible_by_K
{
    public class Solution
    {
        private const int MOD = 1000000007;
        private int[,,] dp;
        private int m, n, k;
        private int[][] grid;

        public int NumberOfPaths(int[][] grid, int k)
        {
            this.m = grid.Length;
            this.n = grid[0].Length;
            this.k = k;
            this.grid = grid;

            // dp[row, col, remainder] = number of paths
            dp = new int[m, n, k];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    for (int r = 0; r < k; r++)
                        dp[i, j, r] = -1;

            return Dfs(0, 0, grid[0][0] % k);
        }

        private int Dfs(int row, int col, int remainder)
        {
            if (row == m - 1 && col == n - 1)
            {
                return remainder == 0 ? 1 : 0;
            }

            if (dp[row, col, remainder] != -1)
            {
                return dp[row, col, remainder];
            }

            long ways = 0;

            // Move down
            if (row + 1 < m)
            {
                int newRem = (remainder + grid[row + 1][col]) % k;
                ways += Dfs(row + 1, col, newRem);
            }

            // Move right
            if (col + 1 < n)
            {
                int newRem = (remainder + grid[row][col + 1]) % k;
                ways += Dfs(row, col + 1, newRem);
            }

            dp[row, col, remainder] = (int)(ways % MOD);
            return dp[row, col, remainder];
        }
    }
}
