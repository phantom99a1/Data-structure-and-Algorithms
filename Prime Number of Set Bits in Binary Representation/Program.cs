namespace Prime_Number_of_Set_Bits_in_Binary_Representation
{
    public class Solution
    {
        public int CountPrimeSetBits(int left, int right)
        {
            var count = 0;
            for (int i = left; i <= right; i++)
            {
                var bits = CountBits(i);
                if (bits == 2 || bits == 3 || bits == 5 || bits == 7 ||
                    bits == 11 || bits == 13 || bits == 17 || bits == 19)
                    count++;
            }

            return count;
        }

        private int CountBits(int num)
        {
            var count = 0;
            while (num > 0)
            {
                num &= num - 1;
                count++;
            }

            return count;
        }
    }
}
