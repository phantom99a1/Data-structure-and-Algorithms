namespace Maximum_Value_of_an_Ordered_Triplet_I
{
    /*You are given a 0-indexed integer array nums.Return the maximum value over all triplets of indices (i, j, k) 
     * such that i < j < k. If all such triplets have a negative value, return 0.
    The value of a triplet of indices (i, j, k) is equal to (nums[i] - nums[j]) * nums[k].
    
    Constraint:
    3 <= nums.length <= 100
    1 <= nums[i] <= 10^6
     */
    using System;
    using System.Linq;

    class Program
    {
        static int[] ValidateInput(string input)
        {
            int[] nums = input.Split(' ').Select(int.Parse).ToArray();
            if (nums.Length < 3 || nums.Length > 100)
            {
                Console.WriteLine("Error: The array length must be between 3 and 100.");
                return null;
            }
            if (nums.Any(n => n < 1 || n > Math.Pow(10, 6)))
            {
                Console.WriteLine("Error: Each number must be between 1 and 10^6.");
                return null;
            }
            return nums;
        }

        static long MaximumTripletValue(int[] nums)
        {
            int n = nums.Length;
            if (n < 3) return 0; // A triplet isn't possible if the array length is less than 3

            long maxLeft = nums[0]; // Maximum value seen so far
            long maxValue = 0; // Maximum triplet value initialized

            for (int j = 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    // Calculate the triplet value: (nums[i] - nums[j]) * nums[k]
                    long tripletValue = (maxLeft - nums[j]) * nums[k];
                    maxValue = Math.Max(maxValue, tripletValue); // Update maxValue
                }
                maxLeft = Math.Max(maxLeft, nums[j]); // Update maxLeft
            }

            return maxValue;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();
            int[] nums = ValidateInput(input);
            if (nums != null)
            {
                Console.WriteLine("Maximum value of triplet: " + MaximumTripletValue(nums));
            }
        }
    }
}
