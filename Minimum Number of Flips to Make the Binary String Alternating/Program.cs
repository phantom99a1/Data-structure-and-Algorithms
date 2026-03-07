namespace Minimum_Number_of_Flips_to_Make_the_Binary_String_Alternating
{
    public class Solution
    {
        public int MinFlips(string s)
        {
            int n = s.Length;
            string t = s + s;

            int mis0 = 0;
            int ans = n;

            for (int i = 0; i < 2 * n; i++)
            {

                char expected = (i % 2 == 0) ? '0' : '1';

                if (t[i] != expected) mis0++;

                if (i >= n)
                {
                    int left = i - n;
                    char expLeft = (left % 2 == 0) ? '0' : '1';
                    if (t[left] != expLeft) mis0--;
                }

                if (i >= n - 1)
                {
                    int mis1 = n - mis0;
                    ans = Math.Min(ans, Math.Min(mis0, mis1));
                }
            }

            return ans;
        }
    }
}
