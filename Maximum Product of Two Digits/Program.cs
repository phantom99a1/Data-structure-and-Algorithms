namespace Maximum_Product_of_Two_Digits
{
    public class Solution
    {
        public int MaxProduct(int n)
        {
            int first = 0, second = 0;
            while (n > 0)
            {
                int x = n % 10;
                if (x > first)
                {
                    second = first;
                    first = x;
                }
                else if (x > second)
                {
                    second = x;
                }
                n /= 10;
            }
            return first * second;
        }
    }
}
