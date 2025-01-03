namespace Number_of_Ways_to_Split_Array
{
    /*You are given a 0-indexed integer array nums of length n.
    nums contains a valid split at index i if the following are true:
    The sum of the first i + 1 elements is greater than or equal to the sum of the last n - i - 1 elements.
    There is at least one element to the right of i. That is, 0 <= i < n - 1.
    Return the number of valid splits in nums.
    
     Constraint:
    2 <= nums.length <= 10^5
    -10^5 <= nums[i] <= 10^5
     */
   
    public class Program
    {
        public static int NumOfWaysToSplitArray(int[] nums)
        {
            long totalSum = nums.Sum();
            long leftSum = 0;
            int count = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                leftSum += nums[i];
                long rightSum = totalSum - leftSum;
                if (leftSum >= rightSum)
                {
                    count++;
                }
            }

            return count;
        }

        public static void Main()
        {
            bool isValid = false;
            int[]? nums = null;
            int minLength = 2;
            int maxLength = 10000;
            int minValue = -10000;
            int maxValue = 10000;

            while (!isValid)
            {
                Console.WriteLine("Enter the array of integers (comma-separated): ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"Array must be non-empty and its length must be between {minLength} and {maxLength}.");
                    Console.ReadKey();
                    continue;
                }

                var parsedNums = input.Split(',')
                                      .Select(str => int.TryParse(str, out int num) ? (int?)num : null)
                                      .ToArray();

                if (parsedNums.Length < minLength || parsedNums.Length > maxLength)
                {
                    Console.WriteLine($"Array length must be between {minLength} and {maxLength}.");
                    Console.ReadKey();
                }
                else if (parsedNums.Any(num => num == null || num < minValue || num > maxValue))
                {
                    Console.WriteLine($"All elements must be integers between {minValue} and {maxValue}.");
                    Console.ReadKey();
                }
                else
                {
                    nums = parsedNums.Where(num => num.HasValue).Select(num => num.Value).ToArray();
                    isValid = true;
                }
            }

            Console.WriteLine("Number of ways to split the array: " + NumOfWaysToSplitArray(nums ?? []));
            Console.ReadKey();
        }
    }
}
