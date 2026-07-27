namespace Maximum_Product_of_Two_Elements_in_an_Array
{
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int m1 = nums[0];
            int m2 = nums[1];
            int max = (m1 - 1) * (m2 - 1);
            for (int i = 2; i < nums.Length; i++)
            {
                int x = (m1 - 1) * (nums[i] - 1);
                int y = (nums[i] - 1) * (m2 - 1);
                if (x > max)
                {
                    m2 = nums[i];
                    max = x;
                }
                if (y > max)
                {
                    m1 = nums[i];
                    max = y;
                }
            }
            return max;
        }
    }
}
