namespace Count_the_Number_of_Arrays_with_K_Matching_Adjacent_Elements
{
    /*You are given three integers n, m, k. A good array arr of size n is defined as follows:
    Each element in arr is in the inclusive range [1, m].
    Exactly k indices i (where 1 <= i < n) satisfy the condition arr[i - 1] == arr[i].
    Return the number of good arrays that can be formed.
    Since the answer may be very large, return it modulo 10^9 + 7.
    
     Constraint:
    1 <= n <= 10^5
    1 <= m <= 10^5
    0 <= k <= n - 1
     */
    public class Solution
    {
        const int MOD = 1_000_000_007;
        const int MX = 100000;
        static long[] fact = new long[MX];
        static long[] invFact = new long[MX];

        long qpow(long x, int n)
        {
            long res = 1;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    res = res * x % MOD;
                }
                x = x * x % MOD;
                n >>= 1;
            }
            return res;
        }

        void init()
        {
            if (fact[0] != 0)
            {
                return;
            }
            fact[0] = 1;
            for (int i = 1; i < MX; i++)
            {
                fact[i] = fact[i - 1] * i % MOD;
            }
            invFact[MX - 1] = qpow(fact[MX - 1], MOD - 2);
            for (int i = MX - 1; i > 0; i--)
            {
                invFact[i - 1] = invFact[i] * i % MOD;
            }
        }

        long comb(int n, int m)
        {
            return fact[n] * invFact[m] % MOD * invFact[n - m] % MOD;
        }

        public int CountGoodArrays(int n, int m, int k)
        {
            init();
            return (int)(comb(n - 1, k) * m % MOD * qpow(m - 1, n - k - 1) % MOD);
        }
    }
}
