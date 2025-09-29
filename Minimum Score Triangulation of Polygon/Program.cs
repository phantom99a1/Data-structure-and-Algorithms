namespace Minimum_Score_Triangulation_of_Polygon
{
    public class Solution
    {
        public int MinScoreTriangulation(int[] values)
        {
            int n = values.Length;
            int[,] dp = new int[n, n];

            for (int length = 2; length < n; length++)
            {
                for (int i = 0; i + length < n; i++)
                {
                    int j = i + length;
                    dp[i, j] = int.MaxValue;
                    for (int k = i + 1; k < j; k++)
                    {
                        int score = values[i] * values[j] * values[k] + dp[i, k] + dp[k, j];
                        dp[i, j] = Math.Min(dp[i, j], score);
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
