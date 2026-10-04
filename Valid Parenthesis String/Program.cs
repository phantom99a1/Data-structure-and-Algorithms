namespace Valid_Parenthesis_String
{
    public class Solution
    {
        public bool CheckValidString(string s)
        {
            int low = 0;
            int high = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    low++;
                    high++;
                }
                else if (s[i] == ')')
                {
                    low--;
                    high--;
                }
                else
                {
                    low--;
                    high++;
                }

                if (high < 0)
                    return false;

                if (low < 0)
                    low = 0;
            }

            return low == 0;
        }
    }
}
