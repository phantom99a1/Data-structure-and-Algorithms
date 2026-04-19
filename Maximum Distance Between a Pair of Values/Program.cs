namespace Maximum_Distance_Between_a_Pair_of_Values
{
    public class Solution
    {
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0, ans = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] > nums2[j])
                {
                    i++;
                }
                else
                {
                    ans = Math.Max(ans, j - i);
                    j++;
                }
            }

            return ans;
        }
    }
}
