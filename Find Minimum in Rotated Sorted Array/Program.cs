namespace Find_Minimum_in_Rotated_Sorted_Array
{
    public class Solution
    {
        public int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] < nums[right])
                    return nums[left];

                int mid = left + (right - left) / 2;

                if (nums[right] > nums[mid]) right = mid;
                else left = mid + 1;
            }

            return nums[left];
        }
    }
}
