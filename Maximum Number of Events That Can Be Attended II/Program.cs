namespace Maximum_Number_of_Events_That_Can_Be_Attended_II
{
    public class Solution
    {
        public int MaxValue(int[][] events, int k)
        {
            Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));
            int n = events.Length;
            int[,] dp = new int[n + 1, k + 1];

            int Search(int x, int hi)
            {
                int l = 0, r = hi;
                while (l < r)
                {
                    int mid = (l + r) / 2;
                    if (events[mid][1] >= x) r = mid;
                    else l = mid + 1;
                }
                return l;
            }

            for (int i = 1; i <= n; ++i)
            {
                int start = events[i - 1][0], value = events[i - 1][2];
                int p = Search(start, i - 1);
                for (int j = 1; j <= k; ++j)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[p, j - 1] + value);
                }
            }

            return dp[n, k];
        }
    }
}
