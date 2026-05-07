namespace Rotate_Function
{
    public class Solution
    {
        public int MaxRotateFunction(int[] nums)
        {
            int n = nums.Length;
            int sum = 0;
            int F = 0;

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                F += i * nums[i];
            }

            int res = F;

            for (int j = 1; j < n; j++)
            {
                F += sum - n * nums[n - j];
                res = Math.Max(res, F);
            }

            return res;
        }
    }
}
