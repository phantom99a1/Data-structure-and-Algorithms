namespace Count_Partitions_with_Even_Sum_Difference
{
    public class Solution
    {
        public int CountPartitions(int[] nums)
        {
            int n = nums.Length;
            int total = 0;

            foreach (int num in nums)
            {
                total += num;
            }

            // If total sum is even, all (n-1) partitions are valid
            if (total % 2 == 0)
            {
                return n - 1;
            }

            // Otherwise, no partition is valid
            return 0;
        }
    }
}
