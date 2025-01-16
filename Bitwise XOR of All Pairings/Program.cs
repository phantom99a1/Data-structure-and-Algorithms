namespace Bitwise_XOR_of_All_Pairings
{
    /*You are given two 0-indexed arrays, nums1 and nums2, consisting of non-negative integers. 
    There exists another array, nums3, which contains the bitwise XOR of all pairings of integers between 
    nums1 and nums2 (every integer in nums1 is paired with every integer in nums2 exactly once).
    Return the bitwise XOR of all integers in nums3.
    
    Constraint:
    1 <= nums1.length, nums2.length <= 10^5
    0 <= nums1[i], nums2[j] <= 10^9
     */
    
    public class Program
    {
        private const int MinArrayLength = 1;
        private const int MaxArrayLength = 100000;
        private const int MinValue = 0;
        private const int MaxValue = 1000000000;

        public static void Main()
        {
            int[] nums1 = GetValidInput("Enter array nums1 (comma-separated): ");
            int[] nums2 = GetValidInput("Enter array nums2 (comma-separated): ");

            Console.WriteLine("Bitwise XOR of All Pairings: " + BitwiseXOROfAllPairings(nums1, nums2));
            Console.ReadKey();
        }

        public static bool IsValidInput(string input, out List<string> errorMessages)
        {
            errorMessages = [];

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessages.Add("Input cannot be empty.");
                return false;
            }

            string[] parts = input.Split(',').Select(p => p.Trim()).ToArray();
            if (parts.Length < MinArrayLength || parts.Length > MaxArrayLength)
            {
                errorMessages.Add($"Input length must be between {MinArrayLength} and {MaxArrayLength}.");
            }

            var parsedNumbers = parts.Select(p => int.TryParse(p, out int num) ? num : (int?)null).ToArray();            

            if( parsedNumbers.Any(num => !num.HasValue || num < MinValue || num > MaxValue))
            {
                errorMessages.Add($"All elements must be an integer between {MinValue} and {MaxValue}.");
            }

            
            return errorMessages.Count == 0;
        }

        public static int[] GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages))
                {
                    return input.Split(',').Select(x => int.Parse(x)).ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid input: ");
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                }
            }
        }

        public static long BitwiseXOROfAllPairings(int[] nums1, int[] nums2)
        {
            long xorSum = 0;

            if (nums2.Length % 2 != 0)
            {
                foreach (int num in nums1)
                {
                    xorSum ^= num;
                }
            }

            if (nums1.Length % 2 != 0)
            {
                foreach (int num in nums2)
                {
                    xorSum ^= num;
                }
            }

            return xorSum;
        }
    }
}
