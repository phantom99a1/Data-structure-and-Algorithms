using System.Text.RegularExpressions;

namespace Shortest_Common_Supersequence
{
    /*Given two strings str1 and str2, return the shortest string that has both str1 and str2 as subsequences. 
     * If there are multiple valid strings, return any of them.
    A string s is a subsequence of string t if deleting some number of characters from t (possibly 0) results in the string s.
    
    Constraint:
    1 <= str1.length, str2.length <= 1000
    str1 and str2 consist of lowercase English letters.
     */
    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        public static void Main()
        {
            string str1 = GetValidInput("Enter first string: ");
            string str2 = GetValidInput("Enter second string: ");
            string scs = GetShortestCommonSupersequence(str1, str2);
            Console.WriteLine("Shortest Common Supersequence: " + scs);
            Console.ReadKey();
        }

        public static string GetValidInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine() ?? "";
                if (IsValidInput(input))
                {
                    break;
                }
                Console.WriteLine($"Invalid input. Please enter a valid string consisting of lowercase English letters with length between {minLength} and {maxLength}.");
            }
            return input;
        }

        public static bool IsValidInput(string str)
        {
            return !string.IsNullOrEmpty(str) && str.Length >= minLength && str.Length <= maxLength && MyRegex().IsMatch(str);
        }

        public static string GetShortestCommonSupersequence(string str1, string str2)
        {
            int m = str1.Length, n = str2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int a = m, b = n;
            string scs = "";

            while (a > 0 && b > 0)
            {
                if (str1[a - 1] == str2[b - 1])
                {
                    scs = str1[a - 1] + scs;
                    a--;
                    b--;
                }
                else if (dp[a - 1, b] > dp[a, b - 1])
                {
                    scs = str1[a - 1] + scs;
                    a--;
                }
                else
                {
                    scs = str2[b - 1] + scs;
                    b--;
                }
            }

            while (a > 0)
            {
                scs = str1[a - 1] + scs;
                a--;
            }

            while (b > 0)
            {
                scs = str2[b - 1] + scs;
                b--;
            }

            return scs;
        }

        [GeneratedRegex("^[a-z]+$")]
        private static partial Regex MyRegex();
    }

}
