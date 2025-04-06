namespace Largest_Divisible_Subset
{
    /*Given a set of distinct positive integers nums, return the largest subset answer such that every pair 
    (answer[i], answer[j]) of elements in this subset satisfies:
    answer[i] % answer[j] == 0, or
    answer[j] % answer[i] == 0
    If there are multiple solutions, return any of them.
    
    Constraint:
    1 <= nums.length <= 1000
    1 <= nums[i] <= 2 * 10^9
    All the integers in nums are unique.
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<int> LargestDivisibleSubset(List<int> nums)
        {
            nums.Sort();
            int n = nums.Count;
            int[] dp = new int[n];
            int[] previousIndex = new int[n];
            int maxSubsetIndex = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                previousIndex[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        previousIndex[i] = j;
                    }
                }
                if (dp[i] > dp[maxSubsetIndex])
                {
                    maxSubsetIndex = i;
                }
            }

            List<int> subset = new List<int>();
            while (maxSubsetIndex != -1)
            {
                subset.Add(nums[maxSubsetIndex]);
                maxSubsetIndex = previousIndex[maxSubsetIndex];
            }
            return subset;
        }

        static void ValidateInput(List<int> nums)
        {
            List<string> errors = new List<string>();
            if (nums.Count < 1 || nums.Count > 1000)
            {
                errors.Add("Error: nums.Length must be between 1 and 1000.");
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 2000000000)
                {
                    errors.Add("Error: nums[i] must be between 1 and 2 * 10^9.");
                }
            }
            HashSet<int> uniqueNums = new HashSet<int>(nums);
            if (uniqueNums.Count != nums.Count)
            {
                errors.Add("Error: All integers in nums must be unique.");
            }
            if (errors.Count > 0)
            {
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            Console.WriteLine("Enter numbers (type 'done' to finish):");
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input.Trim().ToLower() == "done")
                {
                    ValidateInput(nums);
                    var subset = LargestDivisibleSubset(nums);
                    Console.WriteLine("Largest Divisible Subset: " + string.Join(", ", subset));
                    break;
                }
                else
                {
                    if (int.TryParse(input.Trim(), out int num))
                    {
                        nums.Add(num);
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid number.");
                    }
                }
            }
        }
    }
}
