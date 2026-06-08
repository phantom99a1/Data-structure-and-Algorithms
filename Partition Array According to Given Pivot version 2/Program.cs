namespace Partition_Array_According_to_Given_Pivot_version_2
{
    public class Solution
    {
        public int[] PivotArray(int[] nums, int pivot)
        {
            List<int> left = new();
            List<int> same = new();
            List<int> right = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < pivot)
                {
                    left.Add(nums[i]);
                }
                else if (nums[i] > pivot)
                {
                    right.Add(nums[i]);
                }
                else
                {
                    same.Add(nums[i]);
                }
            }

            left.AddRange(same);
            left.AddRange(right);

            return [.. left];
        }
    }
}
