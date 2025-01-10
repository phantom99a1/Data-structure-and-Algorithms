using System.Text.RegularExpressions;

namespace Word_Subsets
{
    /*You are given two string arrays words1 and words2.
    A string b is a subset of string a if every letter in b occurs in a including multiplicity.
    For example, "wrr" is a subset of "warrior" but is not a subset of "world".
    A string a from words1 is universal if for every string b in words2, b is a subset of a.
    Return an array of all the universal strings in words1. You may return the answer in any order.
    
    Constraint:
    1 <= words1.length, words2.length <= 10^4
    1 <= words1[i].length, words2[i].length <= 10
    words1[i] and words2[i] consist only of lowercase English letters.
    All the strings of words1 are unique.
     */
    
    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 10;
        private const int minArrayLength = 1;
        private const int maxArrayLength = 10000;
        public static bool IsValidInput(string input, out List<string> errorMessages)
        {
            errorMessages = new List<string>();
            string[] words = input.Split(' ');
            if (words.Length < minArrayLength || words.Length > maxArrayLength)
            {
                errorMessages.Add($"The number of words must be between {minArrayLength} and {maxArrayLength}.");
            }
            foreach (string word in words)
            {
                if (word.Length < minLength || word.Length > maxLength)
                {
                    errorMessages.Add($"Each word must have a length between {minLength} and {maxLength}.");
                }
                if (!MyRegex().IsMatch(word))
                {
                    errorMessages.Add("Each word must consist only of lowercase English letters.");
                }
            }
            return errorMessages.Count == 0;
        }

        public static List<string> GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages))
                {
                    return new List<string>(input.Split(' '));
                }
                else
                {
                    Console.WriteLine("Invalid input: ");
                    foreach(var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                    Console.ReadKey();
                }
            }
        }

        public static List<string> WordSubsets(List<string> words1, List<string> words2)
        {
            int[] maxCount = new int[26];
            foreach (var word in words2)
            {
                int[] count = CountChars(word);
                for (int i = 0; i < 26; i++)
                {
                    maxCount[i] = Math.Max(maxCount[i], count[i]);
                }
            }

            List<string> result = new List<string>();
            foreach (var word in words1)
            {
                int[] count = CountChars(word);
                bool isUniversal = true;
                for (int i = 0; i < 26; i++)
                {
                    if (count[i] < maxCount[i])
                    {
                        isUniversal = false;
                        break;
                    }
                }
                if (isUniversal)
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public static int[] CountChars(string word)
        {
            int[] count = new int[26];
            foreach (var ch in word)
            {
                count[ch - 'a']++;
            }
            return count;
        }

        public static void Main()
        {
            List<string> words1 = GetValidInput("Enter words1: ");
            List<string> words2 = GetValidInput("Enter words2: ");

            List<string> result = WordSubsets(words1, words2);
            Console.WriteLine($"Result: [{string.Join(", ", result)}]");
            Console.ReadKey();
        }

        [GeneratedRegex("^[a-z]+$")]
        private static partial Regex MyRegex();
    }
}
