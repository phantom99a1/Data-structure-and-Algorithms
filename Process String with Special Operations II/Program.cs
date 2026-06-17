namespace Process_String_with_Special_Operations_II
{
    public class Solution
    {
        public char ProcessStr(string s, long k)
        {
            long len = 0;

            foreach (char ch in s)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    len++;
                }
                else if (ch == '*')
                {
                    if (len > 0) len--;
                }
                else if (ch == '#')
                {
                    len *= 2;
                }
            }

            if (k >= len) return '.';

            for (int i = s.Length - 1; i >= 0; i--)
            {
                char ch = s[i];

                if (ch >= 'a' && ch <= 'z')
                {
                    if (k == len - 1) return ch;
                    len--;
                }
                else if (ch == '*')
                {
                    len++;
                }
                else if (ch == '#')
                {
                    long prevLen = len / 2;
                    k %= prevLen;
                    len = prevLen;
                }
                else
                {
                    k = len - 1 - k;
                }
            }

            return '.';
        }
    }
}
