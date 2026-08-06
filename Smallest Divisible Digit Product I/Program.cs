namespace Smallest_Divisible_Digit_Product_I
{
    public class Solution
    {
        public int SmallestNumber(int n, int t)
        {
            int product = 1;
            int nCounter = n;
            int counter = 0;
            int result = n;

            while (product % t != 0)
            {
                nCounter = n + counter;
                product = 1;
                result = nCounter;

                while (nCounter != 0)
                {
                    int remainder = nCounter % 10;
                    product = product * remainder;
                    nCounter = nCounter / 10;
                }
                counter++;
            }
            return result;
        }
    }
}
