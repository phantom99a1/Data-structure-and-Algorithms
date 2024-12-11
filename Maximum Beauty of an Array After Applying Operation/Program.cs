namespace Maximum_Beauty_of_an_Array_After_Applying_Operation
{
    /*You are given a 0-indexed array nums and a non-negative integer k.

    In one operation, you can do the following:

    Choose an index i that hasn't been chosen before from the range [0, nums.length - 1].
    Replace nums[i] with any integer from the range [nums[i] - k, nums[i] + k].
    The beauty of the array is the length of the longest subsequence consisting of equal elements.

    Return the maximum possible beauty of the array nums after applying the operation any number of times.

    Note that you can apply the operation to each index only once.

    A subsequence of an array is a new array generated from the original array 
    by deleting some elements (possibly none) without changing the order of the remaining elements.*/   
    public class Program
    {
        public static void Main()
        {
            int[] nums = ParseArrayInput("Enter the numbers in the array (comma-separated): ");
            int k = ParseNumberInput("Enter the value of k: ");
            int result = MaximumBeauty(nums, k);
            Console.WriteLine($"The maximum beauty of the array is: {result}");
            Console.ReadKey();
        }

        public static int[] ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input;
            do
            {
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input.Split(',').Select(int.Parse).ToArray();
        }

        public static int ParseNumberInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input;
            int number;
            do
            {
                input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out number) || number < 0)
                {
                    Console.WriteLine("Input must be a valid number. Please try again.");
                    Console.ReadKey(true);
                }
            } while (!int.TryParse(input, out number) || number < 0);
            return number;
        }

        public static int MaximumBeauty(int[] nums, int k)
        {
            Array.Sort(nums);
            int maxBeauty = 0;
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                while (nums[right] - nums[left] > 2 * k)
                {
                    left++;
                }
                maxBeauty = Math.Max(maxBeauty, right - left + 1);
            }

            return maxBeauty;
        }
    }

}
