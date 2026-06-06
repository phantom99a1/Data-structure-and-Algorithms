namespace Left_and_Right_Sum_Differences
{
    public class Solution
    {
        public int[] LeftRightDifference(int[] nums)
        {
            int n = nums.Length;
            int[] leftSum = new int[n];
            int[] rightSum = new int[n];
            int[] newSum = new int[n];

            for (int i = 1; i < n; i++)
            {
                leftSum[i] = leftSum[i - 1] + nums[i - 1];
            }

            for (int j = n - 2; j >= 0; j--)
            {
                rightSum[j] = rightSum[j + 1] + nums[j + 1];
            }

            for (int k = 0; k < n; k++)
            {
                newSum[k] = Math.Abs(leftSum[k] - rightSum[k]);
            }

            return newSum;
        }
    }
}
