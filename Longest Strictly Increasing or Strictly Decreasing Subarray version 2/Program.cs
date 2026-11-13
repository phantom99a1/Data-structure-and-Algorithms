namespace Longest_Strictly_Increasing_or_Strictly_Decreasing_Subarray_version_2
{
    public class Solution
    {
        public int LongestMonotonicSubarray(int[] nums)
        {
            int inc = 1;
            int dec = 1;
            int ans = 1;

            for (int i = 0; i < nums.Length - 1; i++)
            {

                if (nums[i + 1] > nums[i])
                {
                    inc++;
                    dec = 1;
                }
                else if (nums[i + 1] < nums[i])
                {
                    dec++;
                    inc = 1;
                }
                else
                {
                    inc = 1;
                    dec = 1;
                }

                ans = Math.Max(ans, Math.Max(inc, dec));
            }

            return ans;
        }
    }
}
