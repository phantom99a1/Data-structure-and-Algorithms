namespace Find_the_Lexicographically_Largest_String_From_the_Box_I
{
    /*You are given a string word, and an integer numFriends.
    Alice is organizing a game for her numFriends friends. There are multiple rounds in the game, where in each round:
    word is split into numFriends non-empty strings, such that no previous round has had the exact same split.
    All the split words are put into a box.
    Find the lexicographically largest string from the box after all the rounds are finished.
    
     Constraint:
    1 <= word.length <= 5 * 10^3
    word consists only of lowercase English letters.
    1 <= numFriends <= word.length
     */
    public class Solution
    {
        public string AnswerString(string word, int numFriends)
        {
            if (numFriends == 1) return word;

            int n = word.Length;
            string ans = "";

            for (int i = 0; i < n; i++)
            {
                int k = Math.Min(n - i, n - numFriends + 1);
                string candidate = word.Substring(i, k);
                if (string.Compare(ans, candidate) < 0)
                {
                    ans = candidate;
                }
            }

            return ans;
        }
    }
}
