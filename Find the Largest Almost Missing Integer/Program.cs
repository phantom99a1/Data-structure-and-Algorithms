namespace Find_the_Largest_Almost_Missing_Integer
{
    public class Solution
    {
        public int LargestInteger(int[] nums, int k) => nums.Length == k
            ? nums.Max()
            : k == 1
                ? nums.GroupBy(m => m).
                    Where(m => m.Count() <= 1).
                    Select(n => n.Key).
                    DefaultIfEmpty(-1).
                    Max()
                : Math.Max(
                    nums.Count(m => m == nums[0]) <= 1 ? nums[0] : -1,
                    nums.Count(m => m == nums[^1]) <= 1 ? nums[^1] : -1
                    );
    }
}
