namespace Find_the_Number_of_Subsequences_With_Equal_GCD
{
    public class Solution
    {
        const int MOD = 1000000007;

        public int SubsequencePairCount(int[] nums)
        {
            int m = 0;
            foreach (int num in nums)
            {
                m = Math.Max(m, num);
            }

            int[,] dp = new int[m + 1, m + 1];
            dp[0, 0] = 1;

            foreach (int num in nums)
            {
                int[,] ndp = new int[m + 1, m + 1];
                for (int j = 0; j <= m; j++)
                {
                    int divisor1 = Gcd(j, num);
                    for (int k = 0; k <= m; k++)
                    {
                        int val = dp[j, k];
                        if (val == 0)
                        {
                            continue;
                        }
                        int divisor2 = Gcd(k, num);
                        ndp[j, k] = (ndp[j, k] + val) % MOD;
                        ndp[divisor1, k] = (ndp[divisor1, k] + val) % MOD;
                        ndp[j, divisor2] = (ndp[j, divisor2] + val) % MOD;
                    }
                }
                dp = ndp;
            }

            int ans = 0;
            for (int j = 1; j <= m; j++)
            {
                ans = (ans + dp[j, j]) % MOD;
            }
            return ans;
        }

        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = a;
                a = b;
                b = temp % b;
            }
            return a;
        }
    }
}
