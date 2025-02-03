namespace Longest_Strictly_Increasing_or_Strictly_Decreasing_Subarray
{
    /*You are given an array of integers nums. Return the length of the longest subarray of nums which is either 
    strictly increasing or strictly decreasing
    
     Constraint:
    1 <= nums.length <= 50
    1 <= nums[i] <= 50
     */
   
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 50;
        private const int minValue = 1;
        private const int maxValue = 50;
        public static int LongestStrictlyIncreasingOrDecreasingSubarray(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int maxLength = 1;
            int increasingLength = 1;
            int decreasingLength = 1;

            // Check for the longest strictly increasing subarray
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    increasingLength++;
                    decreasingLength = 1;
                }
                else if (nums[i]  < nums[i - 1])
                {
                    decreasingLength++ ;
                    increasingLength = 1;
                }
                else
                {
                    increasingLength = 1;
                    decreasingLength = 1;
                }
                maxLength = Max(maxLength, increasingLength, decreasingLength);
            }

            return maxLength;
        }

        public static void Main()
        {
            int[] nums;
            List<string> errors;

            do
            {
                (nums, errors) = GetValidInput("Enter the numbers (format: num1,num2,...,numN): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = LongestStrictlyIncreasingOrDecreasingSubarray(nums);
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }

        public static (int[], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(',');

            if (parts.Length < minLength || parts.Length > maxLength)
            {
                errors.Add($"The length of nums must be between {minLength} and {maxLength}.");
            }

            int[] nums = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                try
                {
                    int num = int.Parse(parts[i]);
                    if (num >= minValue && num <= maxLength)
                    {
                        nums[i] = num;
                    }
                    else
                    {
                        errors.Add($"Element {i + 1} ({num}) must be a number between {minValue} and {maxValue}.");
                    }
                }
                catch (FormatException)
                {
                    errors.Add($"Element {i + 1} ({parts[i]}) is not a valid integer.");
                }
            }

            return (nums, errors);
        }

        private static int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
    }
}
