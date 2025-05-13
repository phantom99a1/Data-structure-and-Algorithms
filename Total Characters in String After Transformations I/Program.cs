namespace Total_Characters_in_String_After_Transformations_I
{
    /*You are given a string s and an integer t, representing the number of transformations to perform. In one transformation, 
    every character in s is replaced according to the following rules:
    If the character is 'z', replace it with the string "ab". Otherwise, replace it with the next character in the alphabet. 
    For example, 'a' is replaced with 'b', 'b' is replaced with 'c', and so on.
    Return the length of the resulting string after exactly t transformations.
    Since the answer may be very large, return it modulo 10^9 + 7.
    
     Constraint:
    1 <= s.length <= 10^5
    s consists only of lowercase English letters.
    1 <= t <= 10^5
     */
    public class Solution
    {
        const int MOD = 1000000007;
        public int LengthAfterTransformations(string s, int t)
        {
            long[,] dp = new long[26, t + 1];

            for (int i = 0; i < 26; i++)
                dp[i, 0] = 1;

            for (int i = 1; i <= t; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j == 25)
                        dp[j, i] = (dp[0, i - 1] + dp[1, i - 1]) % MOD;
                    else
                        dp[j, i] = dp[j + 1, i - 1];
                }
            }

            long result = 0;
            foreach (char c in s)
            {
                int idx = c - 'a';
                result = (result + dp[idx, t]) % MOD;
            }

            return (int)result;
        }
    }
}
