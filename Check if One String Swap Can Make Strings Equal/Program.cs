using System.Text.RegularExpressions;

namespace Check_if_One_String_Swap_Can_Make_Strings_Equal
{
    /*You are given two strings s1 and s2 of equal length. A string swap is an operation where you choose two indices in 
    * a string (not necessarily different) and swap the characters at these indices.
    Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings. 
    Otherwise, return false.

    Constraint:
    1 <= s1.length, s2.length <= 100
    s1.length == s2.length
    s1 and s2 consist of only lowercase English letters.
    */

    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100;
        public static void Main()
        {
            string s1 = GetValidInput("Enter the first string input: ");
            string s2 = GetValidInput("Enter the second string input: ", s1.Length);


            bool result = CanBeEqualWithOneSwap(s1, s2);
            Console.WriteLine(result ? "True: One swap can make the strings equal."
                : "False: One swap cannot make the strings equal.");
            Console.ReadKey();
        }

        public static bool CanBeEqualWithOneSwap(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            var differences = new List<int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    differences.Add(i);
                }
            }

            if (differences.Count == 0)
            {
                return true; // Strings are already equal
            }
            else if (differences.Count == 2)
            {
                int i = differences[0];
                int j = differences[1];
                return s1[i] == s2[j] && s1[j] == s2[i];
            }

            return false;
        }

        public static bool IsValidInput(string? input, out List<string> errorMessages, int? length = null)
        {
            errorMessages = [];
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessages.Add("Error: Input must be non-empty");
                return false;
            }
            if (input.Length < minLength || input.Length > maxLength)
            {
                errorMessages.Add($"Error: Input must have the length between {minLength} and {maxLength}");
            }
            if (!MyRegex().IsMatch(input))
            {
                errorMessages.Add("Error: Input must consist of only lowercase English letters");
            }
            if (length.HasValue && input.Length != length)
            {
                errorMessages.Add("Error: The length of input must be equal with the first input");
            }

            return errorMessages.Count == 0;
        }

        public static string GetValidInput(string prompt, int? length = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages, length))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input: ");
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                    Console.ReadKey();
                }
            }
        }

        [GeneratedRegex(@"^[a-z]+$")]
        private static partial Regex MyRegex();
    }
}
