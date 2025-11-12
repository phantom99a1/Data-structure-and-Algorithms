namespace Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1
{
    public class Solution
    {
        public int MinOperations(int[] nums)
        {
            int n = nums.Length;
            int ones = nums.Count(x => x == 1);
            if (ones > 0) return n - ones;

            int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
            int minLen = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int g = nums[i];
                for (int j = i + 1; j < n; j++)
                {
                    g = GCD(g, nums[j]);
                    if (g == 1)
                    {
                        minLen = Math.Min(minLen, j - i);
                        break;
                    }
                }
            }

            return minLen == int.MaxValue ? -1 : minLen + n - 1;
        }
    }
}
