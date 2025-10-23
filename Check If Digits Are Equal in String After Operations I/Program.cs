using System.Text;

namespace Check_If_Digits_Are_Equal_in_String_After_Operations_I
{
    public class Solution
    {
        public bool HasSameDigits(string s)
        {
            while (s.Length > 2)
            {
                var next = new StringBuilder();
                for (int i = 0; i < s.Length - 1; i++)
                {
                    int sum = (s[i] - '0' + s[i + 1] - '0') % 10;
                    next.Append(sum);
                }
                s = next.ToString();
            }
            return s[0] == s[1];
        }
    }
}
