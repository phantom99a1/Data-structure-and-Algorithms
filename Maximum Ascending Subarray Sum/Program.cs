namespace Maximum_Ascending_Subarray_Sum
{
    /*Given an array of positive integers nums, return the maximum possible sum of an ascending subarray in nums.
    A subarray is defined as a contiguous sequence of numbers in an array.
    A subarray [numsl, numsl+1, ..., numsr-1, numsr] is ascending if for all i where l <= i < r, numsi  < numsi+1. 
    Note that a subarray of size 1 is ascending.

    Constraint:
    1 <= nums.length <= 100
    1 <= nums[i] <= 100
    */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100;
        private const int minValue = 1;
        private const int maxValue = 100;
        public static void Main()
        {
            int[] nums;
            while (true)
            {
                Console.WriteLine("Enter numbers separated by spaces:");
                string input = Console.ReadLine() ?? "";
                try
                {
                    nums = input.Split(' ').Select(int.Parse).ToArray();
                    if (nums.Length < minLength || nums.Length > maxLength)
                    {
                        throw new ArgumentException($"Array length must be between {minLength} and {maxLength}.");
                    }
                    if (nums.Any(n => n < minValue || n > maxValue))
                    {
                        throw new ArgumentException($"Array elements must be between {minValue} and {maxValue}.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("Maximum Ascending Subarray Sum: " + MaximumAscendingSubarraySum(nums));
            Console.ReadKey();
        }

        public static int MaximumAscendingSubarraySum(int[] nums)
        {
            int maxSum = 0;
            int currentSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    currentSum += nums[i];
                }
                else
                {
                    maxSum = Math.Max(maxSum, currentSum);
                    currentSum = nums[i];
                }
            }
            return Math.Max(maxSum, currentSum);
        }
    }
}
