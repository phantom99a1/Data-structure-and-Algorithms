namespace Unique_Length_3_Palindromic_Subsequences
{
    /*Given a string s, return the number of unique palindromes of length three that are a subsequence of s.
    Note that even if there are multiple ways to obtain the same subsequence, it is still only counted once.
    A palindrome is a string that reads the same forwards and backwards.
    A subsequence of a string is a new string generated from the original string with some characters 
    (can be none) deleted without changing the relative order of the remaining characters.
    For example, "ace" is a subsequence of "abcde".
    
    Constraint:
        3 <= s.length <= 10^5
        s consists of only lowercase English letters.
     */
    
    public partial class Program
    {
        public static void Main()
        {
            Console.Write("Enter a string: ");
            string s = Console.ReadLine() ?? "";
            int minLength = 3;
            int maxLength = 100000;

            if (s.Length < minLength || s.Length > maxLength)
            {
                Console.WriteLine($"String length must be between {minLength} and {maxLength} characters.");
                Console.ReadKey();
            }
            else if (!MyRegex().IsMatch(s))
            {
                Console.WriteLine("String must contain only lowercase English letters.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Number of unique length-3 palindromic subsequences: " + CountPalindromicSubsequences(s));
                Console.ReadKey();
            }
        }

        public static int CountPalindromicSubsequences(string s)
        {
            int count = 0;
            var charSet = new HashSet<char>(s);
            foreach (char c in charSet)
            {
                int l = s.IndexOf(c);
                int r = s.LastIndexOf(c);
                if (r - l > 1)
                {
                    var middleChars = new HashSet<char>();
                    for (int i = l + 1; i < r; i++)
                    {
                        middleChars.Add(s[i]);
                    }
                    count += middleChars.Count;
                }
            }
            return count;
        }

        [System.Text.RegularExpressions.GeneratedRegex("^[a-z]+$")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();
    }
}