namespace Count_Divisors
{
    /*
    Given a positive integer n, find the number of divisors, the even number of divisors of n
    Input: The first line contains a positive integer 𝑡 (1 ≤ 𝑡 ≤ 20), the number of test cases.
    The next 𝑡 lines each contain a positive integer 𝑛 (0 < 𝑛 <= 10^14).
    Output: the number of divisors, the even number of divisors of n
    */   
    public class Program
    {
        public static void Main()
        {
            long n;

            // Loop to ensure valid input for n
            while (true)
            {
                Console.Write("Enter a positive integer n: ");
                if (long.TryParse(Console.ReadLine(), out n) && n > 0 && n < (long)Math.Pow(10,14))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer greater than 0 and less than 10^14.");
                    Console.ReadKey();
                }
            }

            // Find and count divisors
            int totalDivisors = CountDivisors(n);
            int evenDivisors = CountEvenDivisors(n);

            // Output the results
            Console.WriteLine($"Total number of divisors of {n}: {totalDivisors}");
            Console.WriteLine($"Number of even divisors of {n}: {evenDivisors}");
            Console.ReadKey(true);
        }

        public static int CountDivisors(long n)
        {
            int count = 0;
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (i * i == n)
                    {
                        count++; // i is a perfect square
                    }
                    else
                    {
                        count += 2; // i and n/i are both divisors
                    }
                }
            }
            return count;
        }

        public static int CountEvenDivisors(long n)
        {
            int count = 0;
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    if (i * i == n)
                    {
                        if (i % 2 == 0) count++;
                    }
                    else
                    {
                        if (i % 2 == 0) count++;
                        if ((n / i) % 2 == 0) count++;
                    }
                }
            }
            return count;
        }
    }

}
