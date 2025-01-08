namespace Count_Prefix_and_Suffix_Pairs_I
{
    /*You are given a 0-indexed string array words.
    Let's define a boolean function isPrefixAndSuffix that takes two strings, str1 and str2:
    isPrefixAndSuffix(str1, str2) returns true if str1 is both a prefix and a suffix of str2, and false otherwise.
    For example, isPrefixAndSuffix("aba", "ababa") is true because "aba" is a prefix of "ababa" and also a suffix, 
    but isPrefixAndSuffix("abc", "abcd") is false.
    Return an integer denoting the number of index pairs (i, j) such that i < j, and isPrefixAndSuffix(words[i], words[j]) is true.
    
    Constraint:
    1 <= words.length <= 50
    1 <= words[i].length <= 10
    words[i] consists only of lowercase English letters.
     */
    
    public class Program
    {
        // Function to check if str1 is both a prefix and a suffix of str2
        public static bool IsPrefixAndSuffix(string str1, string str2)
        {
            return str2.StartsWith(str1) && str2.EndsWith(str1);
        }

        // Function to count prefix and suffix pairs
        public static int CountPrefixSuffixPairs(string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (IsPrefixAndSuffix(words[i], words[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // Function to validate input
        public static void ValidateInput(string[] words)
        {
            int minArrayLength = 1;
            int maxArrayLength = 50;
            int minLength = 1;
            int maxLength = 10;
            if (words.Length < minArrayLength || words.Length > maxArrayLength)
            {
                throw new ArgumentException($"words.length must be between {minArrayLength} and {maxArrayLength}");
            }
            foreach (string word in words)
            {
                if (word.Length < minLength || word.Length > maxLength)
                {
                    throw new ArgumentException($"Each word must be {minLength} to {maxLength}");
                }

                if(word.Any(c => !char.IsLower(c)))
                {
                    throw new ArgumentException("Each word must be lowercase English letters");
                }
            }
        }

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter words separated by space: ");
                string input = Console.ReadLine() ?? "";
                string[] words = input.Split(' ');

                try
                {
                    ValidateInput(words);
                    int result = CountPrefixSuffixPairs(words);
                    Console.WriteLine($"Number of prefix-suffix pairs: {result}");
                    Console.ReadKey();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }            
        }
    }
}
