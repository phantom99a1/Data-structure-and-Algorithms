namespace Minimum_Changes_To_Make_Alternating_Binary_String
{
    public class Solution
    {
        public int MinOperations(string s)
        {
            int n, c = 0, j = 0;
            for (n = 0; n < s.Length; n++, j ^= 1)
            {
                if (s[n] - '0' == j) c++;
            }
            return Math.Min(c, n - c);
        }
    }
}
