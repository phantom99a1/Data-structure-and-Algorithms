namespace Make_Array_Elements_Equal_to_Zero
{
    public class Solution
    {
        public int CountValidSelections(int[] nums)
        {
            int n = nums.Length;
            int ans = 0;
            int[] prefix = new int[n];
            int[] suffix = new int[n];

            for (int i = 1; i < n; ++i)
                prefix[i] = prefix[i - 1] + nums[i - 1];

            for (int i = n - 2; i >= 0; --i)
                suffix[i] = suffix[i + 1] + nums[i + 1];

            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > 0) continue;
                if (prefix[i] == suffix[i]) ans += 2;
                else if (Math.Abs(prefix[i] - suffix[i]) == 1) ans += 1;
            }

            return ans;
        }
    }
}
