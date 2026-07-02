namespace Find_the_Maximum_Number_of_Elements_in_Subset
{
    public class Solution
    {
        public int MaximumLength(int[] nums)
        {
            var cnt = new Dictionary<long, int>();

            foreach (int num in nums)
            {
                cnt.TryGetValue(num, out int c);
                cnt[num] = c + 1;
            }

            // ans is at least the number of occurrences of 1, rounded down to an
            // odd number
            cnt.TryGetValue(1, out int oneCnt);
            int ans = (oneCnt & 1) == 1 ? oneCnt : oneCnt - 1;

            cnt.Remove(1);

            foreach (long num in cnt.Keys)
            {
                int res = 0;
                long x = num;

                while (cnt.TryGetValue(x, out int c) && c > 1)
                {
                    res += 2;
                    x *= x;
                }

                ans = Math.Max(ans, res + (cnt.ContainsKey(x) ? 1 : -1));
            }

            return ans;
        }
    }
}
