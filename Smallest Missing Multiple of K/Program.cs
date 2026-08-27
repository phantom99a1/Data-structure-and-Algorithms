namespace Smallest_Missing_Multiple_of_K
{
    public class Solution
    {
        public int MissingMultiple(int[] nums, int k)
        {
            int temp = k;

            while (nums.Contains(temp))
            {
                if (nums.Contains(temp))
                {
                    temp += k;
                }
            }
            return temp;
        }
    }
}
