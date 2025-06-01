namespace Distribute_Candies_Among_Children_II
{
    using System;

    class Program
    {
        static int DistributeCandies(int n, int limit)
        {
            int[,] dp = new int[4, n + 1];
            dp[0, 0] = 1;

            for (int child = 1; child <= 3; child++)
            {
                for (int candy = 0; candy <= n; candy++)
                {
                    dp[child, candy] = dp[child - 1, candy];
                    if (candy > 0) dp[child, candy] += dp[child, candy - 1];

                    if (candy - limit - 1 >= 0)
                    {
                        dp[child, candy] -= dp[child - 1, candy - limit - 1];
                    }
                }
            }

            return dp[3, n];
        }

        static void Main()
        {
            Console.WriteLine(DistributeCandies(5, 2)); // Output: 3
        }
    }
}
