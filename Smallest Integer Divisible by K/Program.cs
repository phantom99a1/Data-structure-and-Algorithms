namespace Smallest_Integer_Divisible_by_K
{
    public class Solution
    {
        public int SmallestRepunitDivByK(int k)
        {
            // If k has prime factor 2 or 5, no repunit (only 1s) can be divisible.
            if (k % 2 == 0 || k % 5 == 0) return -1;

            int remainder = 0;
            for (int len = 1; len <= k; len++)
            {
                remainder = (remainder * 10 + 1) % k;
                if (remainder == 0) return len;
            }
            // Pigeonhole principle ensures a cycle by len = k; if not found, it's impossible.
            return -1;
        }
    }
}
