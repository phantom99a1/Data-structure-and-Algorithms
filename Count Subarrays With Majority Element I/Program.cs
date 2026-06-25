namespace Count_Subarrays_With_Majority_Element_I
{
    public class Solution
    {
        public int CountMajoritySubarrays(int[] nums, int target)
        {
            int n = nums.Length;
            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                int cnt = 0;
                for (int j = i; j < n; ++j)
                {
                    cnt += (nums[j] == target ? 1 : -1);
                    if (cnt > 0)
                    {
                        ++ans;
                    }
                }
            }
            return ans;
        }
    }
}
