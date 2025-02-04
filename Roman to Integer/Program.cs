using System.Text.RegularExpressions;

namespace Roman_to_Integer
{
    /*Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    Symbol       Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000
    For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, 
    which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
    Roman numerals are usually written largest to smallest from left to right. 
    However, the numeral for four is not IIII. Instead, the number four is written as IV. 
    Because the one is before the five we subtract it making four. 
    The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.
    Given a roman numeral, convert it to an integer.
    
    Constraint:
    1 <= s.length <= 15
    s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
    It is guaranteed that s is a valid roman numeral in the range [1, 3999].
     */

    public partial class Program
    {
        public static void Main()
        {
            string s;
            while (true)
            {
                Console.WriteLine("Enter a Roman numeral:");
                s = Console.ReadLine() ?? "";
                if (ValidateInput(s) || IsValidRomanNumeral(s))
                {
                    break;
                }
            }

            Console.WriteLine("Integer value: " + RomanToInt(s));
            Console.ReadKey();
        }

        public static bool ValidateInput(string s)
        {
            if (s.Length < 1 || s.Length > 15)
            {
                Console.WriteLine("Error: Length of the string must be between 1 and 15.");
                return false;
            }
            if (!MyRegex().IsMatch(s))
            {
                Console.WriteLine("Error: The string must contain only the characters 'I', 'V', 'X', 'L', 'C', 'D', 'M'.");
                return false;
            }
            
            return true;
        }
        public static bool IsValidRomanNumeral(string s)
        {
            // Regex pattern to match valid Roman numerals with proper constraints
            string pattern = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

            if (!Regex.IsMatch(s, pattern))
            {
                Console.WriteLine("Error: Invalid Roman numeral sequence.");
                return false;
            }

            return true;
        }

        public static int RomanToInt(string s)
        {
            var romanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int currentVal = romanMap[s[i]];
                int nextVal = (i + 1 < s.Length) ? romanMap[s[i + 1]] : 0;

                if (nextVal > currentVal)
                {
                    result -= currentVal;
                }
                else
                {
                    result += currentVal;
                }
            }

            return result;
        }

        [GeneratedRegex("^[IVXLCDM]+$")]
        private static partial Regex MyRegex();
    }
}
