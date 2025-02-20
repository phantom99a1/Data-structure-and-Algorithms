namespace Find_Unique_Binary_String
{
    /*Given an array of strings nums containing n unique binary strings each of length n, return a binary string of length 
     n that does not appear in nums. If there are multiple answers, you may return any of them.
    
    Constraint:
    n == nums.length
    1 <= n <= 16
    nums[i].length == n
    nums[i] is either '0' or '1'.
    All the strings of nums are unique.
     */
    
    public class Program
    {
        public static void Main()
        {
            int n = GetValidN();
            List<string> nums = GetValidNums(n);
            string uniqueBinaryString = FindUniqueBinaryString(nums);
            Console.WriteLine($"The unique binary string is: {uniqueBinaryString}");
            Console.ReadKey();
        }

        public static int GetValidN()
        {
            int n;
            while (true)
            {
                Console.Write("Enter the value of n (1 <= n <= 16): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 16)
                    break;
                Console.WriteLine("Invalid input for n. Please enter an integer between 1 and 16.");
            }
            return n;
        }

        public static List<string> GetValidNums(int n)
        {
            var nums = new List<string>();
            while (nums.Count < n)
            {
                Console.Write($"Enter a binary string of length {n}: ");
                string input = Console.ReadLine() ?? "";
                if (input.Length == n && input.All(c => c == '0' || c == '1') && !nums.Contains(input))
                    nums.Add(input);
                else
                    Console.WriteLine("Invalid input. Make sure the string is binary, of correct length, and unique.");
            }
            return nums;
        }

        public static string FindUniqueBinaryString(List<string> nums)
        {
            var set = new HashSet<string>(nums);
            for (int i = 0; i < Math.Pow(2, nums.Count); i++)
            {
                string candidate = Convert.ToString(i, 2).PadLeft(nums.Count, '0');
                if (!set.Contains(candidate))
                    return candidate;
            }
            return "";
        }
    }
}
