namespace Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers
{
    public class Solution
    {
        public int[] GetNoZeroIntegers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                int j = n - i;
                if (!HasZero(i) && !HasZero(j))
                {
                    return new int[] { i, j };
                }
            }
            return null;
        }

        private bool HasZero(int num)
        {
            while (num > 0)
            {
                if (num % 10 == 0) return true;
                num /= 10;
            }
            return false;
        }
    }
}
