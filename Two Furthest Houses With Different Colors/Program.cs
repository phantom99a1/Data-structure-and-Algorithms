public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int dis = 0;
        int n = colors.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (colors[i] != colors[j])
                {
                    dis = Math.Max(dis, j - i);
                }
            }
        }

        return dis;
    }
}