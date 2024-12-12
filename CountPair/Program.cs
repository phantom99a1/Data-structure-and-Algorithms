using System.Numerics;

namespace CountPair
{
    /*Given an integer 𝑛, find all pairs of integers (𝑎,𝑏) such that 𝑎 and 𝑏 are even, 𝑎,𝑏>0, and 𝑎⋅𝑎⋅𝑏⋅𝑏=𝑛.The pair (𝑎,𝑏) is ordered.
    Input: The first line contains a positive integer 𝑡 (1 ≤ 𝑡 ≤ 20), the number of test cases.
    The next 𝑡 lines each contain a positive integer 𝑛 (0 < 𝑛 <= 10^18).
    Output:
    For each test case, output the number of pairs (𝑎,𝑏) that satisfy the given conditions.
    Extension: Show all of pairs that statisfy the given conditions
    */
    public class Program
    {
        public static void Main()
        {
            // Enter the number of testcases
            int t;
            do
            {
                Console.Write("Enter the number of testcases (1 <= t <= 20): ");
            } while (!int.TryParse(Console.ReadLine(), out t) || t < 1 || t > 20);

            for (int i = 0; i < t; i++)
            {
                // Enter n and check the validation:
                BigInteger n;
                do
                {
                    Console.Write($"Enter the positive integer for testcase {i + 1} (0 < n <= 10^18): ");
                } while (!BigInteger.TryParse(Console.ReadLine(), out n) || n <= 0 || n > BigInteger.Pow(10, 18));

                // Count and print the pair (a, b) is ordered:
                int count = CountPairs(n);
                Console.WriteLine(count);
                var pairs = FindListPairs(n); 
                if (pairs != null && pairs.Count > 0) 
                { 
                    foreach(var pair in pairs)
                    {
                        Console.WriteLine($"({pair.Item1}, {pair.Item2})");
                    }
                } else { 
                    Console.WriteLine("There is no pairs that statisfy the given conditions!"); 
                }
                Console.ReadKey();
            }
        }

        public static int CountPairs(BigInteger n)
        {
            int count = 0;
            for (BigInteger a = 2; a * a * a * a <= n; a += 2)
            {
                if (n % (a * a) == 0)
                {
                    BigInteger m = n / (a * a);
                    BigInteger b = Sqrt(m);
                    if (b * b == m && b % 2 == 0)
                    {
                        count += 2;
                    }
                    if (a == b)
                        count--;
                }
            }
            return count;
        }

        public static BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            BigInteger x = n / 2;
            while (true)
            {
                BigInteger y = (x + n / x) / 2;
                if (y >= x) return x;
                x = y;
            }
        }
        public static List<Tuple<BigInteger, BigInteger>>? FindListPairs(BigInteger n)
        {
            var pairs = new List<Tuple<BigInteger, BigInteger>>();
            for (BigInteger a = 2; a * a * a * a <= n; a += 2) 
            { 
                if (n % (a * a) == 0) 
                { 
                    BigInteger m = n / (a * a); 
                    BigInteger b = Sqrt(m); 
                    if (b * b == m && b % 2 == 0) 
                    {
                        pairs.Add(new Tuple<BigInteger, BigInteger>(a, b)); 
                    } 
                } 
            }
            return pairs;
        }
    }
}
