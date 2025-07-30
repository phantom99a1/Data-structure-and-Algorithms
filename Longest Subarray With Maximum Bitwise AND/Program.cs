namespace Longest_Subarray_With_Maximum_Bitwise_AND
{
    public class Solution
    {
        public int LongestSubarray(int[] nums)
        {
            int maxVal = nums.Max();
            int maxLen = 0, currentLen = 0;

            foreach (int num in nums)
            {
                if (num == maxVal)
                {
                    currentLen++;
                    maxLen = Math.Max(maxLen, currentLen);
                }
                else
                {
                    currentLen = 0;
                }
            }

            return maxLen;
        }
    }
}
