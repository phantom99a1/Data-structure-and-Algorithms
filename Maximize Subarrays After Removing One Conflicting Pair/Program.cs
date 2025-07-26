namespace Maximize_Subarrays_After_Removing_One_Conflicting_Pair
{
    public class Solution
    {
        public long MaxSubarrays(int n, int[][] conflictingPairs)
        {
            long validSubarrays = 0;
            int maxLeft = 0, secondMaxLeft = 0;
            long[] gains = new long[n + 1];
            List<int>[] conflicts = new List<int>[n + 1];

            for (int i = 0; i <= n; i++)
                conflicts[i] = new List<int>();

            foreach (var pair in conflictingPairs)
            {
                int a = pair[0], b = pair[1];
                conflicts[Math.Max(a, b)].Add(Math.Min(a, b));
            }

            for (int right = 1; right <= n; ++right)
            {
                foreach (int left in conflicts[right])
                {
                    if (left > maxLeft)
                    {
                        secondMaxLeft = maxLeft;
                        maxLeft = left;
                    }
                    else if (left > secondMaxLeft)
                    {
                        secondMaxLeft = left;
                    }
                }
                validSubarrays += right - maxLeft;
                gains[maxLeft] += maxLeft - secondMaxLeft;
            }

            return validSubarrays + gains.Max();
        }
    }
}
