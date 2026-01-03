namespace Number_of_Ways_to_Paint_N___3_Grid
{
    public class Solution
    {
        public int NumOfWays(int n)
        {
            const long MOD = 1000000007;

            // Base case: n = 1
            // 6 patterns of type ABA and 6 patterns of type ABC
            long aba = 6;
            long abc = 6;

            for (int i = 1; i < n; i++)
            {
                long prev_aba = aba;
                long prev_abc = abc;

                // Transition logic derived from the tables:
                // An ABA row generates 3 ABA and 2 ABC next rows
                // An ABC row generates 2 ABA and 2 ABC next rows
                aba = (3 * prev_aba + 2 * prev_abc) % MOD;
                abc = (2 * prev_aba + 2 * prev_abc) % MOD;
            }

            // Final count is the sum of both pattern types at row n
            return (int)((aba + abc) % MOD);
        }
    }
}
