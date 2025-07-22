namespace Maximum_Erasure_Value
{
    internal class Program
    {
        public int MaximumUniqueSubarray(int[] nums)
        {
            var seen = new HashSet<int>();
            int left = 0, sum = 0, maxSum = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                while (seen.Contains(nums[right]))
                {
                    seen.Remove(nums[left]);
                    sum -= nums[left];
                    left++;
                }
                seen.Add(nums[right]);
                sum += nums[right];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }
    }
}
