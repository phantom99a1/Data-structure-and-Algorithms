namespace Increment_Submatrices_by_One
{
    public class Solution
    {
        public int[][] RangeAddQueries(int n, int[][] queries)
        {
            int[,] diff = new int[n + 1, n + 1];

            foreach (var q in queries)
            {
                int r1 = q[0], c1 = q[1], r2 = q[2], c2 = q[3];
                diff[r1, c1]++;
                if (c2 + 1 < n) diff[r1, c2 + 1]--;
                if (r2 + 1 < n) diff[r2 + 1, c1]--;
                if (r2 + 1 < n && c2 + 1 < n) diff[r2 + 1, c2 + 1]++;
            }

            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    res[i][j] = diff[i, j];
                    if (i > 0) res[i][j] += res[i - 1][j];
                    if (j > 0) res[i][j] += res[i][j - 1];
                    if (i > 0 && j > 0) res[i][j] -= res[i - 1][j - 1];
                }
            }

            return res;
        }
    }
}
