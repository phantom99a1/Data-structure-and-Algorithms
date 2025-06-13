namespace Minimize_the_Maximum_Difference_of_Pairs
{
    public class Solution
    {
        public int MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);

            bool CanFormPairs(int maxDiff)
            {
                int count = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - nums[i - 1] <= maxDiff)
                    {
                        count++;
                        i++; // skip the next one since it's paired
                    }
                }
                return count >= p;
            }

            int left = 0, right = nums[^1] - nums[0];
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (CanFormPairs(mid)) right = mid;
                else left = mid + 1;
            }
            return left;
        }
    }
}
