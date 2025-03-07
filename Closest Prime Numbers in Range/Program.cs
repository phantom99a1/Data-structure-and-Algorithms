namespace Closest_Prime_Numbers_in_Range
{
    /*Given two positive integers left and right, find the two integers num1 and num2 such that:
    left <= num1 < num2 <= right .
    Both num1 and num2 are prime numbers.
    num2 - num1 is the minimum amongst all other pairs satisfying the above conditions.
    Return the positive integer array ans = [num1, num2]. If there are multiple pairs satisfying these conditions, 
    return the one with the smallest num1 value. If no such numbers exist, return [-1, -1].
    
    Constraint:
    1 <= left <= right <= 10^6
     */
    
    public class Program
    {
        private const int minValue = 1;
        private const int maxValue = 1000000;
        // Sieve of Eratosthenes to generate prime numbers
        public static bool[] GeneratePrimes(int max)
        {
            bool[] isPrime = new bool[max + 1];
            Array.Fill(isPrime, true);
            isPrime[0] = isPrime[1] = false; // 0 and 1 are not prime

            for (int i = 2; i * i <= max; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= max; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            return isPrime;
        }

        // Validate the input
        public static int ValidateInput(string input)
        {
            if (!int.TryParse(input, out int num) || num < minValue || num > maxValue)
            {
                throw new ArgumentException($"Number must be between {minValue} and {maxValue}.");
            }
            return num;
        }

        // Find the closest primes in the range
        public static int[]? FindClosestPrimes(int left, int right, bool[] isPrime)
        {
            var primes = new List<int>();
            for (int i = left; i <= right; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            if (primes.Count < 2)
            {
                return null; // Not enough primes in the range
            }

            int minDiff = int.MaxValue;
            int[]? closest = null;

            for (int i = 0; i < primes.Count - 1; i++)
            {
                int diff = primes[i + 1] - primes[i];
                if (diff < minDiff)
                {
                    minDiff = diff;
                    closest = [primes[i], primes[i + 1]];
                }
            }

            return closest;
        }

        public static void Main()
        {
            bool[] isPrime = GeneratePrimes(maxValue); // Precompute primes up to 1,000,000
            int left, right;

            while (true)
            {
                try
                {
                    Console.Write("Enter left: ");
                    left = ValidateInput(Console.ReadLine() ?? "");                    
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter right: ");
                    right = ValidateInput(Console.ReadLine() ?? "");
                    if (left > right)
                    {
                        Console.WriteLine("Constraint violated: left should be <= right.");
                        continue;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var closestPrimes = FindClosestPrimes(left, right, isPrime);
            if (closestPrimes == null)
            {
                Console.WriteLine("Not enough primes in the range.");
            }
            else
            {
                Console.WriteLine($"Closest prime numbers: [{string.Join(',', closestPrimes)}]");
                Console.ReadKey();
            }
        }
    }
}
