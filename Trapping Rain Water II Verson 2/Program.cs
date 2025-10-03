namespace Trapping_Rain_Water_II_Verson_2
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int TrapRainWater(int[][] grid)
        {
            int n = grid.Length, m = grid[0].Length;
            bool[,] vis = new bool[n, m];
            var minHeap = new PriorityQueue<(int row, int col, int height), int>();
            int maxCurrHeight = 0, volume = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                    {
                        minHeap.Enqueue((i, j, grid[i][j]), grid[i][j]);
                        vis[i, j] = true;
                    }
                }
            }

            int[] dirRow = { 0, 0, 1, -1 };
            int[] dirCol = { 1, -1, 0, 0 };

            while (minHeap.Count > 0)
            {
                var (row, col, height) = minHeap.Dequeue();
                maxCurrHeight = Math.Max(maxCurrHeight, height);

                for (int i = 0; i < 4; i++)
                {
                    int nx = row + dirRow[i], ny = col + dirCol[i];
                    if (nx >= 0 && ny >= 0 && nx < n && ny < m && !vis[nx, ny])
                    {
                        vis[nx, ny] = true;
                        if (grid[nx][ny] < maxCurrHeight)
                        {
                            volume += maxCurrHeight - grid[nx][ny];
                        }
                        minHeap.Enqueue((nx, ny, grid[nx][ny]), grid[nx][ny]);
                    }
                }
            }

            return volume;
        }
    }
}
