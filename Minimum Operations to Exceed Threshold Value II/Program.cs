namespace Minimum_Operations_to_Exceed_Threshold_Value_II
{
    /*You are given a 0-indexed integer array nums, and an integer k.
    In one operation, you will:
    Take the two smallest integers x and y in nums.
    Remove x and y from nums.
    Add min(x, y) * 2 + max(x, y) anywhere in the array.
    Note that you can only apply the described operation if nums contains at least two elements.
    Return the minimum number of operations needed so that all elements of the array are greater than or equal to k.
    
    Constraint:
    2 <= nums.length <= 2 * 10^5
    1 <= nums[i] <= 10^9
    1 <= k <= 10^9
    The input is generated such that an answer always exists. That is, there exists some sequence of 
    operations after which all elements of the array are greater than or equal to k.
     */
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MinOperations(int[] nums, int k)
        {
            int result = 0;
            List<long> newNums = new List<long>();
            Array.Sort(nums, (a, b) => b.CompareTo(a));
            int i = nums.Length - 1;
            int j = 0;
            while (true)
            {
                long a, b;
                if (newNums.Count > 0 && j < newNums.Count && (i < 0 || newNums[j] < nums[i]))
                    a = newNums[j++];
                else
                    a = nums[i--];
                if (a >= k)
                    return result;
                if (newNums.Count > 0 && j < newNums.Count && (i < 0 || newNums[j] < nums[i]))
                    b = newNums[j++];
                else
                    b = nums[i--];
                newNums.Add(a * 2 + b);
                result++;
            }
        }

        public static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            int k;

            Console.WriteLine("Enter value for k:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out k) && k >= 1 && k <= 1000000000)
                    break;
                else
                    Console.WriteLine("Error: k should be an integer between 1 and 10^9");
            }

            Console.WriteLine("Enter elements for nums, one per line. Enter 'done' when finished:");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;

                if (int.TryParse(input, out int num) && num >= 1 && num <= 1000000000)
                    nums.Add(num);
                else
                    Console.WriteLine("Error: nums[i] should be an integer between 1 and 10^9");
            }

            Solution solution = new Solution();
            Console.WriteLine($"Minimum operations: {solution.MinOperations(nums.ToArray(), k)}");
        }
    }
}
