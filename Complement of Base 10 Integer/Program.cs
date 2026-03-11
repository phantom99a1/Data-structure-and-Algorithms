namespace Complement_of_Base_10_Integer
{
    public class Solution
    {
        public int BitwiseComplement(int n)
        {

            if (n == 0) return 1;

            int bits = (int)Math.Log(n, 2) + 1;
            int mask = (1 << bits) - 1;

            return n ^ mask;
        }
    }
}
