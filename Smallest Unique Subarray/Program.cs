namespace Smallest_Unique_Subarray
{
    public class Solution
    {
        public int SmallestUniqueSubarray(int[] nums)
        {
            int len = nums.Length;
            if (len < 2)
                return len;

            long b = 101;
            long mod = (long)Math.Pow(10, 9) + 7;
            int low = 1, high = len;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                long hcode = 0, p = 1;
                for (int i = 0; i < mid; i++)
                {
                    hcode = (hcode * b + nums[i]) % mod;
                    p = p * b % mod;
                }

                Dictionary<long, int> freq = new();
                freq.Add(hcode, 1);
                for (int i = mid; i < len; i++)
                {
                    hcode = (hcode * b + nums[i] - nums[i - mid] * p % mod) % mod;
                    if (hcode < 0)
                        hcode += mod;

                    freq.TryAdd(hcode, 0);
                    freq[hcode]++;
                }

                bool findValid = false;
                foreach (var kvp in freq)
                {
                    if (kvp.Value == 1)
                    {
                        findValid = true;
                        break;
                    }
                }

                if (findValid)
                    high = mid;
                else
                    low = mid + 1;
            }

            return high;
        }
    }
}
