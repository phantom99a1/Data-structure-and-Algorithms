namespace Make_String_a_Subsequence_Using_Cyclic_Increments
{
    /*You are given two 0-indexed strings str1 and str2.

    In an operation, you select a set of indices in str1, and for each index i in the set, 
    increment str1[i] to the next character cyclically. 
    That is 'a' becomes 'b', 'b' becomes 'c', and so on, and 'z' becomes 'a'.

    Return true if it is possible to make str2 a subsequence of str1 by performing the operation at most once, 
    and false otherwise.

    Note: A subsequence of a string is a new string that is formed from the original string 
    by deleting some (possibly none) of the characters without disturbing 
    the relative positions of the remaining characters.*/

    public class Solution
    {
        public static bool CanMakeSubsequence(string str1, string str2)
        {
            int s1 = 0, s2 = 0;
            while (s1 < str1.Length && s2 < str2.Length)
            {
                if (str1[s1] == str2[s2] || (char)((str1[s1] - 'a' + 1) % 26 + 'a') == str2[s2])
                {
                    s2++;
                }
                s1++;
            }
            return s2 == str2.Length;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the first string (s):");
            string s = Console.ReadLine() ?? "";

            Console.WriteLine("Enter the second string (t):");
            string t = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
            {
                Console.WriteLine("Invalid input. Please ensure both strings are non-empty.");
                Console.ReadKey();
                return;
            }

            bool result = CanMakeSubsequence(s, t);
            Console.WriteLine(result ? $"Yes, {t} can be made a subsequence of {s}." : $"No, {t} cannot be made a subsequence of {s}.");
            Console.ReadKey(true);
        }
    }
}
