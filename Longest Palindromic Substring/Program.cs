namespace Longest_Palindromic_Substring
{
    /*Given a string s, return the longest palindromic substring in s.
     
    Constraint:
    1 <= s.length <= 1000
    s consist of only digits and English letters.
     */
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 0) return "";

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        public static void Main(string[] args)
        {
            string s;
            while (true)
            {
                Console.WriteLine("Enter a string: ");
                s = Console.ReadLine() ?? "";
                if (IsValidString(s, out List<string> errors))
                {
                    string result = LongestPalindrome(s);
                    Console.WriteLine($"The longest palindromic substring is: {result}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Input invalid: ");
                    foreach(var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            }
        }

        public static bool IsValidString(string s, out List<string> errorMessages)
        {
            errorMessages = [];
            if(s.Length < minLength || s.Length > maxLength)
            {
                errorMessages.Add($"Error: Input string length must be between {minLength} and {maxLength}.");
            }

            if(s.Any(x => !char.IsLetterOrDigit(x))){
                errorMessages.Add("Error: Input string must consist only of digits and English letters.");
            }

            return errorMessages.Count == 0;
        }
    }
}
