namespace Ones_and_Zeroes
{
    public class Solution
    {
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            foreach (string str in strs)
            {
                int zeros = str.Count(c => c == '0');
                int ones = str.Length - zeros;

                for (int i = m; i >= zeros; i--)
                {
                    for (int j = n; j >= ones; j--)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
