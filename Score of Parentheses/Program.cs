namespace Score_of_Parentheses
{
    public class Solution
    {
        public int ScoreOfParentheses(string s)
        {
            var balance = 0;
            var result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') balance++;
                else
                {
                    balance--;
                    if (s[i - 1] == '(')
                        result += 1 << balance;
                }
            }

            return result;
        }
    }
}
