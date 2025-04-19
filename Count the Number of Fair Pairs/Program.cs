namespace Count_the_Number_of_Fair_Pairs
{
    /*Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.
    A pair (i, j) is fair if:
    0 <= i < j < n, and
    lower <= nums[i] + nums[j] <= upper
    
     Constraint:
    1 <= nums.length <= 10^5
    nums.length == n
    -10^9 <= nums[i] <= 10^9
    -10^9 <= lower <= upper <= 10^9
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<int> ValidateInput(string input)
        {
            string[] parts = input.Split(',');
            List<int> nums = new List<int>();
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    if (num < -1_000_000_000 || num > 1_000_000_000)
                    {
                        Console.WriteLine($"Error: {num} is out of range (-10^9 to 10^9).");
                        return null;
                    }
                    nums.Add(num);
                }
                else
                {
                    Console.WriteLine($"Error: '{part}' is not a valid integer.");
                    return null;
                }
            }
            if (nums.Count < 1 || nums.Count > 100_000)
            {
                Console.WriteLine("Error: nums.length must be between 1 and 10^5.");
                return null;
            }
            return nums;
        }

        static int CountFairPairs(List<int> nums, int lower, int upper)
        {
            nums.Sort();
            int count = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                int left = i + 1, right = nums.Count - 1;

                // Binary search for lower bound
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[i] + nums[mid] >= lower)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                int lowerBound = left;

                left = i + 1;
                right = nums.Count - 1;

                // Binary search for upper bound
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[i] + nums[mid] <= upper)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                int upperBound = right;

                if (lowerBound <= upperBound)
                {
                    count += (upperBound - lowerBound + 1);
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by commas:");
            string input = Console.ReadLine() ?? "";
            List<int> nums = ValidateInput(input);

            if (nums != null)
            {
                Console.WriteLine("Enter lower bound:");
                if (int.TryParse(Console.ReadLine(), out int lower) &&
                    lower >= -1_000_000_000 && lower <= 1_000_000_000)
                {
                    Console.WriteLine("Enter upper bound:");
                    if (int.TryParse(Console.ReadLine(), out int upper) &&
                        upper >= -1_000_000_000 && upper <= 1_000_000_000 &&
                        lower <= upper)
                    {
                        int count = CountFairPairs(nums, lower, upper);
                        Console.WriteLine($"Number of fair pairs: {count}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid upper bound.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid lower bound.");
                }
            }
        }
    }
}
