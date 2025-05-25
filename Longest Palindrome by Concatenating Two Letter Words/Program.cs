namespace Longest_Palindrome_by_Concatenating_Two_Letter_Words
{
    /*You are given an array of strings words. Each element of words consists of two lowercase English letters.
    Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. 
    Each element can be selected at most once. Return the length of the longest palindrome that you can create. 
    If it is impossible to create any palindrome, return 0. A palindrome is a string that reads the same forward and backward.
    
    Constraint:
    1 <= words.length <= 10^5
    words[i].length == 2
    words[i] consists of lowercase English letters.
     */
    public class Solution
    {
        public int LongestPalindrome(string[] words)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();
            int length = 0;
            bool centerUsed = false;

            foreach (string word in words)
            {
                string reversed = new string(word.Reverse().ToArray());
                if (count.ContainsKey(reversed) && count[reversed] > 0)
                {
                    length += 4;
                    count[reversed]--;
                }
                else
                {
                    if (!count.ContainsKey(word)) count[word] = 0;
                    count[word]++;
                }
            }

            foreach (var kvp in count)
            {
                if (kvp.Key[0] == kvp.Key[1] && kvp.Value > 0)
                {
                    length += 2;
                    break;
                }
            }

            return length;
        }
    }
}
