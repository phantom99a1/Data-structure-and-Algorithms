namespace The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n
{
    /*A happy string is a string that:
    consists only of letters of the set ['a', 'b', 'c'].
    s[i] != s[i + 1] for all values of i from 1 to s.length - 1 (string is 1-indexed).
    For example, strings "abc", "ac", "b" and "abcbabcbcb" are all happy strings and strings "aa", "baa" and "ababbc" 
    are not happy strings.
    Given two integers n and k, consider a list of all happy strings of length n sorted in lexicographical order.
    Return the kth string of this list or return an empty string if there are less than k happy strings of length n.
    
    Constraint:
    1 <= n <= 10
    1 <= k <= 100
     */
    
    public class HappyStringGenerator
    {
        private const int minLength = 1;
        private const int maxLength = 10;
        private const int minValue = 1;
        private const int maxValue = 100;
        public static string GetHappyString(int n, int k)
        {
            var happyStrings = new List<string>();

            void GenerateHappyStrings(int length, string prefix, char lastChar)
            {
                if (length == 0)
                {
                    happyStrings.Add(prefix);
                    return;
                }
                foreach (char c in new[] { 'a', 'b', 'c' })
                {
                    if (c != lastChar)
                    {
                        GenerateHappyStrings(length - 1, prefix + c, c);
                    }
                }
            }

            GenerateHappyStrings(n, "", '\0');
            happyStrings.Sort();

            return k > happyStrings.Count ? "" : happyStrings[k - 1];
        }

        public static void Main()
        {
            int n = 0, k = 0;
            bool isValid = false;

            // Validate n
            while (!isValid)
            {
                Console.Write("Enter n: ");
                string nInput = Console.ReadLine() ?? "";
                if (int.TryParse(nInput, out n))
                {
                    if (n >= minLength && n <= maxLength)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Ensure {minLength} <= n <= {maxLength}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }

            isValid = false;

            // Validate k
            while (!isValid)
            {
                Console.Write("Enter k: ");
                string kInput = Console.ReadLine() ?? "";
                if (int.TryParse(kInput, out k))
                {
                    if (k >= minValue && k <= maxValue)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Ensure {minValue} <= k <= {maxValue}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }

            string result = GetHappyString(n, k);
            Console.WriteLine(string.IsNullOrEmpty(result) ? "Error: k is larger than the number of happy strings." : result);
            Console.ReadKey();
        }
    }
}
