namespace Determine_Whether_Matrix_Can_Be_Obtained_By_Rotation
{
    public class Solution
    {
        void Rotate(ref int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = i; j < mat.Length; j++)
                {
                    int temp = mat[i][j];
                    mat[i][j] = mat[j][i];
                    mat[j][i] = temp;
                }
            }
            //Reverse the row
            for (int i = 0; i < mat.Length; i++)
            {
                Array.Reverse(mat[i]);
            }
        }
        //step-1 transpose the matrix
        //two for loop one for row and second for col
        //step-2 reverse the rows
        bool areEqual(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] != target[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //two function areqqueal and rotate
        public bool FindRotation(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            bool equal = true;
            for (int c = 1; c <= 4; c++)
            {
                if (areEqual(mat, target))
                {
                    return true;
                }
                Rotate(ref mat);
            }
            return false;
        }

    }

}
