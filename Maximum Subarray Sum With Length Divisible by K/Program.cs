namespace Maximum_Subarray_Sum_With_Length_Divisible_by_K
{
    public class Solution
    {
        public long MaxSubarraySum(int[] nums, int k)
        {
            int n = nums.Length;
            long prefix = 0;
            long result = long.MinValue;

            // Dictionary to store minimum prefix sum for each modulo class
            var minPrefix = new Dictionary<int, long>();
            minPrefix[0] = 0;  // base case

            for (int i = 0; i < n; i++)
            {
                prefix += nums[i];
                int mod = (i + 1) % k;

                if (minPrefix.ContainsKey(mod))
                {
                    result = Math.Max(result, prefix - minPrefix[mod]);
                    minPrefix[mod] = Math.Min(minPrefix[mod], prefix);
                }
                else
                {
                    minPrefix[mod] = prefix;
                }
            }

            return result;
        }
    }
}
