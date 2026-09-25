namespace Minimum_Operations_to_Reduce_X_to_Zero
{
    public class Solution
    {
        public int MinOperations(int[] nums, int x)
        {
            int target = -x, n = nums.Length;
            foreach (int num in nums) target += num;

            if (target == 0) return n;

            int maxLen = 0, curSum = 0, left = 0;

            for (int right = 0; right < n; ++right)
            {
                curSum += nums[right];
                while (left <= right && curSum > target)
                {
                    curSum -= nums[left];
                    left++;
                }
                if (curSum == target)
                {
                    maxLen = Math.Max(maxLen, right - left + 1);
                }
            }

            return maxLen != 0 ? n - maxLen : -1;
        }
    }
}
