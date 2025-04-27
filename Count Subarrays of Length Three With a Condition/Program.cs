namespace Count_Subarrays_of_Length_Three_With_a_Condition
{
    public class Solution
    {
        public int CountSubarrays(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if ((nums[i - 1] + nums[i + 1]) * 2 == nums[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
