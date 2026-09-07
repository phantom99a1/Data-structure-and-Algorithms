namespace Distinct_Subsequences_II
{
    public class Solution
    {
        public int DistinctSubseqII(string s)
        {
            int MOD = 1_000_000_007;
            int n = s.Length;

            // dp[i] represents the number of distinct subsequences up to index i.
            int[] dp = new int[n + 1];
            dp[0] = 1; // Base case: empty subsequence

            int[] last = new int[26]; // Last occurrence of each character
            Array.Fill(last, -1);

            for (int i = 0; i < n; i++)
            {
                dp[i + 1] = (2 * dp[i]) % MOD; // Double the subsequences by adding s[i]

                int charIndex = s[i] - 'a';
                if (last[charIndex] != -1)
                {
                    dp[i + 1] = (dp[i + 1] - dp[last[charIndex]] + MOD) % MOD; // Remove duplicates
                }

                last[charIndex] = i; // Update last occurrence of the current character
            }

            // Subtract 1 to exclude the empty subsequence
            return (dp[n] - 1 + MOD) % MOD;
        }
    }
}
