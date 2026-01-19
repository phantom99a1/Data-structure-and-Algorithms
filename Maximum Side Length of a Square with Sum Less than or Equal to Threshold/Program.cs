namespace Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold
{
    public class Solution
    {
        public int MaxSideLength(int[][] mat, int threshold)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[,] prefix = new int[m + 1, n + 1];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    prefix[i + 1, j + 1] = mat[i][j] + prefix[i, j + 1] + prefix[i + 1, j] - prefix[i, j];
                }
            }

            int left = 0, right = Math.Min(m, n), ans = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                bool found = false;

                for (int i = mid; i <= m && !found; i++)
                {
                    for (int j = mid; j <= n && !found; j++)
                    {
                        int total = prefix[i, j] - prefix[i - mid, j] - prefix[i, j - mid] + prefix[i - mid, j - mid];
                        if (total <= threshold) found = true;
                    }
                }

                if (found)
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return ans;
        }
    }
}
