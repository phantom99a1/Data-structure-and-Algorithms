namespace Painting_a_Grid_With_Three_Different_Colors
{
    /*You are given two integers m and n. Consider an m x n grid where each cell is initially white. 
    You can paint each cell red, green, or blue. All cells must be painted.
    Return the number of ways to color the grid with no two adjacent cells having the same color. 
    Since the answer can be very large, return it modulo 10^9 + 7.
    
     Constraint:
    1 <= m <= 5
    1 <= n <= 1000
     */

    public class Solution
    {
        private const int MOD = 1000000007;

        public int ColorTheGrid(int m, int n)
        {
            List<int[]> validStates = new List<int[]>();

            void GenerateStates(List<int> state, int row)
            {
                if (row == m)
                {
                    validStates.Add(state.ToArray());
                    return;
                }
                for (int color = 0; color < 3; color++)
                {
                    if (row == 0 || state[row - 1] != color)
                    {
                        state.Add(color);
                        GenerateStates(state, row + 1);
                        state.RemoveAt(state.Count - 1);
                    }
                }
            }

            GenerateStates(new List<int>(), 0);

            int[,] dp = new int[n, validStates.Count];

            for (int j = 0; j < validStates.Count; j++) dp[0, j] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < validStates.Count; j++)
                {
                    for (int k = 0; k < validStates.Count; k++)
                    {
                        bool valid = true;
                        for (int idx = 0; idx < m; idx++)
                        {
                            if (validStates[j][idx] == validStates[k][idx])
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid) dp[i, j] = (dp[i, j] + dp[i - 1, k]) % MOD;
                    }
                }
            }

            int result = 0;
            for (int j = 0; j < validStates.Count; j++) result = (result + dp[n - 1, j]) % MOD;

            return result;
        }
    }
}
