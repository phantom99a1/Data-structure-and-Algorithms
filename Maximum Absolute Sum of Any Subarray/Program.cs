namespace Maximum_Absolute_Sum_of_Any_Subarray
{
    /*You are given an integer array nums. The absolute sum of a subarray [numsl, numsl+1, ..., numsr-1, numsr] 
    is abs(numsl + numsl+1 + ... + numsr-1 + numsr).
    Return the maximum absolute sum of any (possibly empty) subarray of nums.
    Note that abs(x) is defined as follows:
    If x is a negative integer, then abs(x) = -x.
    If x is a non-negative integer, then abs(x) = x.
    
    Constraint:
    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4
     */
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        private const int minValue = -10000;
        private const int maxValue = 10000;
        public static void Main()
        {
            int[] nums = GetValidInput();
            Console.WriteLine("Maximum Absolute Sum of Any Subarray: " + MaxAbsoluteSum(nums));
            Console.ReadKey();
        }

        public static int[] GetValidInput()
        {
            while (true)
            {
                Console.WriteLine("Enter an array of integers separated by spaces: ");
                string input = Console.ReadLine() ?? "";
                int[] nums = input.Split(' ').Select(int.Parse).ToArray();
                if (ValidateInput(nums))
                {
                    return nums;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please ensure that {minLength} <= nums.length <= {maxLength} and {minValue} <= nums[i] <= {maxValue}.");
                }
            }
        }

        public static bool ValidateInput(int[] nums)
        {
            if (nums.Length < minLength || nums.Length > maxLength) return false;
            foreach (int num in nums)
            {
                if (num < minValue || num > maxValue) return false;
            }
            return true;
        }

        public static int MaxAbsoluteSum(int[] nums)
        {
            int maxSum = 0, minSum = 0, currentMax = 0, currentMin = 0;

            foreach (int num in nums)
            {
                currentMax = Math.Max(currentMax + num, num);
                maxSum = Math.Max(maxSum, currentMax);

                currentMin = Math.Min(currentMin + num, num);
                minSum = Math.Min(minSum, currentMin);
            }

            return Math.Max(maxSum, -minSum);
        }
    }
}
