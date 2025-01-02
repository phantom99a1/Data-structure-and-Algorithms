namespace Count_Vowel_Strings_in_Ranges
{
    /*You are given a 0-indexed array of strings words and a 2D array of integers queries.
    Each query queries[i] = [li, ri] asks us to find the number of strings present in the range li to ri (both inclusive) 
    of words that start and end with a vowel.
    Return an array ans of size queries.length, where ans[i] is the answer to the ith query.
    Note that the vowel letters are 'a', 'e', 'i', 'o', and 'u'.
    
    Constraints:
    1 <= words.length <= 10^5
    1 <= words[i].length <= 40
    words[i] consists only of lowercase English letters.
    sum(words[i].length) <= 3 * 10^5
    1 <= queries.length <= 10^5
    0 <= li <= ri < words.length
     */

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter words separated by space:");
            var inputWord = Console.ReadLine() ?? "";
            string[] words = inputWord.Split(' ');

            if (!ValidateWords(words))
            {
                Console.WriteLine("Input constraints violated.");
                return;
            }

            Console.WriteLine("Enter number of queries:");
            int numQueries = int.Parse(Console.ReadLine() ?? "");

            if (numQueries < 1 || numQueries > 100000)
            {
                Console.WriteLine("Number of queries out of constraints.");
                return;
            }

            var queries = new List<int[]>();
            for (int i = 0; i < numQueries; i++)
            {
                Console.WriteLine($"Enter query {i + 1} (format: li ri):");
                var stringQuery = Console.ReadLine() ?? "";
                string[] queryInput = stringQuery.Split(' ');
                int li = int.Parse(queryInput[0]);
                int ri = int.Parse(queryInput[1]);

                if (li >= 0 && ri < words.Length)
                {
                    queries.Add([li, ri]);
                }
                else
                {
                    Console.WriteLine("Query indices out of bounds.");
                    Console.ReadKey();
                    return;
                }
            }

            int[] result = VowelStrings(words, [.. queries]);
            Console.WriteLine($"Results: [{string.Join(',',result)}]" );
            Console.ReadKey(true);
        }

        public static bool ValidateWords(string[] words)
        {
            int minLength = 1;
            int maxLength = 100000;
            int maxSumLength = 300000;
            if (words.Length < minLength || words.Length > maxLength || words.Sum(w => w.Length) > maxSumLength)
                return false;

            foreach (var word in words)
            {
                if (!IsValid(word))
                    return false;
            }

            return true;
        }

        public static bool IsValid(string word)
        {
            int minWordLength = 1;
            int maxWordLength = 40;
            return word.Length >= minWordLength && word.Length <= maxWordLength && word.All(char.IsLower);
        }

        public static int[] VowelStrings(string[] words, int[][] queries)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            bool IsVowelString(string str)
            {
                return vowels.Contains(str[0]) && vowels.Contains(str[^1]);
            }

            int[] isVowelArray = words.Select(w => IsVowelString(w) ? 1 : 0).ToArray();

            int[] prefixSums = new int[words.Length + 1];
            for (int i = 0; i < words.Length; i++)
            {
                prefixSums[i + 1] = prefixSums[i] + isVowelArray[i];
            }

            int[] results = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int li = queries[i][0];
                int ri = queries[i][1];
                results[i] = prefixSums[ri + 1] - prefixSums[li];
            }

            return results;
        }
    }
}
