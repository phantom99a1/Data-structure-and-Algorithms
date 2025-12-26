namespace Minimum_Penalty_for_a_Shop
{
    public class Solution
    {
        public int BestClosingTime(string s)
        {
            int pen = 0;
            foreach (char c in s)
                if (c == 'Y') pen++;

            int best = pen, ans = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'Y') pen--;
                else pen++;

                if (pen < best)
                {
                    best = pen;
                    ans = i + 1;
                }
            }
            return ans;
        }
    }
}
