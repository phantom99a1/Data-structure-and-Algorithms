namespace Count_Submatrices_With_All_Ones
{
    public class Solution
    {
        public int NumSubmat(int[][] mat)
        {
            int rows = mat.Length, cols = mat[0].Length;
            int result = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        mat[i][j] += mat[i][j - 1];
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int minWidth = mat[i][j];
                    for (int k = i; k >= 0 && mat[k][j] > 0; k--)
                    {
                        minWidth = Math.Min(minWidth, mat[k][j]);
                        result += minWidth;
                    }
                }
            }

            return result;
        }
    }
}
