namespace Cyclically_Rotating_a_Grid
{
    public class Solution
    {
        private (int, int) GetPos(int layer, int m, int n, int idx)
        {
            int lm = m - layer * 2;
            int ln = n - layer * 2;

            int leftEdge = lm - 1;
            int bottomEdge = leftEdge + ln - 1;
            int rightEdge = bottomEdge + lm - 1;

            if (idx >= rightEdge)
                return (layer, layer + ln - 1 - (idx - rightEdge));
            else if (idx >= bottomEdge)
                return (layer + lm - 1 - (idx - bottomEdge), layer + ln - 1);
            else if (idx >= leftEdge)
                return (layer + lm - 1, layer + (idx - leftEdge));
            else
                return (layer + idx, layer);
        }

        public int[][] RotateGrid(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }

            int x = Math.Min(m, n) / 2; // Num of layers

            for (int i = 0; i < x; i++)
            {
                int layerSize = (m - i * 2) * 2 + (n - i * 2) * 2 - 4;

                for (int j = 0; j < layerSize; j++)
                {
                    var before = GetPos(i, m, n, j);
                    var after = GetPos(i, m, n, (j + k) % layerSize);

                    res[after.Item1][after.Item2] = grid[before.Item1][before.Item2];
                }
            }

            return res;
        }
    }
}
