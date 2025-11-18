namespace _1_bit_and_2_bit_Characters
{
    public class Solution
    {
        public bool IsOneBitCharacter(int[] bits)
        {
            int i = 0;
            int n = bits.Length;

            while (i < n - 1)
            {
                if (bits[i] == 1)
                {
                    i += 2; // two-bit character: 10 or 11
                }
                else
                {
                    i += 1; // one-bit character: 0
                }
            }

            return i == n - 1;
        }
    }
}
