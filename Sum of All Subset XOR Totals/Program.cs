namespace Sum_of_All_Subset_XOR_Totals
{
    /*The XOR total of an array is defined as the bitwise XOR of all its elements, or 0 if the array is empty.
    For example, the XOR total of the array [2,5,6] is 2 XOR 5 XOR 6 = 1.
    Given an array nums, return the sum of all XOR totals for every subset of nums. 
    Note: Subsets with the same elements should be counted multiple times.
    An array a is a subset of an array b if a can be obtained from b by deleting some (possibly zero) elements of b.
    
    Constraint:
    1 <= nums.length <= 12
    1 <= nums[i] <= 20
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int SubsetXORSum(int[] nums)
        {
            int dfs(int index, int currentXor)
            {
                if (index == nums.Length) return currentXor;
                return dfs(index + 1, currentXor ^ nums[index]) + dfs(index + 1, currentXor);
            }
            return dfs(0, 0);
        }

        static string ValidateInput(List<int> nums)
        {
            if (nums.Count < 1 || nums.Count > 12)
                return "Error: nums.length must be between 1 and 12.";
            foreach (int num in nums)
            {
                if (num < 1 || num > 20)
                    return $"Error: nums[i] = {num} is out of bounds (1 <= nums[i] <= 20).";
            }
            return null;
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Enter numbers separated by spaces: ");
                string input = Console.ReadLine();
                var nums = new List<int>();

                foreach (string num in input.Split(" "))
                {
                    if (int.TryParse(num, out int parsedNum))
                        nums.Add(parsedNum);
                    else
                    {
                        Console.WriteLine($"Error: Invalid number '{num}'.");
                        continue;
                    }
                }

                string error = ValidateInput(nums);
                if (error != null)
                {
                    Console.WriteLine(error);
                    continue;
                }

                int result = SubsetXORSum(nums.ToArray());
                Console.WriteLine($"Subset XOR Sum: {result}");
                break;
            }
        }
    }
}
