namespace Maximum_Absolute_Sum_of_Any_Subarray
{
    
    public class Solution
    {
        public static void Main(string[] args)
        {
            int[] nums = GetValidInput();
            Console.WriteLine("Maximum Absolute Sum of Any Subarray: " + MaxAbsoluteSum(nums));
        }

        public static int[] GetValidInput()
        {
            while (true)
            {
                Console.WriteLine("Enter an array of integers separated by spaces: ");
                string input = Console.ReadLine();
                int[] nums = input.Split(' ').Select(int.Parse).ToArray();
                if (ValidateInput(nums))
                {
                    return nums;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please ensure that 1 <= nums.length <= 10^5 and -10^4 <= nums[i] <= 10^4.");
                }
            }
        }

        public static bool ValidateInput(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 100000) return false;
            foreach (int num in nums)
            {
                if (num < -10000 || num > 10000) return false;
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
