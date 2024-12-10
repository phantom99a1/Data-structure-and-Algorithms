namespace Find_Longest_Special_Substring_That_Occurs_Thrice_I
{
    /*You are given a string s that consists of lowercase English letters.

    A string is called special if it is made up of only a single character. 
    For example, the string "abc" is not special, whereas the strings "ddd", "zz", and "f" are special.

    Return the length of the longest special substring of s which occurs at least thrice, 
    or -1 if no special substring occurs at least thrice.

    A substring is a contiguous non-empty sequence of characters within a string. */
    public class Program
    {
        public static void Main()
        {
            string s = GetInput("Enter the string: ");
            int result = LongestSpecialSubstring(s);
            Console.WriteLine($"The length of the longest special substring that occurs at least thrice is: {result}");
            Console.ReadKey();
        }

        public static string GetInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    Console.ReadKey();
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        public static int LongestSpecialSubstring(string s)
        {
            int n = s.Length;
            int l = 0, r = n;

            Func<int, bool> check = (x) =>
            {
                int[] cnt = new int[26];
                for (int i = 0; i < n;)
                {
                    int j = i + 1;
                    while (j < n && s[j] == s[i])
                    {
                        j++;
                    }
                    int k = s[i] - 'a';
                    cnt[k] += Math.Max(0, j - i - x + 1);
                    if (cnt[k] >= 3)
                    {
                        return true;
                    }
                    i = j;
                }
                return false;
            };

            while (l < r)
            {
                int mid = (l + r + 1) >> 1;
                if (check(mid))
                {
                    l = mid;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return l == 0 ? -1 : l;
        }
    }

}
