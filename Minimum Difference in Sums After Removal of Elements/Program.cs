namespace Minimum_Difference_in_Sums_After_Removal_of_Elements
{
    public class Solution
    {
        public long MinimumDifference(int[] nums)
        {
            int n = nums.Length / 3;
            int len = nums.Length;

            long[] leftSum = new long[len];
            long[] rightSum = new long[len];

            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            long sum = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                maxHeap.Enqueue(nums[i], nums[i]);
                sum += nums[i];

                if (maxHeap.Count > n)
                {
                    sum -= maxHeap.Dequeue();
                }

                leftSum[i] = (maxHeap.Count == n) ? sum : long.MaxValue;
            }

            var minHeap = new PriorityQueue<int, int>();
            sum = 0;

            for (int i = len - 1; i >= n; i--)
            {
                minHeap.Enqueue(nums[i], nums[i]);
                sum += nums[i];

                if (minHeap.Count > n)
                {
                    sum -= minHeap.Dequeue();
                }

                rightSum[i] = (minHeap.Count == n) ? sum : long.MinValue;
            }

            long minDiff = long.MaxValue;

            for (int i = n - 1; i < 2 * n; i++)
            {
                if (rightSum[i + 1] != long.MinValue)
                {
                    minDiff = Math.Min(minDiff, leftSum[i] - rightSum[i + 1]);
                }
            }

            return minDiff;
        }
    }
}
