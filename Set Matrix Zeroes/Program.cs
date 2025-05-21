namespace Set_Matrix_Zeroes
{
    /**/
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            int rows = matrix.Length, cols = matrix[0].Length;
            bool firstRowZero = false, firstColZero = false;

            // Check if first row or column should be zero
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i][0] == 0) firstColZero = true;
            }
            for (int j = 0; j < cols; j++)
            {
                if (matrix[0][j] == 0) firstRowZero = true;
            }

            // Use first row and column as markers
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // Set matrix elements to zero based on markers
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // Handle first row and column separately
            if (firstColZero)
            {
                for (int i = 0; i < rows; i++) matrix[i][0] = 0;
            }
            if (firstRowZero)
            {
                for (int j = 0; j < cols; j++) matrix[0][j] = 0;
            }
        }
    }
}
