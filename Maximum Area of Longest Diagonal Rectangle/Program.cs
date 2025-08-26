namespace Maximum_Area_of_Longest_Diagonal_Rectangle
{
    public class Solution
    {
        public int AreaOfMaxDiagonal(int[][] dimensions)
        {
            int maxDiagonalSq = 0;
            int maxArea = 0;

            foreach (var rect in dimensions)
            {
                int length = rect[0], width = rect[1];
                int diagonalSq = length * length + width * width;
                int area = length * width;

                if (diagonalSq > maxDiagonalSq)
                {
                    maxDiagonalSq = diagonalSq;
                    maxArea = area;
                }
                else if (diagonalSq == maxDiagonalSq)
                {
                    maxArea = Math.Max(maxArea, area);
                }
            }

            return maxArea;
        }
    }
}
