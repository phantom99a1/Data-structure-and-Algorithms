namespace Distinct_Subsequences
{
    public class Solution
    {
        public int NumDistinct(string s, string t)
        {
            int n = s.Length, m = t.Length;
            int[,] dp = new int[n + 1, m + 1];

            // Base case: empty t
            for (int i = 0; i <= n; i++) dp[i, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] += dp[i - 1, j - 1];
                    }
                }
            }
            return dp[n, m];
        }
    }
}
