namespace Maximum_Number_of_Items_From_Sale_I
{
    public class Solution
    {
        public int MaximumSaleItems(int[][] items, int budget)
        {
            int n = items.Length;
            int[] bonus = new int[n];
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j && items[j][0] % items[i][0] == 0)
                    {
                        cnt++;
                    }
                }
                bonus[i] = cnt;
            }

            int[] dp = new int[budget + 1];
            for (int i = 0; i < n; i++)
            {
                int cost = items[i][1];
                int freeCopies = bonus[i];
                if (cost <= budget)
                {
                    for (int b = budget; b >= cost; b--)
                    {
                        dp[b] = Math.Max(dp[b], dp[b - cost] + 1 + freeCopies);
                    }
                    for (int b = cost; b <= budget; b++)
                    {
                        dp[b] = Math.Max(dp[b], dp[b - cost] + 1);
                    }
                }
            }

            int ans = 0;
            foreach (int val in dp)
            {
                if (val > ans)
                {
                    ans = val;
                }
            }
            return ans;
        }
    }
}
