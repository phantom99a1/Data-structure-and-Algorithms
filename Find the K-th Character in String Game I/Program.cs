namespace Find_the_K_th_Character_in_String_Game_I
{
    public class Solution
    {
        public char FindKthCharacter(int k)
        {
            List<int> word = new List<int> { 0 }; // 'a' is 0
            while (word.Count < k)
            {
                int size = word.Count;
                for (int i = 0; i < size; i++)
                {
                    word.Add((word[i] + 1) % 26);
                }
            }
            return (char)('a' + word[k - 1]);
        }
    }
}
