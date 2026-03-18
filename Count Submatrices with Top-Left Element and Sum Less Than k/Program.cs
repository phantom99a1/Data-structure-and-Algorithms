namespace Count_Submatrices_with_Top_Left_Element_and_Sum_Less_Than_k
{
    public class Solution
    {
        int[][] grid;
        public int CountSubmatrices(int[][] grid, int k)
        {
            this.grid = grid;
            var answer = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {

                    grid[i][j] += GetGridNum(i - 1, j) + GetGridNum(i, j - 1) - GetGridNum(i - 1, j - 1);

                    if (grid[i][j] <= k)
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }

        public int GetGridNum(int i, int j)
        {
            if (i < 0 || i >= grid.Length)
            {
                return 0;
            }
            if (j < 0 || j >= grid[0].Length)
            {
                return 0;
            }
            return grid[i][j];
        }
    }
}
