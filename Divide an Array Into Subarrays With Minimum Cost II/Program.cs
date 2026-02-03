namespace Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II
{
    public class Solution
    {
        public long MinimumCost(int[] nums, int k, int dist)
        {
            int n = nums.Length, targetK = k - 1;
            int[] sorted = nums.Distinct().OrderBy(x => x).ToArray();
            int m = sorted.Length;
            long[] bitSum = new long[m + 1];
            int[] bitCount = new int[m + 1];
            var rankMap = sorted.Select((v, i) => new { v, i }).ToDictionary(x => x.v, x => x.i + 1);

            void Update(int r, int v, int c)
            {
                for (; r <= m; r += r & -r)
                {
                    bitSum[r] += (long)v; bitCount[r] += c;
                }
            }

            int maxP = 1;
            while ((maxP << 1) <= m) maxP <<= 1;
            long minExtra = long.MaxValue;

            for (int i = 1; i < n; i++)
            {
                Update(rankMap[nums[i]], nums[i], 1);
                if (i > dist + 1)
                {
                    int oldV = nums[i - dist - 1];
                    Update(rankMap[oldV], -oldV, -1);
                }
                if (i >= targetK)
                {
                    int idx = 0, cc = 0; long cs = 0;
                    for (int p = maxP; p > 0; p >>= 1)
                    {
                        if (idx + p <= m && cc + bitCount[idx + p] < targetK)
                        {
                            idx += p; cc += bitCount[idx]; cs += bitSum[idx];
                        }
                    }
                    if (cc < targetK) cs += (long)(targetK - cc) * sorted[idx];
                    minExtra = Math.Min(minExtra, cs);
                }
            }
            return nums[0] + minExtra;
        }
    }
}
