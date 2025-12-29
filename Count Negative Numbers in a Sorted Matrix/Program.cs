namespace Count_Negative_Numbers_in_a_Sorted_Matrix
{
    public class Solution
    {
        public int CountNegatives(int[][] grid)
        {
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = grid[0].Length - 1; j >= 0 && grid[i][j] < 0; j--)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
