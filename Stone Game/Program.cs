namespace Stone_Game
{
    public class Solution
    {
        public bool StoneGame(int[] piles)
        {
            int[] dp = new int[piles.Length];
            Array.Copy(piles, dp, piles.Length);

            for (int d = 1; d < piles.Length; d++)
                for (int i = 0; i < piles.Length - d; i++)
                    dp[i] = Math.Max(piles[i] - dp[i + 1], piles[i + d] - dp[i]);
            return dp[0] > 0;
        }
    }
}
