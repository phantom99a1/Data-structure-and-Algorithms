namespace Continuous_Subarrays
{
    /*You are given a 0-indexed integer array nums. A subarray of nums is called continuous if:

    Let i, i + 1, ..., j be the indices in the subarray. 
    Then, for each pair of indices i <= i1, i2 <= j, 0 <= |nums[i1] - nums[i2]| <= 2.
    Return the total number of continuous subarrays.

    A subarray is a contiguous non-empty sequence of elements within an array.
    
    Constraints:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
    */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // Read input from the keyboard
            Console.Write("Enter the array of integers (space separated): ");
            string input = Console.ReadLine() ?? "";
            int[] nums;

            // Validate input
            try
            {
                nums = input.Split(' ').Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid array of integers.");
                Console.ReadKey();
                return;
            }

            if (nums.Length == 0 || nums.Any(x => x < 1))
            {
                Console.WriteLine("Invalid input. Please enter a valid array of integers.");
                Console.ReadKey();
                return;
            }

            // Calculate and print the total number of continuous subarrays
            long count = ContinuousSubarrays(nums);
            Console.WriteLine("Total number of continuous subarrays: " + count);
            Console.ReadKey();
        }

        // Function to find the total number of continuous subarrays
        public static long ContinuousSubarrays(int[] nums)
        {
            long count = 0;
            int n = nums.Length;
            var minDeque = new LinkedList<int>();
            var maxDeque = new LinkedList<int>();
            int left = 0;

            for (int right = 0; right < n; right++)
            {
                // Maintain the minDeque to store the indices of minimum elements
                while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[right])
                {
                    minDeque.RemoveLast();
                }
                minDeque.AddLast(right);

                // Maintain the maxDeque to store the indices of maximum elements
                while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[right])
                {
                    maxDeque.RemoveLast();
                }
                maxDeque.AddLast(right);

                // Check the difference between the max and min values in the window
                while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > 2)
                {
                    left++;
                    // Remove elements outside the window
                    if (minDeque.First.Value < left)
                    {
                        minDeque.RemoveFirst();
                    }
                    if (maxDeque.First.Value < left)
                    {
                        maxDeque.RemoveFirst();
                    }
                }

                // Calculate the number of continuous subarrays ending at 'right'
                count += right - left + 1;
            }

            return count;
        }
    }

}
