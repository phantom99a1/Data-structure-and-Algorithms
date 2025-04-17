namespace Count_Equal_and_Divisible_Pairs_in_an_Array
{
    /*Given a 0-indexed integer array nums of length n and an integer k, return the number of pairs (i, j) 
    where 0 <= i < j < n, such that nums[i] == nums[j] and (i * j) is divisible by k.
    
     Constraint:
    1 <= nums.length <= 100
    1 <= nums[i], k <= 100
     */
    using System;
    using System.Linq;

    class Program
    {
        static int CountDivisiblePairs(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j] && (i * j) % k == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            int[] nums = null;
            int k = 0;

            // Input validation
            while (true)
            {
                try
                {
                    Console.Write("Enter an array of integers (comma-separated, 1 <= length <= 100): ");
                    nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                    if (nums.Length < 1 || nums.Length > 100) throw new Exception("Array length must be between 1 and 100.");
                    if (nums.Any(num => num < 1 || num > 100)) throw new Exception("Array elements must be between 1 and 100.");

                    Console.Write("Enter k (1 <= k <= 100): ");
                    k = int.Parse(Console.ReadLine());
                    if (k < 1 || k > 100) throw new Exception("k must be a number between 1 and 100.");

                    break; // Exit loop if input is valid
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error: " + error.Message);
                }
            }

            Console.WriteLine("Number of Equal and Divisible Pairs: " + CountDivisiblePairs(nums, k));
        }
    }
}
