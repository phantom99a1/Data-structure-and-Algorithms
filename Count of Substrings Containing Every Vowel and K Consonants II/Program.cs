using System.Text.RegularExpressions;

namespace Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II
{
    /*You are given a string word and a non-negative integer k.
    Return the total number of substrings of word that contain every vowel ('a', 'e', 'i', 'o', and 'u') 
    at least once and exactly k consonants.
    
    Constraint:
    5 <= word.length <= 2 * 10^5
    word consists only of lowercase English letters.
    0 <= k <= word.length - 5
     */
    
    public partial class Program
    {
        private const int minLength = 5;
        private const int maxLength = 200000;
        private const int minValue = 0;
        public static bool IsValidInput(string word, int k, out List<string> errors)
        {
            errors = [];
            if (word.Length < minLength || word.Length > maxLength)
            {
                errors.Add($"Word length must be between {minLength} and {maxLength}.");
            }
            if (!MyRegex().IsMatch(word))
            {
                errors.Add("Word must only consist of lowercase English letters.");
            }
            if (k < minValue || k > word.Length - 5)
            {
                errors.Add($"k must be in the range {minValue} <= k <= {word.Length - 5}.");
            }
            return errors.Count == 0;
        }

        public static long CountOfSubstrings(string word, int k)
        {
            int[,] frequencies = new int[2, 128];
            foreach (char vowel in "aeiou")
                frequencies[0, vowel] = 1;

            long response = 0;
            int currentK = 0, vowels = 0, extraLeft = 0;

            for (int right = 0, left = 0; right < word.Length; right++)
            {
                char rightChar = word[right];

                if (frequencies[0, rightChar] == 1)
                {
                    if (++frequencies[1, rightChar] == 1) vowels++;
                }
                else
                {
                    currentK++;
                }

                while (currentK > k)
                {
                    char leftChar = word[left];
                    if (frequencies[0, leftChar] == 1)
                    {
                        if (--frequencies[1, leftChar] == 0) vowels--;
                    }
                    else
                    {
                        currentK--;
                    }
                    left++;
                    extraLeft = 0;
                }

                while (vowels == 5 && currentK == k && left < right && frequencies[0, word[left]] == 1 && frequencies[1, word[left]] > 1)
                {
                    extraLeft++;
                    frequencies[1, word[left]]--;
                    left++;
                }

                if (currentK == k && vowels == 5)
                {
                    response += (1 + extraLeft);
                }
            }

            return response;
        }

        public static void Main()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine() ?? "";
            Console.Write("Enter k: ");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("k must be a valid integer.");
                return;
            }

            if (!IsValidInput(word, k, out var errors))
            {
                Console.WriteLine("Input errors:");
                errors.ForEach(Console.WriteLine);
            }
            else
            {
                long result = CountOfSubstrings(word, k);
                Console.WriteLine($"Count of valid substrings: {result}");
                Console.ReadKey();
            }
        }

        [GeneratedRegex("^[a-z]+$")]
        private static partial Regex MyRegex();
    }
}
