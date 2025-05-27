namespace Divisible_and_Non_divisible_Sums_Difference
{
    using System;

    class Program
    {
        static int DifferenceOfSums(int n, int m)
        {
            int totalDifference = 0;
            for (int i = 1; i <= n; i++)
            {
                totalDifference += (i % m == 0) ? -i : i;
            }
            return totalDifference;
        }

        static void Main()
        {
            Console.WriteLine(DifferenceOfSums(10, 3)); // Output: 19
        }
    }
}
