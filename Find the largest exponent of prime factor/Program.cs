namespace Find_the_largest_exponent_of_prime_factor
{
    #region
    /*
    Find the prime factor with the largest exponent of the integer N. 
    If there are multiple prime factors with the same largest exponent, choose the smaller number.*/
    #endregion    
    public class Program
    {
        public static void Solve(long n)
        {
            long res = 0;
            int mu = 0;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    int dem = 0;
                    while (n % i == 0)
                    {
                        ++dem;
                        n /= i;
                    }
                    if (dem > mu)
                    {
                        mu = dem;
                        res = i;
                    }
                }
            }

            if (n != 1)
            {
                if (mu == 0)
                {
                    mu = 1;
                    res = n;
                }
            }

            Console.WriteLine($"{res} {mu}");
        }

        public static void Main()
        {
            long n = GetPositiveLong("Enter a positive integer: ");
            Solve(n);
            Console.ReadKey();
        }

        public static long GetPositiveLong(string prompt)
        {
            long value;
            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine() ?? "";
                if (!long.TryParse(input, out value) || value <= 0)
                {
                    Console.WriteLine("Input must be a positive integer. Please try again.");
                }
            } while (value <= 0);
            return value;
        }
    }

}
