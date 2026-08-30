namespace Removing_Minimum_and_Maximum_From_Array
{
    public class Solution
    {
        public int MinimumDeletions(int[] nums)
        {
            int n = nums.Length;

            // Find the indices of the minimum and maximum values
            int minidx = 0, maxidx = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < nums[minidx])
                {
                    minidx = i;
                }
                if (nums[i] > nums[maxidx])
                {
                    maxidx = i;
                }
            }

            int l = Math.Min(
                minidx, maxidx);  // The smaller value in the most valuable index
            int r = Math.Max(
                minidx, maxidx);  // The bigger value in the most valuable index

            // Calculate the minimum number of deletions in three cases
            return Math.Min(Math.Min(r + 1, n - l), l + 1 + n - r);
        }
    }
}
