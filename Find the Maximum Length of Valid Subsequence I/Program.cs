namespace Find_the_Maximum_Length_of_Valid_Subsequence_I
{
    public class Solution
    {
        public int MaximumLength(int[] nums)
        {
            int k = 2;
            int[,] dp = new int[k, k];
            int maxLen = 0;

            foreach (int x in nums)
            {
                int mod = x % k;
                for (int j = 0; j < k; j++)
                {
                    int y = (j - mod + k) % k;
                    dp[mod, y] = dp[y, mod] + 1;
                    maxLen = Math.Max(maxLen, dp[mod, y]);
                }
            }

            return maxLen;
        }
    }
}
