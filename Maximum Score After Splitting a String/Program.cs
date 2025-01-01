namespace Maximum_Score_After_Splitting_a_String
{
    /*Given a string s of zeros and ones, return the maximum score after splitting the string into two non-empty substrings 
     * (i.e. left substring and right substring).

    The score after splitting a string is the number of zeros in the left substring plus the number of ones in the right substring.
    
    Constraint:
    2 <= s.length <= 500
    The string s consists of characters '0' and '1' only.
     */

    public class Program
    {
        public static void Main()
        {
            int minLength = 2;
            int maxLength = 500;
            Console.WriteLine("Enter a binary string:");
            string s = Console.ReadLine() ?? "";

            if (s.Length < minLength || s.Length > maxLength || !IsBinaryString(s))
            {
                Console.WriteLine($"Invalid input. Please enter a binary string of length between {minLength} and {maxLength}.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Maximum score after splitting the string: " + MaxScore(s));
                Console.ReadKey();
            }
        }

        public static bool IsBinaryString(string s)
        {
            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }

        public static int MaxScore(string s)
        {
            int maxScore = 0;
            for (int i = 1; i < s.Length; i++)
            {
                string left = s[..i];
                string right = s[i..];
                int score = (left.Split('0').Length - 1) + (right.Split('1').Length - 1);
                maxScore = Math.Max(maxScore, score);
            }
            return maxScore;
        }
    }
}
