namespace Minimum_Index_of_a_Valid_Split
{
    /*An element x of an integer array arr of length m is dominant if more than half the elements of arr have a value of x.
    You are given a 0-indexed integer array nums of length n with one dominant element.
    You can split nums at an index i into two arrays nums[0, ..., i] and nums[i + 1, ..., n - 1], but the split is only valid if:
    0 <= i < n - 1
    nums[0, ..., i], and nums[i + 1, ..., n - 1] have the same dominant element.
    Here, nums[i, ..., j] denotes the subarray of nums starting at index i and ending at index j, both ends being inclusive. 
    Particularly, if j < i then nums[i, ..., j] denotes an empty subarray.
    Return the minimum index of a valid split. If no valid split exists, return -1.
    
    Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
    nums has exactly one dominant element.
     */

    using System;
    using System.Linq;

    class Program
    {
        public static int MinimumIndex(int[] nums)
        {
            int n = nums.Length;

            // Step 1: Find the dominant element using Boyer-Moore majority vote algorithm
            int? candidate = null;
            int count = 0;
            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                    count = 1;
                }
                else
                {
                    count += (num == candidate) ? 1 : -1;
                }
            }

            // Check if the candidate is truly dominant
            int totalFrequency = nums.Count(num => num == candidate);
            if (totalFrequency <= n / 2)
            {
                return -1; // No valid dominant element
            }

            // Step 2: Validate the split
            int leftCount = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] == candidate)
                {
                    leftCount++;
                }
                int rightCount = totalFrequency - leftCount;

                if (leftCount > (i + 1) / 2 && rightCount > (n - i - 1) / 2)
                {
                    return i;
                }
            }

            return -1; // No valid split found
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter array (comma-separated):");
            string input = Console.ReadLine();
            int[] nums = Array.ConvertAll(input.Split(','), int.Parse);

            int result = MinimumIndex(nums);
            Console.WriteLine("Minimum index of a valid split: " + result);
        }
    }
}
