namespace Count_Hills_and_Valleys_in_an_Array
{
    public class Solution
    {
        public int CountHillValley(int[] nums)
        {
            if (nums.Length < 3) return 0;
            int l = 0;
            int i = 1;
            int c = 0;
            for (int r = 2; r < nums.Length; r++)
            {
                if (nums[l] == nums[i])
                {
                    i++;
                    l++;
                }
                else if (nums[r] == nums[i])
                {
                    continue;
                }
                else
                {
                    if ((nums[l] < nums[i] && nums[i] > nums[r]) || (nums[l] > nums[i] && nums[i] < nums[r]))
                    {
                        c++;
                    }

                    l = r - 1;
                    i = r;
                }
            }
            return c;

        }
    }
}
