namespace Minimum_Removals_to_Balance_Array
{
    public class Solution
    {
        public int MinRemoval(int[] nums, int k)
        {
            Array.Sort(nums);
            int i = 0;
            int maxLen = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                while ((long)nums[j] > (long)nums[i] * k)
                {
                    i++;
                }
                maxLen = Math.Max(maxLen, j - i + 1);
            }

            return nums.Length - maxLen;
        }
    }
}
