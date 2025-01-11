using System.Text.RegularExpressions;

namespace Construct_K_Palindrome_Strings
{
    /*Given a string s and an integer k, return true if you can use all the characters in s to construct 
     k palindrome strings or false otherwise.
     
     Constraint:
    1 <= s.length <= 10^5
    s consists of lowercase English letters.
    1 <= k <= 10^5
     */
    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        private const int minValue = 1;
        private const int maxValue = 100000;
        public static bool CanConstruct(string s, int k)
        {
            int[] charCount = new int[26];
            foreach(char c in s)
            {
                charCount[c - 'a']++;
            }
            int oddCount = 0;
            foreach(int count in charCount)
            {
                if(count % 2 == 1)
                {
                    oddCount++;
                }
            }
            return oddCount <= k && k <= s.Length;
        }

        public static bool IsValidInput(string s, out List<string> errorMessages)
        {
            errorMessages = [];
            if(string.IsNullOrWhiteSpace(s) || s.Length < minLength || s.Length > maxLength)
            {
                errorMessages.Add($"The input string must be non-empty and between {minLength} and {maxLength}");
            }
            if (!MyRegex().IsMatch(s))
            {
                errorMessages.Add("Each word must consist only of lowercase English letters.");
            }
            return errorMessages.Count == 0;
        }

        public static bool IsValidInput(string input, out string errorMessage)
        {
            errorMessage = "";
            if (!int.TryParse(input, out int k) || k < minValue || k > maxValue)
            {
                errorMessage = $"The input integer must be non-empty and integer, between {minValue} and {maxValue}";
            }
            return errorMessage.Length == 0;
        }

        public static string GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input string: ");
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                    Console.ReadKey();
                }
            }
        }

        public static int GetValidInputInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if(IsValidInput(input, out string errorMessage))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine(errorMessage);
                    Console.ReadKey();
                }
            }
        }

        public static void Main()
        {
            var inputString = GetValidInput("Enter the string s: ");
            var inputInteger = GetValidInputInteger("Enter the integer k: ");
            var result = CanConstruct(inputString, inputInteger);
            Console.WriteLine($"Result: {result}");
            Console.ReadKey(true);
        }

        [GeneratedRegex("^[a-z]+$")]
        private static partial Regex MyRegex();
    }
}
