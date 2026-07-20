namespace Shift_2D_Grid
{
    public class Solution
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            var row = grid.Length;
            var col = grid[0].Length;

            if (k % (row * col) == 0)
                return grid;

            var result = new int[row][];
            for (int i = 0; i < row; i++)
                result[i] = new int[col];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    var newCol = (j + k) % col;
                    var wrapRows = (j + k) / col;
                    var newRow = (i + wrapRows) % row;
                    result[newRow][newCol] = grid[i][j];
                }

            return result;
        }
    }
}
