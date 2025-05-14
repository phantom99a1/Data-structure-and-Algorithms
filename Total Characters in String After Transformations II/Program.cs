namespace Total_Characters_in_String_After_Transformations_II
{
    /*You are given a string s consisting of lowercase English letters, an integer t representing the number of transformations 
    to perform, and an array nums of size 26. In one transformation, every character in s is replaced according to the 
    following rules: Replace s[i] with the next nums[s[i] - 'a'] consecutive characters in the alphabet. 
    For example, if s[i] = 'a' and nums[0] = 3, the character 'a' transforms into the next 3 consecutive characters ahead of it, 
    which results in "bcd".The transformation wraps around the alphabet if it exceeds 'z'. 
    For example, if s[i] = 'y' and nums[24] = 3, the character 'y' transforms into the next 3 consecutive characters ahead of it, 
    which results in "zab". Return the length of the resulting string after exactly t transformations.
    Since the answer may be very large, return it modulo 10^9 + 7.
    
     Constraint:
    1 <= s.length <= 10^5
    s consists only of lowercase English letters.
    1 <= t <= 10^9
    nums.length == 26
    1 <= nums[i] <= 25
     */
    public class Solution
    {
        private const int MOD = 1_000_000_007;
        public int LengthAfterTransformations(string s, int t, IList<int> nums)
        {
            int[,] transition = new int[26, 26];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 1; j <= nums[i]; j++)
                {
                    int nextChar = (i + j) % 26;
                    transition[i, nextChar]++;
                }
            }
            int[,] resultMatrix = MatrixPower(transition, t);
            int[] finalCounts = new int[26];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    finalCounts[i] = (finalCounts[i] + resultMatrix[i, j]) % MOD;
                }
            }
            long total = 0;
            foreach (char ch in s)
            {
                total = (total + finalCounts[ch - 'a']) % MOD;
            }

            return (int)total;
        }
        private int[,] MatrixPower(int[,] matrix, int power)
        {
            int[,] result = IdentityMatrix();

            while (power > 0)
            {
                if ((power & 1) == 1)
                {
                    result = MultiplyMatrices(result, matrix);
                }
                matrix = MultiplyMatrices(matrix, matrix);
                power >>= 1;
            }

            return result;
        }

        private int[,] IdentityMatrix()
        {
            int[,] identity = new int[26, 26];
            for (int i = 0; i < 26; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }

        private int[,] MultiplyMatrices(int[,] a, int[,] b)
        {
            int[,] res = new int[26, 26];

            for (int i = 0; i < 26; i++)
            {
                for (int k = 0; k < 26; k++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        res[i, j] = (int)((res[i, j] + 1L * a[i, k] * b[k, j]) % MOD);
                    }
                }
            }

            return res;
        }
    }
}
