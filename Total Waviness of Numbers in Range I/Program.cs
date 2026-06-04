namespace Total_Waviness_of_Numbers_in_Range_I
{
    public class Solution
    {
        public int TotalWaviness(int num1, int num2)
        {
            int result = 0;
            var dp = new int[num2 + 1];

            for (int num = 0; num <= num2 / 10; num++)
                CountWaviness(num, dp);

            for (int num = num1; num <= num2; num++)
                result += CountWaviness(num, dp);

            return result;
        }

        private int CountWaviness(int num, int[] dp)
        {
            if (num < 100) return 0;

            int i = num % 10;
            int j = (num / 10) % 10;
            int k = (num / 100) % 10;

            dp[num] = dp[num / 10] + (
                (i < j && j > k) || (i > j && j < k) ? 1 : 0
            );

            return dp[num];
        }
    }
}
