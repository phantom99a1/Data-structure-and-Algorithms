namespace Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary
{
    /*You are given a list of strings of the same length words and a string target.

    Your task is to form target using the given words under the following rules:
        Target should be formed from left to right.
        To form the ith character (0-indexed) of target, you can choose the kth character of the jth string in words 
        if target[i] = words[j][k].
        Once you use the kth character of the jth string of words, you can no longer use the xth character of any string 
        in words where x <= k. In other words, all characters to the left of or at index k become unusuable for every string.
        Repeat the process until you form the string target.
        Notice that you can use multiple characters from the same string in words provided the conditions above are met.

    Return the number of ways to form target from words. Since the answer may be too large, return it modulo 109 + 7.
    
    Constraint:
    1 <= words.length <= 1000
    1 <= words[i].length <= 1000
    All strings in words have the same length.
    1 <= target.length <= 1000
    words[i] and target contain only lowercase English letters.
     */
   
    public class Solution
    {
        public static int NumWays(string[] words, string target)
        {
            const int MOD = 1000000007;
            int m = target.Length;
            int n = words[0].Length;

            long[] dp = new long[m + 1];
            dp[0] = 1;

            int[,] count = new int[n, 26];
            foreach (var word in words)
            {
                for (int j = 0; j < n; j++)
                {
                    count[j, word[j] - 'a']++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    dp[j + 1] = (dp[j + 1] + dp[j] * count[i, target[j] - 'a']) % MOD;
                }
            }

            return (int)dp[m];
        }

        public static bool ValidateInput(string[] words, string target)
        {
            int maxLength = 1000;
            int minLength = 1;
            int wordLength = words[0].Length;
            return words.Length >= minLength && words.Length <= maxLength &&
                   wordLength >= minLength && wordLength <= maxLength &&
                   target.Length >= minLength && target.Length <= maxLength &&
                   words.All(word => word.Length == wordLength && word.All(char.IsLower)) &&
                   target.All(char.IsLower);
        }

        public static void Main()
        {            
            Console.WriteLine("Enter the words array (comma-separated):");
            string wordsInput = Console.ReadLine() ?? "";
            string[] words = wordsInput.Split(',').Select(word => word.Trim()).ToArray();

            Console.WriteLine("Enter the target string:");
            string targetInput = Console.ReadLine() ?? "";

            if (ValidateInput(words, targetInput))
            {
                int result = NumWays(words, targetInput);
                Console.WriteLine("Number of ways to form the target string: " + result);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please follow the constraints.");
                Console.ReadKey();
            }
        }
    }
}
