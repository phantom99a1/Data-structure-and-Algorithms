namespace Partition_Equal_Subset_Sum
{
    /*Given an integer array nums, return true if you can partition the array into two subsets such that the sum of 
    the elements in both subsets is equal or false otherwise.
    
    Constraint:
    1 <= nums.length <= 200
    1 <= nums[i] <= 100
     */
    using System;
    using System.Linq;

    class Program
    {
        static string IsValidInput(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 200)
            {
                return "Error: Array length must be between 1 and 200.";
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return $"Error: Array elements must be between 1 and 100. Invalid element: {num}";
                }
            }
            return null; // No errors
        }

        static bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 != 0) return false;
            int target = sum / 2;
            bool[] dp = new bool[target + 1];
            dp[0] = true;

            foreach (int num in nums)
            {
                for (int i = target; i >= num; i--)
                {
                    dp[i] = dp[i] || dp[i - num];
                }
            }
            return dp[target];
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Enter an array of positive integers (comma-separated): ");
                string input = Console.ReadLine();
                int[] nums;
                try
                {
                    nums = input.Split(',').Select(int.Parse).ToArray();
                }
                catch
                {
                    Console.WriteLine("Error: Invalid input. Please enter integers only.");
                    continue;
                }

                string error = IsValidInput(nums);
                if (error != null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                Console.WriteLine("Can partition: " + CanPartition(nums));
                break;
            }
        }
    }
}
