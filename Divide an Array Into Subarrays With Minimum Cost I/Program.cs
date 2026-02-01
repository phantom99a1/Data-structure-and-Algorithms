namespace Divide_an_Array_Into_Subarrays_With_Minimum_Cost_I
{
    public class Solution
    {
        public int MinimumCost(int[] nums)
        {
            var sum = nums[0];
            var min1 = nums[1];
            var min2 = nums[2];

            for (var i = 2; i < nums.Length; i++)
            {
                if (nums[i] < min1)
                {
                    min2 = min1;
                    min1 = nums[i];
                }
                else if (nums[i] < min2)
                {
                    min2 = nums[i];
                }
            }

            return sum + min1 + min2;
        }
    }
}
