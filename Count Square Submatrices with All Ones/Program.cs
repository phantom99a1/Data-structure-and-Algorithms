namespace Count_Square_Submatrices_with_All_Ones
{
    public class Solution
    {
        public int CountSquares(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1 && i > 0 && j > 0)
                    {
                        matrix[i][j] = Math.Min(
                            Math.Min(matrix[i - 1][j], matrix[i][j - 1]),
                            matrix[i - 1][j - 1]
                        ) + 1;
                    }
                    count += matrix[i][j];
                }
            }

            return count;
        }
    }
}
