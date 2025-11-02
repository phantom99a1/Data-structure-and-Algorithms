namespace Count_Unguarded_Cells_in_the_Grid
{
    public class Solution
    {
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            int[,] grid = new int[m, n];
            const int GUARD = 1, WALL = 2, GUARDED = 3;

            foreach (var g in guards) grid[g[0], g[1]] = GUARD;
            foreach (var w in walls) grid[w[0], w[1]] = WALL;

            int[][] directions = new int[][] {
            new int[] {0, 1}, new int[] {0, -1},
            new int[] {1, 0}, new int[] {-1, 0}
        };

            foreach (var g in guards)
            {
                foreach (var dir in directions)
                {
                    int r = g[0] + dir[0], c = g[1] + dir[1];
                    while (r >= 0 && r < m && c >= 0 && c < n && grid[r, c] != WALL && grid[r, c] != GUARD)
                    {
                        if (grid[r, c] == 0) grid[r, c] = GUARDED;
                        r += dir[0];
                        c += dir[1];
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == 0) count++;
                }
            }

            return count;
        }
    }
}
