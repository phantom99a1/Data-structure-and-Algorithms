namespace Check_if_Array_Is_Sorted_and_Rotated
{
    /*Given an array nums, return true if the array was originally sorted in non-decreasing order, 
     then rotated some number of positions (including zero). Otherwise, return false.
    There may be duplicates in the original array.
    Note: An array A rotated by x positions results in an array B of the same length such that 
    A[i] == B[(i+x) % A.length], where % is the modulo operation.
    
     Constraint:
    1 <= nums.length <= 100
    1 <= nums[i] <= 100
     */
    
    public class Solution
    {
        public static bool CheckIfSortedAndRotated(int[] nums)
        {
            int k = 0;
            int n = nums.Length;
            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    k++;
                }
            }
            if (k > 1 || (k == 1 && nums[0] < nums[n - 1]))
            {
                return false;
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

            var result = CheckIfSortedAndRotated(nums);
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }

        public static (int[], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(',');

            if (parts.Length < 1 || parts.Length > 100)
            {
                errors.Add("The length of nums must be between 1 and 100.");
            }

            int[] nums = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                try
                {
                    int num = int.Parse(parts[i]);
                    if (num >= 1 && num <= 100)
                    {
                        nums[i] = num;
                    }
                    else
                    {
                        errors.Add($"Element {i + 1} ({num}) must be a number between 1 and 100.");
                    }
                }
                catch (FormatException)
                {
                    errors.Add($"Element {i + 1} ({parts[i]}) is not a valid integer.");
                }
            }

            return (nums, errors);
        }
    }
}
