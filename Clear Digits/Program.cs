using System.Text.RegularExpressions;

namespace Clear_Digits
{
    /*You are given a string s.
    Your task is to remove all digits by doing this operation repeatedly:
    Delete the first digit and the closest non-digit character to its left.
    Return the resulting string after removing all digits.
    
    Constraint:
    1 <= s.length <= 100
    s consists only of lowercase English letters and digits.
    The input is generated such that it is possible to delete all digits.
     */
    

    // Example usage:
    public partial class Program
    {
        public static string ClearDigits(string s)
        {
            string errorMessage = ValidateInput(s) ?? "";
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }
            return RemoveDigits(s);
        }

        private static string? ValidateInput(string s)
        {
            if (s.Length < 1 || s.Length > 100)
            {
                return "Error: String length must be between 1 and 100.";
            }
            if (!MyRegex().IsMatch(s))
            {
                return "Error: String must consist only of lowercase English letters and digits.";
            }
            return null;
        }

        private static string RemoveDigits(string s)
        {
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            var result = new char[stack.Count];
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }
            return new string(result);
        }
        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine() ?? "";

                string result = ClearDigits(input) ?? "";
                if (result.StartsWith("Error:"))
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Result: " + result);
                    break;
                }
            }
        }

        [GeneratedRegex("^[a-z0-9]+$")]
        private static partial Regex MyRegex();
    }
}
