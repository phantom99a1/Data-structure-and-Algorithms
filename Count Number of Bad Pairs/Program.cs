namespace Count_Number_of_Bad_Pairs
{
    /*You are given a 0-indexed integer array nums. A pair of indices (i, j) is a bad pair if i < j and j - i != nums[j] - nums[i].
    Return the total number of bad pairs in nums.
    
     Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
     */
    
    public class Solution
    {
        private const int MinValue = 1;
        private const int MaxValue = 1000000000;
        private const int MinLength = 1;
        private const int MaxLength = 100000;

        public static void Main()
        {
            int[] nums = GetValidInput();
            long result = CountBadPairs(nums);
            Console.WriteLine("Number of bad pairs: " + result);
            Console.ReadKey();
        }

        public static long CountBadPairs(int[] nums)
        {
            int n = nums.Length;
            long badPairs = 0;
            var map = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int diff = i - nums[i];
                if (map.TryGetValue(diff, out int value))
                {
                    badPairs += i - value;
                    map[diff] = ++value;
                }
                else
                {
                    badPairs += i;
                    map[diff] = 1;
                }                
            }

            return badPairs;
        }

        private static int[] GetValidInput()
        {
            Console.WriteLine("Enter the numbers separated by spaces:");
            string input = Console.ReadLine() ?? "";
            string[] stringNums = input.Split(' ');
            var nums = new List<int>();

            foreach (string str in stringNums)
            {
                if (int.TryParse(str, out int num) && num >= MinValue && num <= MaxValue)
                {
                    nums.Add(num);
                }
                else
                {
                    Console.WriteLine($"Invalid number '{str}', please enter valid integers within the range between {MinValue} and {MaxValue}.");
                    return GetValidInput();
                }
            }

            if (nums.Count < MinLength || nums.Count > MaxLength)
            {
                Console.WriteLine($"Invalid input length, please ensure the length between {MinLength} and {MaxLength}.");
                return GetValidInput();
            }

            return [.. nums];
        }
    }
}
