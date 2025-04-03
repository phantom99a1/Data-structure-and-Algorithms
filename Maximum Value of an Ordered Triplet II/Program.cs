namespace Maximum_Value_of_an_Ordered_Triplet_II
{
    /*You are given a 0-indexed integer array nums.Return the maximum value over all triplets of indices (i, j, k) 
     * such that i < j < k. If all such triplets have a negative value, return 0.
    The value of a triplet of indices (i, j, k) is equal to (nums[i] - nums[j]) * nums[k].
    
     Constraint:
    3 <= nums.length <= 10^5
    1 <= nums[i] <= 10^6
     */
    using System;
    using System.Linq;

    class Program
    {
        static bool ValidateInput(int[] nums)
        {
            if (nums.Length < 3 || nums.Length > 100000)
            {
                Console.WriteLine("Error: Array length must be between 3 and 10^5.");
                return false;
            }
            if (nums.Any(num => num < 1 || num > 1000000))
            {
                Console.WriteLine("Error: Array elements must be between 1 and 10^6.");
                return false;
            }
            return true;
        }

        static long MaxTripletValue(int[] nums)
        {
            long[] prefixMax = new long[nums.Length];
            long[] suffixMax = new long[nums.Length];

            prefixMax[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                prefixMax[i] = Math.Max(prefixMax[i - 1], nums[i]);
            }

            suffixMax[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                suffixMax[i] = Math.Max(suffixMax[i + 1], nums[i]);
            }

            long maxValue = 0;
            for (int j = 1; j < nums.Length - 1; j++)
            {
                maxValue = Math.Max(maxValue, (prefixMax[j - 1] - nums[j]) * suffixMax[j + 1]);
            }

            return maxValue;
        }

        static void Main()
        {
            Console.WriteLine("Enter the array (comma-separated):");
            var input = Console.ReadLine();
            var nums = input.Split(',').Select(int.Parse).ToArray();

            if (ValidateInput(nums))
            {
                Console.WriteLine("Maximum Triplet Value: " + MaxTripletValue(nums));
            }
        }
    }
}
