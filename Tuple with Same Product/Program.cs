using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tuple_with_Same_Product
{
    /*Given an array nums of distinct positive integers, return the number of tuples (a, b, c, d) 
     such that a * b = c * d where a, b, c, and d are elements of nums, and a != b != c != d.

    Constraint:
    1 <= nums.length <= 1000
    1 <= nums[i] <= 10^4
    All elements in nums are distinct.
    */

    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        private const int minValue = 1;
        private const int maxValue = 10000;
        public static bool IsValidInput(string input, out List<string> errors)
        {
            errors = [];
            int[] nums;

            try
            {
                nums = input.Trim().Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                errors.Add("Input must be a list of integers separated by commas.");
                return false;
            }

            if (nums.Length < minLength || nums.Length > maxLength)
            {
                errors.Add($"Array length must be between {minLength} and {maxLength}.");
            }
            foreach (int num in nums)
            {
                if (num < minValue || num > maxValue)
                {
                    errors.Add($"Each number must be between {minValue} and {maxValue}.");
                }
            }
            if (nums.Length != nums.Distinct().Count())
            {
                errors.Add("All elements in nums must be distinct.");
            }

            return errors.Count == 0;
        }

        public static int CountTuplesWithSameProduct(int[] nums)
        {
            var productMap = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int product = nums[i] * nums[j];
                    if (productMap.ContainsKey(product))
                    {
                        count += 8 * productMap[product];
                        productMap[product]++;
                    }
                    else
                    {
                        productMap[product] = 1;
                    }
                }
            }
            return count;
        }

        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter numbers separated by commas: ");
                string input = Console.ReadLine() ?? "";

                if (IsValidInput(input, out List<string> errors))
                {
                    int[] nums = input.Trim().Split(',').Select(int.Parse).ToArray();
                    int result = CountTuplesWithSameProduct(nums);
                    Console.WriteLine("Number of tuples with the same product: " + result);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Errors:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine("- " + error);
                    }
                }
            }
        }
    }
}
