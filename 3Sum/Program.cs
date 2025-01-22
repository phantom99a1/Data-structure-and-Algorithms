namespace _3Sum
{
    /*Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
     * such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    Notice that the solution set must not contain duplicate triplets.
    
    Constraint:
    3 <= nums.length <= 3000
    -10^5 <= nums[i] <= 10^5
     */
    public class Program
    {
        private const int minLength = 3;
        private const int maxLength = 3000;
        private const int minValue = -100000;
        private const int maxValue = 100000;
        public static void Main()
        {
            int[] nums;
            List<string> errors;

            do
            {
                (nums, errors) = GetValidInput("Enter the array (elements separated by ','): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = ThreeSum(nums);
            Console.WriteLine("3Sum Result:");
            Console.WriteLine("[" + string.Join(",", result.Select(triplet => "[" + string.Join(",", triplet) + "]")) + "]");
            Console.ReadKey();
        }

        public static (int[], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            int[] nums;
            try
            {
                nums = input.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in input.");
                return (Array.Empty<int>(), errors);
            }

            if (nums.Length < minLength || nums.Length > maxLength)
            {
                errors.Add($"The length of the array must be between {minLength} and {maxLength}.");
            }
            if (nums.Any(num => num < minValue || num > maxLength))
            {
                errors.Add($"Each number must be between {minValue} and {maxLength}.");
            }

            return (nums, errors);
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicate elements

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add([nums[i], nums[left], nums[right]]);
                        while (left < right && nums[left] == nums[left + 1]) left++; // Skip duplicate elements
                        while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicate elements
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
    }
}
