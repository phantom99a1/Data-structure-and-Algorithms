using System.Text.RegularExpressions;

namespace Remove_All_Occurrences_of_a_Substring
{
    /*Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:
    Find the leftmost occurrence of the substring part and remove it from s.
    Return s after removing all occurrences of part.
    A substring is a contiguous sequence of characters in a string.
    
    Constraint:
    1 <= s.length <= 1000
    1 <= part.length <= 1000
    s​​​​​​ and part consists of lowercase English letters.
     */
    
    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        public static void Main()
        {
            string s = GetValidInput("Enter string s: ");
            string part = GetValidInput("Enter substring part: ");

            Console.WriteLine("Result: " + RemoveOccurrences(s, part));
            Console.ReadKey();
        }

        public static string RemoveOccurrences(string s, string part)
        {
            while (s.Contains(part))
            {
                s = s.Replace(part, "");
            }
            return s;
        }

        public static bool IsValidInput(string input, out List<string> errors)
        {
            errors = [];
            if (input.Length < minLength || input.Length > maxLength)
            {
                errors.Add($"Input length must be between {minLength} and {maxLength}.");
            }
            if (!MyRegex().IsMatch(input))
            {
                errors.Add("Input must consist of lowercase English letters.");
            }
            return errors.Count == 0;
        }

        public static string GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errors))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Errors:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }

        [GeneratedRegex(@"^[a-z]+$")]
        private static partial Regex MyRegex();
    }
}
