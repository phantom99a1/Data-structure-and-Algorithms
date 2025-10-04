namespace Container_With_Most_Water
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int h = Math.Min(height[left], height[right]);
                int w = right - left;
                maxArea = Math.Max(maxArea, h * w);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }
    }
}
