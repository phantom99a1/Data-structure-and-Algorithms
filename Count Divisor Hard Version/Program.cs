namespace Count_Divisor_Hard_Version
{
    /*Given an array of positive integers A[] consisting of n positive integers, 
     * let M be the product of all the numbers in the array. Calculate the number of divisors of M. 
     * Since the number of divisors of M can be very large, return the result modulo 10^9+7.*/
    
    public class Solution
    {
        const int MAX = 1000000;
        static readonly int[] p = new int[MAX + 1];
        static readonly int[] cnt = new int[MAX + 1];

        static void Sieve()
        {
            for (int i = 1; i <= MAX; i++)
            {
                p[i] = i;
            }
            for (int i = 2; i <= 1000; i++)
            {
                if (p[i] == i)
                {
                    for (int j = 2 * i; j <= MAX; j += i)
                    {
                        if (p[j] == j)
                            p[j] = i;
                    }
                }
            }
        }

        static void Factorize(int n)
        {
            while (n != 1)
            {
                int d = p[n];
                while (n % d == 0)
                {
                    n /= d;
                    cnt[d]++;
                }
            }
        }

        public static void Main()
        {
            Sieve();
            int mod = 1000000007;

            Console.WriteLine("Enter the number of elements:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("The number of elements must be a positive integer.");
                return;
            }

            int[] A = new int[n];
            Console.WriteLine($"Enter {n} positive integers:");
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out A[i]) || A[i] <= 0)
                {
                    Console.WriteLine("Each element must be a positive integer.");
                    return;
                }
            }

            foreach (var num in A)
            {
                Factorize(num);
            }

            long ans = 1;
            for (int i = 2; i <= MAX; i++)
            {
                if (cnt[i] != 0)
                {
                    ans = ans * (cnt[i] + 1) % mod;
                }
            }
            Console.WriteLine("The number of divisors is: " + ans);
            Console.ReadKey();
        }
    }
}
