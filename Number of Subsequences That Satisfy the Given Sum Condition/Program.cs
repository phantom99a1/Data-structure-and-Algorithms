namespace Number_of_Subsequences_That_Satisfy_the_Given_Sum_Condition
{
    public class Solution
    {
        public int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            int mod = 1_000_000_007;
            int[] pow = new int[nums.Length];
            pow[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                pow[i] = (pow[i - 1] * 2) % mod;
            }

            int left = 0, right = nums.Length - 1, result = 0;

            while (left <= right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    result = (result + pow[right - left]) % mod;
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return result;
        }
    }
}
