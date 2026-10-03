namespace Longest_Valid_Parentheses
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            ReadOnlySpan<char> t = s;
            int n = t.Length;
            if (n < 2) return 0;

            int max = 0, bal = 0, cnt = 0, lastReset = -1;
            for (int i = 0; i < n; i++)
            {
                if (t[i] == '(') bal++; else bal--;
                cnt++;
                if (bal == 0) { if (cnt > max) max = cnt; }
                else if (bal < 0) { bal = 0; cnt = 0; lastReset = i; }
            }
            if (n - 1 - lastReset - bal <= max) return max;

            bal = 0; cnt = 0;
            for (int i = n - 1; i > lastReset; i--)
            {
                if (t[i] == ')') bal++; else bal--;
                cnt++;
                if (bal == 0) { if (cnt > max) max = cnt; }
                else if (bal < 0) { bal = 0; cnt = 0; if (i - lastReset - 1 <= max) break; }
            }
            return max;
        }
    }
}
