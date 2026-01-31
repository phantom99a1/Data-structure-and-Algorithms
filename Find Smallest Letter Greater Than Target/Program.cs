namespace Find_Smallest_Letter_Greater_Than_Target
{
    public class Solution
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            int[] freq = new int[26];
            for (int i = 0; i < letters.Length; i++)
                freq[letters[i] - 'a']++;
            int th = target - 'a';
            for (int i = 0; i < freq.Length; i++)
                if (i > th && freq[i] != 0)
                    return (char)(i + 'a');
            return letters[0];
        }
    }
}
