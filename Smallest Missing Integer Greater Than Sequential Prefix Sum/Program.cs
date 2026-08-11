namespace Smallest_Missing_Integer_Greater_Than_Sequential_Prefix_Sum
{
    public class Solution
    {
        public int MissingInteger(int[] nums)
        {
            int n = nums.Length;
            HashSet<int> numSet = new HashSet<int>(nums);
            int prefixLen = 1;

            for (int i = 1; i < n; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    prefixLen += 1;
                }
                else
                {
                    break;
                }
            }

            int total = (nums[prefixLen - 1] + nums[0]) * prefixLen / 2;
            while (numSet.Contains(total))
            {
                total += 1;
            }

            return total;
        }
    }
}
