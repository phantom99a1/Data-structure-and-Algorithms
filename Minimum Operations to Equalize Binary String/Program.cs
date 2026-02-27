namespace Minimum_Operations_to_Equalize_Binary_String
{
    class Solution
    {
        public int MinOperations(string s, int k)
        {
            int zero = 0;
            int len = s.Length;

            for (int i = 0; i < len; i++)
                zero += ~s[i] & 1;

            if (zero == 0)
                return 0;

            if (len == k)
                return ((zero == len ? 1 : 0) << 1) - 1;

            int @base = len - k;

            int odd = Math.Max(
                (zero + k - 1) / k,
                (len - zero + @base - 1) / @base
            );

            odd += ~odd & 1;

            int even = Math.Max(
                (zero + k - 1) / k,
                (zero + @base - 1) / @base
            );

            even += even & 1;

            int res = int.MaxValue;

            if ((k & 1) == (zero & 1))
                res = Math.Min(res, odd);

            if ((~zero & 1) == 1)
                res = Math.Min(res, even);

            return res == int.MaxValue ? -1 : res;
        }
    }
}
