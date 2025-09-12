namespace Vowels_Game_in_a_String
{
    public class Solution
    {
        public bool DoesAliceWin(string s)
        {
            foreach (char c in s)
            {
                if ("aeiou".Contains(c))
                {
                    return true; // Alice wins
                }
            }
            return false; // Bob wins
        }
    }
}
