namespace Largest_Perimeter_Triangle
{
    public class Solution
    {
        public int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);
            Array.Reverse(nums); // Sort in descending order

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] < nums[i + 1] + nums[i + 2])
                {
                    return nums[i] + nums[i + 1] + nums[i + 2];
                }
            }

            return 0;
        }
    }
}
