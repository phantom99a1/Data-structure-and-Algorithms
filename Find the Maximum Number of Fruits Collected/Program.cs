namespace Find_the_Maximum_Number_of_Fruits_Collected
{
    public class Solution
    {
        public int MaxCollectedFruits(int[][] fruits)
        {
            int n = fruits.Length;
            // Sum of three independent best-paths minus the two extra counts of the final cell
            return GetTopLeft(fruits)
                 + GetTopRight(fruits)
                 + GetBottomLeft(fruits)
                 - 2 * fruits[n - 1][n - 1];
        }

        // 1) Straight diagonal from (0,0) to (n-1,n-1)
        private int GetTopLeft(int[][] fruits)
        {
            int n = fruits.Length, sum = 0;
            for (int i = 0; i < n; i++) sum += fruits[i][i];
            return sum;
        }

        // 2) From (0,n-1) downwards through the “upper-triangle” region
        private int GetTopRight(int[][] fruits)
        {
            int n = fruits.Length;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = Enumerable.Repeat(int.MinValue, n).ToArray();
            }
            dp[0][n - 1] = fruits[0][n - 1];

            // allowed step directions: down-left, down, down-right
            var dirs = new (int dx, int dy)[] { (1, -1), (1, 0), (1, 1) };

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    // only process the “strictly above main diagonal” region, plus the end cell
                    if (x >= y && !(x == n - 1 && y == n - 1))
                        continue;

                    int bestPrev = int.MinValue;
                    foreach (var (dx, dy) in dirs)
                    {
                        int px = x - dx, py = y - dy;
                        if (px < 0 || px >= n || py < 0 || py >= n)
                            continue;
                        // stay within the same triangular region
                        if (px < py && py < n - 1 - px)
                            continue;
                        bestPrev = Math.Max(bestPrev, dp[px][py]);
                    }
                    if (bestPrev != int.MinValue)
                    {
                        dp[x][y] = Math.Max(dp[x][y], bestPrev + fruits[x][y]);
                    }
                }
            }
            return dp[n - 1][n - 1];
        }

        // 3) From (n-1,0) rightwards through the “lower-triangle” region
        private int GetBottomLeft(int[][] fruits)
        {
            int n = fruits.Length;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = Enumerable.Repeat(int.MinValue, n).ToArray();
            }
            dp[n - 1][0] = fruits[n - 1][0];

            // allowed step directions: up-right, right, down-right
            var dirs = new (int dx, int dy)[] { (-1, 1), (0, 1), (1, 1) };

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    // only process the “strictly below main diagonal” region, plus the end cell
                    if (x <= y && !(x == n - 1 && y == n - 1))
                        continue;

                    int bestPrev = int.MinValue;
                    foreach (var (dx, dy) in dirs)
                    {
                        int px = x - dx, py = y - dy;
                        if (px < 0 || px >= n || py < 0 || py >= n)
                            continue;
                        // stay within the same triangular region
                        if (py < px && px < n - 1 - py)
                            continue;
                        bestPrev = Math.Max(bestPrev, dp[px][py]);
                    }
                    if (bestPrev != int.MinValue)
                    {
                        dp[x][y] = Math.Max(dp[x][y], bestPrev + fruits[x][y]);
                    }
                }
            }
            return dp[n - 1][n - 1];
        }
    }
}
