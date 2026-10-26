namespace Count_Islands_With_Total_Value_Divisible_by_K
{
    public class Solution
    {
        public int CountIslands(int[][] grid, int k)
        {
            var result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0) continue;

                    var sum = 0L;
                    CountIslandsDFS(grid, i, j, ref sum);

                    if (sum % k == 0)
                        result++;
                }
            }

            return result;
        }

        private void CountIslandsDFS(int[][] grid, int row, int column, ref long sum)
        {
            if (row < 0 ||
                row >= grid.Length ||
                column < 0 ||
                column >= grid[row].Length ||
                grid[row][column] == 0)
                return;

            sum += grid[row][column];
            grid[row][column] = 0;

            CountIslandsDFS(grid, row + 1, column, ref sum);
            CountIslandsDFS(grid, row - 1, column, ref sum);
            CountIslandsDFS(grid, row, column + 1, ref sum);
            CountIslandsDFS(grid, row, column - 1, ref sum);
        }
    }
}
