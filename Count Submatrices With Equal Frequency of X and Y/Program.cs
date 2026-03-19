namespace Count_Submatrices_With_Equal_Frequency_of_X_and_Y
{
    public class Solution
    {
        public int NumberOfSubmatrices(char[][] grid)
        {
            int result = 0;
            var colsX = new int[grid[0].Length];
            var colsY = new int[grid[0].Length];
            for (int y = 0; y < grid.Length; y++)
            {
                var curX = 0;
                var curY = 0;
                for (int x = 0; x < grid[y].Length; x++)
                {
                    colsX[x] += grid[y][x] == 'X' ? 1 : 0;
                    curX += colsX[x];
                    colsY[x] += grid[y][x] == 'Y' ? 1 : 0;
                    curY += colsY[x];
                    if (curX == curY && curX > 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
