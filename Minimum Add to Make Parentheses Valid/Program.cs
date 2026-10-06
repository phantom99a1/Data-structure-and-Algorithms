namespace Minimum_Add_to_Make_Parentheses_Valid
{
    public class Solution
    {
        public int MinAddToMakeValid(string s)
        {
            Stack<char> st = new();
            int ans = 0;
            int cnt = 0;
            foreach (char ch in s)
            {
                if (ch == ')')
                {
                    if (cnt == 0)
                    {
                        ans++;
                    }
                    else
                    {
                        cnt--;
                    }
                }
                else
                {
                    cnt++;
                }
            }
            return cnt + ans;
        }
    }
}
