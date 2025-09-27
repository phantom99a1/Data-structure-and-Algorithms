namespace Largest_Triangle_Area
{
    public class Solution
    {
        public double LargestTriangleArea(int[][] points)
        {
            double maxArea = 0;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        int x1 = points[i][0], y1 = points[i][1];
                        int x2 = points[j][0], y2 = points[j][1];
                        int x3 = points[k][0], y3 = points[k][1];
                        double area = Math.Abs(
                            x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)
                        ) / 2.0;
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }
            return maxArea;
        }
    }
}
