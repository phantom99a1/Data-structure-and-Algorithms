namespace Minimum_One_Bit_Operations_to_Make_Integers_Zero
{
    public class Solution
    {
        public int MinimumOneBitOperations(int n)
        {
            int res = 0;
            while (n > 0)
            {
                res ^= n;
                n >>= 1;
            }
            return res;
        }
    }
}
