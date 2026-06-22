namespace Maximum_Number_of_Balloons
{
    public class Solution
    {
        public int MaxNumberOfBalloons(string text)
        {
            var counts = new int[26];
            foreach (var ch in text)
                counts[ch - 'a']++;

            var result = 0;
            while (true)
            {
                if (counts[0] > 0 && counts[1] > 0 && counts[11] > 1 && counts[13] > 0 && counts[14] > 1)
                {
                    result++;
                    counts[0]--;
                    counts[1]--;
                    counts[11] -= 2;
                    counts[13]--;
                    counts[14] -= 2;
                }
                else
                    break;
            }
            return result;
        }
    }
}
