namespace Count_Symmetric_Integers
{
    /*You are given two positive integers low and high. An integer x consisting of 2 * n digits is symmetric if 
    the sum of the first n digits of x is equal to the sum of the last n digits of x. 
    Numbers with an odd number of digits are never symmetric. Return the number of symmetric integers in the range [low, high].
    
    Constraint:
    1 <= low <= high <= 10^4
     */
    using System;

    class Program
    {
        static void Main()
        {
            int low, high;

            while (true)
            {
                Console.Write("Enter low (1 <= low <= 10^4): ");
                if (int.TryParse(Console.ReadLine(), out low) && low >= 1 && low <= 10000)
                {
                    break;
                }
                Console.WriteLine("Invalid input for low. Please enter a number between 1 and 10^4.");
            }

            while (true)
            {
                Console.Write("Enter high (low <= high <= 10^4): ");
                if (int.TryParse(Console.ReadLine(), out high) && high >= low && high <= 10000)
                {
                    break;
                }
                Console.WriteLine("Invalid input for high. Please enter a number between low and 10^4.");
            }

            Console.WriteLine($"Symmetric integers between {low} and {high}:");
            for (int i = low; i <= high; i++)
            {
                if (IsSymmetric(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsSymmetric(int num)
        {
            string str = num.ToString();
            if (str.Length % 2 != 0) return false;

            int mid = str.Length / 2;
            int sum1 = 0, sum2 = 0;

            for (int i = 0; i < mid; i++)
            {
                sum1 += str[i] - '0';
                sum2 += str[mid + i] - '0';
            }

            return sum1 == sum2;
        }
    }
}
