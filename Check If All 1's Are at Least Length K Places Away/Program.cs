namespace Check_If_All_1_s_Are_at_Least_Length_K_Places_Away
{
    public class Solution
    {
        public bool KLengthApart(int[] nums, int k)
        {
            int prev = -1; // store index of last seen 1

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if (prev != -1 && i - prev - 1 < k)
                    {
                        return false;
                    }
                    prev = i;
                }
            }
            return true;
        }
    }
}
