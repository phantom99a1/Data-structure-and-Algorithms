namespace Minimum_Moves_to_Equal_Array_Elements_II
{
    public class Solution
    {
        // f(x) = total moves needed to make every element equal to num
        private long FindSum(int[] nums, int num)
        {
            long ans = 0;
            foreach (int v in nums)
            {
                ans += Math.Abs((long)v - num);
            }
            return ans;
        }

        public int MinMoves2(int[] nums)
        {
            Array.Sort(nums);

            // lo: on the downhill side, hi: on the flat/uphill side
            int lo = nums[0] - 2, hi = nums[nums.Length - 1];

            // Binary search on the slope of the convex function f(x)
            while (hi - lo > 1)
            {
                int mid = lo + (hi - lo) / 2;
                if (FindSum(nums, mid) > FindSum(nums, mid + 1))
                {
                    lo = mid;   // still downhill -> minimum is to the right
                }
                else
                {
                    hi = mid;   // at or past the minimum -> move left
                }
            }
            return (int)Math.Min(FindSum(nums, hi), FindSum(nums, lo));
        }
    }
}
