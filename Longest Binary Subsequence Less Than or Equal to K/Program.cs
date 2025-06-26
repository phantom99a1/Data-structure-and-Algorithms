namespace Longest_Binary_Subsequence_Less_Than_or_Equal_to_K
{
    public class Solution
    {
        public int LongestSubsequence(string s, int k)
        {
            int ans = 0;
            long val = 0, power = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    ans++;
                }
                else
                {
                    if (power <= k && val + power <= k)
                    {
                        val += power;
                        ans++;
                    }
                }
                if (power <= k) power *= 2;
            }
            return ans;
        }
    }
}
