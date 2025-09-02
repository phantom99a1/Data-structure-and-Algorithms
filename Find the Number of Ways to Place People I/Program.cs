namespace Find_the_Number_of_Ways_to_Place_People_I
{
    public class Solution
    {
        public int NumberOfPairs(int[][] points)
        {
            Array.Sort(points, (a, b) => a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);
            int ans = 0;
            int n = points.Length;
            int maxY;

            for (int i = 0; i < n; ++i)
            {
                int y1 = points[i][1];
                maxY = int.MinValue;

                for (int j = i + 1; j < n; ++j)
                {
                    int y2 = points[j][1];
                    if (maxY < y2 && y2 <= y1)
                    {
                        maxY = y2;
                        ans++;
                    }
                }
            }

            return ans;
        }
    }
}
