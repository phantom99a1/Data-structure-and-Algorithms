namespace Maximum_Subarray_With_Equal_Products
{
    public class Solution
    {
        private long Gcd(long a, long b)
        {
            while (b != 0L)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private long Lcm(long a, long b)
        {
            return (a / Gcd(a, b)) * b;
        }

        public int MaxLength(int[] nums)
        {
            int n = nums.Length;
            int maxLen = 0;
            for (int i = 0; i < n; i++)
            {
                long currentProd = 1L;
                long currentGcd = nums[i];
                long currentLcm = nums[i];

                for (int j = i; j < n; j++)
                {
                    long val = nums[j];
                    if (currentProd > 1000000000000L / val)
                    {
                        currentProd = 2000000000000L;
                    }
                    else
                    {
                        currentProd *= val;
                    }

                    if (j > i)
                    {
                        currentGcd = Gcd(currentGcd, val);
                        currentLcm = Lcm(currentLcm, val);
                    }

                    if (currentProd == currentLcm * currentGcd)
                    {
                        if (j - i + 1 > maxLen)
                        {
                            maxLen = j - i + 1;
                        }
                    }
                }
            }
            return maxLen;
        }
    }
}
