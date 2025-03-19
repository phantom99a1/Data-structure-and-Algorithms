namespace Minimum_Operations_to_Make_Binary_Array_Elements_Equal_to_One_I
{
    /*You are given a binary array nums.
    You can do the following operation on the array any number of times (possibly zero):
    Choose any 3 consecutive elements from the array and flip all of them.
    Flipping an element means changing its value from 0 to 1, and from 1 to 0.
    Return the minimum number of operations required to make all elements in nums equal to 1. If it is impossible, return -1.
    
    Constraint:
    3 <= nums.length <= 10^5
    0 <= nums[i] <= 1
     */
    
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a binary array (comma-separated 0s and 1s): ");
                string input = Console.ReadLine();

                try
                {
                    int[] nums = input.Split(',')
                                      .Select(str =>
                                      {
                                          if (int.TryParse(str.Trim(), out int value))
                                              return value;
                                          throw new FormatException();
                                      })
                                      .ToArray();

                    string validationError = ValidateInput(nums);
                    if (validationError != null)
                    {
                        Console.WriteLine(validationError);
                    }
                    else
                    {
                        int result = MinimumOperationsToOnes(nums);
                        Console.WriteLine($"Minimum operations needed: {result}");
                        break; // Exit the loop after successful execution
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input format. Please enter numbers separated by commas.");
                }
            }
        }

        static int MinimumOperationsToOnes(int[] nums)
        {
            int n = nums.Length;
            int flips = 0;

            for (int i = 0; i <= n - 3; i++)
            {
                // If the current element is 0, flip the next 3 elements
                if (nums[i] == 0)
                {
                    flips++;
                    nums[i] ^= 1;     // Flip current
                    nums[i + 1] ^= 1; // Flip next
                    nums[i + 2] ^= 1; // Flip next-to-next
                }
            }

            // Check the last two elements for 0; if any, return -1
            for (int i = n - 2; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    return -1;
                }
            }

            return flips;
        }
        static string? ValidateInput(int[] nums)
        {
            if (nums.Length < 3 || nums.Length > Math.Pow(10, 5))
            {
                return "Error: Array length must be between 3 and 100,000.";
            }
            if (!nums.All(num => num == 0 || num == 1))
            {
                return "Error: All elements must be either 0 or 1.";
            }
            return null;
        }
    }
}

