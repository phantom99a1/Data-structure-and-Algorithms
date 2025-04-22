namespace Count_the_Number_of_Ideal_Arrays
{
    /*You are given two integers n and maxValue, which are used to describe an ideal array.
    A 0-indexed integer array arr of length n is considered ideal if the following conditions hold:
    Every arr[i] is a value from 1 to maxValue, for 0 <= i < n.
    Every arr[i] is divisible by arr[i - 1], for 0 < i < n.
    Return the number of distinct ideal arrays of length n. Since the answer may be very large, return it modulo 10^9 + 7.
    
     Constraint:
    2 <= n <= 10^4
    1 <= maxValue <= 10^4
     */
    public class Solution
    {
        long[,] dp = new long[15, 10001];
        long[,] pr = new long[15, 10001];
        long[] tot = new long[15];
        const long mod = 1000000007;
        int n, mx;

        void Get(int la, int cn)
        {
            tot[cn]++;
            for (int p = 2 * la; p <= mx; p += la)
                Get(p, cn + 1);
        }

        public int IdealArrays(int nn, int mmx)
        {
            n = nn;
            mx = mmx;

            for (int i = 1; i <= 10000; i++)
            {
                dp[1, i] = 1;
                pr[1, i] = i;
            }

            for (int i = 2; i < 15; i++)
            {
                for (int j = i; j <= 10000; j++)
                {
                    dp[i, j] = pr[i - 1, j - 1];
                    pr[i, j] = (dp[i, j] + pr[i, j - 1]) % mod;
                }
            }

            for (int i = 1; i <= mx; i++)
                Get(i, 1);

            long ans = mx;
            for (int i = 2; i < 15; i++)
            {
                ans = (ans + tot[i] * dp[i, n]) % mod;
            }

            return (int)ans;
        }
    }
}
