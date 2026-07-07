namespace Concatenate_Non_Zero_Digits_and_Multiply_by_Sum_I
{
    public class Solution
    {
        public long SumAndMultiply(int n)
        {
            long x = 0, sum = 0, pow10 = 1;
            while (n > 0)
            {
                int d = n % 10;
                sum += d;
                if (d > 0)
                {
                    x += d * pow10;
                    pow10 *= 10;
                }
                n /= 10;
            }
            return x * sum;
        }
    }
}
