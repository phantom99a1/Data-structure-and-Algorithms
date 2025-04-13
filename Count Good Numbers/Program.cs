namespace Count_Good_Numbers
{
    /*A digit string is good if the digits (0-indexed) at even indices are even and the digits at odd indices are prime 
    (2, 3, 5, or 7). For example, "2582" is good because the digits (2 and 8) at even positions are even and the digits 
    (5 and 2) at odd positions are prime. However, "3245" is not good because 3 is at an even index but is not even.
    Given an integer n, return the total number of good digit strings of length n. Since the answer may be large, 
    return it modulo 10^9 + 7. A digit string is a string consisting of digits 0 through 9 that may contain leading zeros.
    
     Constraint:
    1 <= n <= 10^15
     */
    using System;
    using System.Numerics;

    class Program
    {
        private const long MOD = 1000000000 + 7;
        static void Main()
        {
            long number = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter a valid number (1 <= n <= 10^15): ");
                string input = Console.ReadLine();

                if (!long.TryParse(input, out number))
                {
                    Console.WriteLine("Error: Input must be a positive integer.");
                    continue;
                }

                if (number < 1 || number > BigInteger.Pow(10, 15))
                {
                    Console.WriteLine("Error: Number must be in the range 1 to 10^15.");
                    continue;
                }

                isValid = true;
            }

            Console.WriteLine($"Good Numbers Count: {CountGoodNumbers(number)}");
        }

        public static int CountGoodNumbers(long n)
        {
            long four = Power(4, n / 2) % MOD;
            long five = Power(5, n / 2) % MOD;

            long ans = (four * five) % MOD;
            if (n % 2 == 1)
                ans = (ans * 5) % MOD;

            return (int)ans;
        }
        static long Power(long x, long n)
        {
            long ans = 1;
            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    x = (x * x) % MOD;
                    n = n / 2;
                }
                else
                {
                    ans = (ans * x) % MOD;
                    n = n - 1;
                }
            }
            return ans;

        }
    }
}
