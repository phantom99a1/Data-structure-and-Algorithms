namespace Check_Divisibility_by_Digit_Sum_and_Product
{
    public class Solution
    {
        public bool CheckDivisibility(int n)
        {
            int digitSum = 0;
            int digitProduct = 1;
            int original = n;

            while (n > 0)
            {
                int digit = n % 10;
                n /= 10;

                digitSum += digit;
                digitProduct *= digit;
            }

            return original % (digitSum + digitProduct) == 0;
        }
    }
}
