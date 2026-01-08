namespace Max_Dot_Product_of_Two_Subsequences
{
    public class Solution
    {
        public int MaxDotProduct(int[] a, int[] b)
        {
            int n = a.Length, m = b.Length;
            int NEG = (int)-1e9;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= m; j++)
                    dp[i, j] = NEG;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int take = a[i - 1] * b[j - 1] + Math.Max(0, dp[i - 1, j - 1]);
                    dp[i, j] = Math.Max(take, Math.Max(dp[i - 1, j], dp[i, j - 1]));
                }
            }
            return dp[n, m];
        }
    }



}
