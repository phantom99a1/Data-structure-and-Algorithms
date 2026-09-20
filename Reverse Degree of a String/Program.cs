namespace Reverse_Degree_of_a_String
{
    public class Solution
    {
        public int ReverseDegree(string s)
        {
            int ans = 0;
            for (int i = 1; i <= s.Length; i++)
            {
                ans += (26 - (s[i - 1] - 'a')) * i;
            }
            return ans;
        }
    }
}
