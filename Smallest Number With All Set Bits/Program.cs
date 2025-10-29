namespace Smallest_Number_With_All_Set_Bits
{
    public class Solution
    {
        public int SmallestNumber(int n)
        {
            int k = 1;
            while ((1 << k) - 1 < n)
            {
                k++;
            }
            return (1 << k) - 1;
        }
    }
}
