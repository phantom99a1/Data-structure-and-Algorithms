namespace Calculate_Money_in_Leetcode_Bank
{
    internal class Program
    {
        public int TotalMoney(int n)
        {
            int weeks = n / 7;
            int days = n % 7;
            int total = 0;

            // Sum for complete weeks
            for (int i = 0; i < weeks; i++)
            {
                total += (7 * i) + (7 * (7 + 1)) / 2;
            }

            // Sum for remaining days
            for (int i = 0; i < days; i++)
            {
                total += weeks + i + 1;
            }

            return total;
        }
    }
}
