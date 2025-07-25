namespace Maximum_Unique_Subarray_Sum_After_Deletion
{
    public class Solution
    {
        public int MaxSum(int[] nums)
        {
            int maxVal = nums.Max();
            if (maxVal <= 0) return maxVal;

            HashSet<int> seen = new HashSet<int>();
            int sum = 0;

            foreach (int num in nums)
            {
                if (num > 0 && !seen.Contains(num))
                {
                    sum += num;
                    seen.Add(num);
                }
            }

            return sum;
        }
    }
}
