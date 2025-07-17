namespace Find_the_Maximum_Length_of_Valid_Subsequence_II
{
    public class Solution
    {
        public int MaximumLength(int[] nums, int k)
        {
            int[,] dp = new int[k, k];
            int maxLen = 0;

            foreach (int num in nums)
            {
                int mod = num % k;
                for (int y = 0; y < k; ++y)
                {
                    dp[mod, y] = dp[y, mod] + 1;
                    maxLen = Math.Max(maxLen, dp[mod, y]);
                }
            }

            return maxLen;
        }
    }
}
