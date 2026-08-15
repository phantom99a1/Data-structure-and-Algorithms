namespace Longest_Subsequence_With_Non_Zero_Bitwise_XOR
{

    public class Solution
    {
        public int LongestSubsequence(int[] a)
        {
            int x = 0;
            for (int i = 0; i < a.Length; i++) x ^= a[i];
            if (x != 0) return a.Length;
            for (int i = 0; i < a.Length; i++) if (a[i] != 0) return a.Length - 1;
            return 0;
        }
    }
}
