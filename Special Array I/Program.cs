namespace Special_Array_I
{
    /*An array is considered special if every pair of its adjacent elements contains two numbers with different parity.
    You are given an array of integers nums. Return true if nums is a special array, otherwise, return false.
    
    Constraint:
    1 <= nums.length <= 100
    1 <= nums[i] <= 100
     */
    
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 100;
        private const int minValue = 1;
        private const int maxValue = 100;
        public static bool IsSpecialArray(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if ((nums[i] % 2) == (nums[i - 1] % 2))
                {
                    return false;
                }
            }
            return true;
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

            var result = IsSpecialArray(nums);
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
                errors.Add("The length of nums must be between 1 and 100.");
            }

            int[] nums = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i], out int num) && num >= minValue && num <= maxValue)
                {
                    nums[i] = num;
                }
                else
                {
                    errors.Add($"Element {i + 1} must be a integer number between 1 and 100.");
                }
            }

            return (nums, errors);
        }
    }
}
