namespace Maximum_Number_of_Distinct_Elements_After_Operations
{
    public class Solution
    {
        public int MaxDistinctElements(int[] nums, int k)
        {
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            int count = 0;
            int prev = int.MinValue >> 1;
            foreach (int a in nums)
            {
                int low = a - k;
                int high = a + k;
                int x = prev + 1;
                if (x < low) x = low;
                if (x <= high)
                {
                    count++;
                    prev = x;
                }
            }
            return count;
        }
    }
}
