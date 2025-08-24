namespace Longest_Subarray_of_1_s_After_Deleting_One_Element
{
    public class Solution
    {
        public int LongestSubarray(int[] nums)
        {
            int left = 0, right = 0, zeroCount = 0, maxLen = 0;

            while (right < nums.Length)
            {
                if (nums[right] == 0) zeroCount++;

                while (zeroCount > 1)
                {
                    if (nums[left] == 0) zeroCount--;
                    left++;
                }

                maxLen = Math.Max(maxLen, right - left);
                right++;
            }

            return maxLen;
        }
    }
}
