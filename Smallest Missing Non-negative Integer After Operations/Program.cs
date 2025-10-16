namespace Smallest_Missing_Non_negative_Integer_After_Operations
{
    public class Solution
    {
        public int FindSmallestInteger(int[] nums, int value)
        {
            var count = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                int mod = ((num % value) + value) % value;
                if (!count.ContainsKey(mod)) count[mod] = 0;
                count[mod]++;
            }

            int[] freq = new int[value];
            foreach (var kvp in count)
            {
                freq[kvp.Key] = kvp.Value;
            }

            int mex = 0;
            while (true)
            {
                int mod = mex % value;
                if (freq[mod] > 0)
                {
                    freq[mod]--;
                    mex++;
                }
                else
                {
                    break;
                }
            }

            return mex;
        }
    }
}
