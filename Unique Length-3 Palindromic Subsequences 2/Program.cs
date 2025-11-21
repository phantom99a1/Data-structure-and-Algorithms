namespace Unique_Length_3_Palindromic_Subsequences_2
{
    public class Solution
    {
        public int CountPalindromicSubsequence(string s)
        {
            int result = 0;
            for (char c = 'a'; c <= 'z'; c++)
            {
                int first = s.IndexOf(c);
                int last = s.LastIndexOf(c);
                if (first != -1 && last != -1 && first < last)
                {
                    HashSet<char> middle = new HashSet<char>();
                    for (int i = first + 1; i < last; i++)
                    {
                        middle.Add(s[i]);
                    }
                    result += middle.Count;
                }
            }
            return result;
        }
    }
}
