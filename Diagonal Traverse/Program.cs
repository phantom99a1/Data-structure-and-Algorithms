namespace Diagonal_Traverse
{
    public class Solution
    {
        public int[] FindDiagonalOrder(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            List<int> result = new List<int>();

            for (int k = 0; k < m + n - 1; k++)
            {
                List<int> intermediate = new List<int>();
                int i = k < n ? 0 : k - n + 1;
                int j = k < n ? k : n - 1;

                while (i < m && j >= 0)
                {
                    intermediate.Add(mat[i][j]);
                    i++;
                    j--;
                }

                if (k % 2 == 0)
                {
                    intermediate.Reverse();
                }

                result.AddRange(intermediate);
            }

            return result.ToArray();
        }
    }
}
