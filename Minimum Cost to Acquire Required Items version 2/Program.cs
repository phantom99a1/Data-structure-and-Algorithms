namespace Minimum_Cost_to_Acquire_Required_Items_version_2
{
    public class Solution
    {
        public int ClimbStairs(int n, int[] costs)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue);

            dp[0] = 0;

            for (int i = 0; i <= n; i++)
            {
                if (dp[i] == int.MaxValue)
                    continue;

                for (int j = 1; j <= 3; j++)
                {
                    int next = i + j;

                    if (next <= n)
                    {
                        dp[next] = Math.Min(
                            dp[next],
                            dp[i] + costs[next - 1] + j * j
                        );
                    }
                }
            }

            return dp[n];
        }
    }
}
