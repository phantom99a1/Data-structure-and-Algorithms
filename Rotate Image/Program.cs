namespace Rotate_Image
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            // Step 1: Transpose
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // Step 2: Reverse each row
            for (int row = 0; row < n; row++)
            {
                int right = n - 1, left = 0;
                while (left < right)
                {
                    int temp = matrix[row][left];
                    matrix[row][left] = matrix[row][right];
                    matrix[row][right] = temp;

                    right--; left++;
                }
            }
        }


    }
}
