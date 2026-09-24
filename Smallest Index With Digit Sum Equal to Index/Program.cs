namespace Smallest_Index_With_Digit_Sum_Equal_to_Index
{
    public class Solution
    {
        public int SmallestIndex(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                int digitSum = 0;

                while (num > 0)
                {
                    digitSum += num % 10;
                    num /= 10;
                }

                if (digitSum == i)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
