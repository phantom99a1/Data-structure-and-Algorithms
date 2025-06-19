namespace Partition_Array_Such_That_Maximum_Difference_Is_K
{
    public class Solution
    {
        public int PartitionArray(int[] nums, int k)
        {
            Array.Sort(nums);
            int count = 1;
            int start = nums[0];

            foreach (int num in nums)
            {
                if (num - start > k)
                {
                    count++;
                    start = num;
                }
            }

            return count;
        }
    }
}
