namespace Count_Non_Decreasing_Subarrays_After_K_Operations
{
    public class Solution
    {
        public long CountNonDecreasingSubarrays(int[] nums, int k)
        {
            int n = nums.Length;
            long res = (long)(1 + n) * n / 2;

            for (int i = 0; i < n - 1; i++)
            {
                int premax = nums[i], idx = i + 1;
                int opt = 0;

                while (idx < n && opt <= k)
                {
                    int diff = nums[idx] - premax;
                    if (diff >= 0)
                    {
                        premax = nums[idx];
                    }
                    else
                    {
                        opt -= diff;
                    }

                    if (opt > k) break;
                    idx++;
                }

                if (idx >= n) return res;
                res -= (n - idx);
            }

            return res;
        }
    }
}
