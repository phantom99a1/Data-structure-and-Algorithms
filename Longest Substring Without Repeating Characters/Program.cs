using System.Text.RegularExpressions;

namespace Longest_Substring_Without_Repeating_Characters
{
    /*Given a string s, find the length of the longest substring without duplicate characters.
     
    Constraint:
    0 <= s.length <= 5 * 10^4
    s consists of English letters, digits, symbols and spaces.
     */
    public partial class Solution
    {
        private const int minLength = 0;
        private const int maxLength = 50000;
        public static int LengthOfLongestSubstring(string s)
        {
            var map = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                if (map.TryGetValue(s[end], out int value))
                {
                    start = Math.Max(value + 1, start);
                }
                map[s[end]] = end;
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }

        public static void Main()
        {
            string s;
            while (true)
            {
                Console.WriteLine("Enter a string: ");
                s = Console.ReadLine() ?? "";
                if (IsValidString(s))
                {
                    int result = LengthOfLongestSubstring(s);
                    Console.WriteLine($"The length of the longest substring without repeating characters is: {result}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input! The string must be between {minLength} and {maxLength} characters long and consist of English letters, digits, symbols, and spaces.");
                }
            }
        }

        public static bool IsValidString(string s)
        {
            int length = s.Length;
            return length >= minLength && length <= maxLength && MyRegex().IsMatch(s);
        }

        [GeneratedRegex("^[ -~]+$")]
        private static partial Regex MyRegex();
    }
}
