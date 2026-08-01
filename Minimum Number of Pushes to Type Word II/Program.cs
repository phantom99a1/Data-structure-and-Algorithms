namespace Minimum_Number_of_Pushes_to_Type_Word_II
{
    public class Solution
    {
        public int MinimumPushes(string word)
        {
            int[] freq = new int[26];
            foreach (char c in word)
            {
                freq[c - 'a']++;
            }

            Array.Sort(freq, (a, b) => b.CompareTo(a));

            int count = 0;
            int sum = 0;
            foreach (int frequency in freq)
            {
                int presses = (count++ / 8) + 1;
                sum += presses * frequency;
            }

            return sum;
        }
    }
}
