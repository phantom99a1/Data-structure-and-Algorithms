namespace First_Missing_Positive
{
    /*Given an unsorted integer array nums. Return the smallest positive integer that is not present in nums.
    You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.
    
    Constraint:
    1 <= nums.length <= 10^5
    -2^31 <= nums[i] <= 2^31 - 1
     */
    public class Solution
    {
        public static int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            (nums[j], nums[i]) = (nums[i], nums[j]);
        }
    }

    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        public static void Main()
        {
            int[] nums = GetValidInput("Enter array (comma separated): ");
            int result = Solution.FirstMissingPositive(nums);
            Console.WriteLine("First Missing Positive: " + result);
            Console.ReadKey();
        }

        public static int[] GetValidInput(string prompt)
        {
            int[] input;
            while (true)
            {
                Console.Write(prompt);
                string inputLine = Console.ReadLine() ?? "";
                try
                {
                    input = inputLine.Split(',')
                                     .Select(x => {
                                         if (!IsValidInteger(x)) throw new FormatException();
                                         return int.Parse(x);
                                     })
                                     .ToArray();
                    if (ValidateInput(input)) break;
                    Console.WriteLine("Invalid input. Ensure it meets the constraints.");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid input. Please enter comma-separated integers within the range {int.MinValue} and {int.MaxValue}.");
                }
            }
            return input;
        }

        public static bool IsValidInteger(string value)
        {
            return int.TryParse(value, out int num) && num >= int.MinValue && num <= int.MaxValue;
        }

        public static bool ValidateInput(int[] arr)
        {
            if (arr.Length < minLength || arr.Length > maxLength) return false;
            return arr.All(x => IsValidInteger(x.ToString()));
        }
    }

}
