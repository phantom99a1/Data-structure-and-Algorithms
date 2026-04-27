using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_if_There_is_a_Valid_Path_in_a_Grid
{
    public class Solution
    {
        private readonly (int di, int dj)[] dirs = { (0, -1), (0, 1), (-1, 0), (1, 0) }; // left, right, up, down
        private bool[,] visited;

        public bool HasValidPath(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (m == 0 || n == 0) return false;

            visited = new bool[m, n];

            return Dfs(grid, 0, 0, m, n);
        }

        private bool Dfs(int[][] grid, int i, int j, int m, int n)
        {
            if (i < 0 || i >= m || j < 0 || j >= n || visited[i, j]) return false;
            if (i == m - 1 && j == n - 1) return true;

            visited[i, j] = true;
            int type = grid[i][j];

            // Try moving in all 4 directions if allowed by current and neighbor cell
            bool found = false;

            // Left
            if ((type == 1 || type == 3 || type == 5) && j > 0 && !visited[i, j - 1] &&
                (grid[i][j - 1] == 1 || grid[i][j - 1] == 4 || grid[i][j - 1] == 6))
            {
                found = found || Dfs(grid, i, j - 1, m, n);
            }

            // Right
            if ((type == 1 || type == 4 || type == 6) && j < n - 1 && !visited[i, j + 1] &&
                (grid[i][j + 1] == 1 || grid[i][j + 1] == 3 || grid[i][j + 1] == 5))
            {
                found = found || Dfs(grid, i, j + 1, m, n);
            }

            // Up
            if ((type == 2 || type == 5 || type == 6) && i > 0 && !visited[i - 1, j] &&
                (grid[i - 1][j] == 2 || grid[i - 1][j] == 3 || grid[i - 1][j] == 4))
            {
                found = found || Dfs(grid, i - 1, j, m, n);
            }

            // Down
            if ((type == 2 || type == 3 || type == 4) && i < m - 1 && !visited[i + 1, j] &&
                (grid[i + 1][j] == 2 || grid[i + 1][j] == 5 || grid[i + 1][j] == 6))
            {
                found = found || Dfs(grid, i + 1, j, m, n);
            }

            return found;
        }
    }
}
