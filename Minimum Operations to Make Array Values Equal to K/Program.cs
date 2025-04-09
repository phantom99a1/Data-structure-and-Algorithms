namespace Minimum_Operations_to_Make_Array_Values_Equal_to_K
{
    /*You are given an integer array nums and an integer k.
    An integer h is called valid if all values in the array that are strictly greater than h are identical.
    For example, if nums = [10, 8, 10, 8], a valid integer is h = 9 because all nums[i] > 9 are equal to 10, 
    but 5 is not a valid integer.You are allowed to perform the following operation on nums:
    Select an integer h that is valid for the current values in nums.For each index i where nums[i] > h, set nums[i] to h.
    Return the minimum number of operations required to make every element in nums equal to k. 
    If it is impossible to make all elements equal to k, return -1.
    
     Constraint:
    1 <= nums.length <= 100 
    1 <= nums[i] <= 100
    1 <= k <= 100
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int MinimumOperations(int[] nums, int k)
        {
            if (Array.Exists(nums, num => num < 1 || num > 100) || k < 1 || k > 100)
            {
                Console.WriteLine("Error: Constraints violated. Ensure 1 <= nums[i] <= 100 and 1 <= k <= 100.");
                return -1;
            }

            int operations = 0;
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in nums)
            {
                if (num > k && !seen.Contains(num))
                {
                    operations++;
                    seen.Add(num);
                }
            }

            return Array.TrueForAll(nums, num => num >= k) ? operations : -1;
        }

        static void Main()
        {
            Console.WriteLine("Enter array values separated by spaces (e.g., 5 2 5 4 5):");
            string[] input = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(input, int.Parse);

            Console.WriteLine("Enter the value of k:");
            int k = int.Parse(Console.ReadLine());

            if (nums.Length < 1 || nums.Length > 100 || Array.Exists(nums, num => num < 1 || num > 100) || k < 1 || k > 100)
            {
                Console.WriteLine("Error: Invalid input. Ensure all values are numbers and within constraints.");
                return;
            }

            int result = MinimumOperations(nums, k);
            Console.WriteLine("Result: " + result);
        }
    }
}
