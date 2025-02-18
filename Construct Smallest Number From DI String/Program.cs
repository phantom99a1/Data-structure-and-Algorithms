using System.Text.RegularExpressions;

namespace Construct_Smallest_Number_From_DI_String
{
    /*You are given a 0-indexed string pattern of length n consisting of the characters 
    'I' meaning increasing and 'D' meaning decreasing.
    A 0-indexed string num of length n + 1 is created using the following conditions:
    num consists of the digits '1' to '9', where each digit is used at most once.
    If pattern[i] == 'I', then num[i] < num[i + 1].
    If pattern[i] == 'D', then num[i] > num[i + 1].
    Return the lexicographically smallest possible string num that meets the conditions.
    
    Constraint:
    1 <= pattern.length <= 8
    pattern consists of only the letters 'I' and 'D'.
     */
    
    public partial class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter a valid pattern (only letters 'I' and 'D', length 1-8): ");
                string input = Console.ReadLine() ?? "";
                if (!IsValidPattern(input))
                {
                    Console.WriteLine("Invalid pattern. Pattern must only contain letters 'I' and 'D' and be of length 1-8.");
                }
                else
                {
                    Console.WriteLine("Constructed Smallest Number: " + ConstructSmallestNumber(input));
                    Console.ReadKey();
                    break;
                }
            }
        }

        public static bool IsValidPattern(string pattern)
        {
            return MyRegex().IsMatch(pattern);
        }

        public static string ConstructSmallestNumber(string pattern)
        {
            var result = new List<int>();
            var stack = new Stack<int>();
            for (int i = 0; i <= pattern.Length; i++)
            {
                stack.Push(i + 1);
                if (i == pattern.Length || pattern[i] == 'I')
                {
                    while (stack.Count > 0)
                    {
                        result.Add(stack.Pop());
                    }
                }
            }
            return string.Join("", result);
        }

        [GeneratedRegex("^[ID]{1,8}$")]
        private static partial Regex MyRegex();
    }
}
