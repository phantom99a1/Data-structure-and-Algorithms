namespace Maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array
{
    public class Solution
    {
        public int MaxAdjacentDistance(int[] nums)
        {
            int maxDiff = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int nextIndex = (i + 1) % nums.Length;
                maxDiff = Math.Max(maxDiff, Math.Abs(nums[i] - nums[nextIndex]));
            }
            return maxDiff;
        }
    }
}
