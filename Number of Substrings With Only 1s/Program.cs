namespace Number_of_Substrings_With_Only_1s
{
    public class Solution
    {
        public int NumSub(string s)
        {
            int MOD = 1000000007;
            long count = 0, result = 0;

            foreach (char c in s)
            {
                if (c == '1')
                {
                    count++;
                    result = (result + count) % MOD;
                }
                else
                {
                    count = 0;
                }
            }

            return (int)result;
        }
    }
}
