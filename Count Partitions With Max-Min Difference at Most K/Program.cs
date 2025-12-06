namespace Count_Partitions_With_Max_Min_Difference_at_Most_K
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int CountPartitions(int[] nums, int k)
        {
            int n = nums.Length;
            const int MOD = 1000000007;

            long[] dp = new long[n + 1];
            dp[0] = 1; // base case: empty partition

            // prefix sum for fast range sum queries
            long[] prefix = new long[n + 1];
            prefix[0] = 1;

            // monotonic queues for min and max
            LinkedList<int> minQ = new LinkedList<int>();
            LinkedList<int> maxQ = new LinkedList<int>();

            int left = 0;
            for (int right = 0; right < n; right++)
            {
                // maintain monotonic min queue
                while (minQ.Count > 0 && nums[minQ.Last.Value] >= nums[right])
                    minQ.RemoveLast();
                minQ.AddLast(right);

                // maintain monotonic max queue
                while (maxQ.Count > 0 && nums[maxQ.Last.Value] <= nums[right])
                    maxQ.RemoveLast();
                maxQ.AddLast(right);

                // shrink window until valid
                while (nums[maxQ.First.Value] - nums[minQ.First.Value] > k)
                {
                    left++;
                    if (minQ.First.Value < left) minQ.RemoveFirst();
                    if (maxQ.First.Value < left) maxQ.RemoveFirst();
                }

                // dp[right+1] = sum of dp[left..right]
                dp[right + 1] = (prefix[right] - (left > 0 ? prefix[left - 1] : 0) + MOD) % MOD;
                prefix[right + 1] = (prefix[right] + dp[right + 1]) % MOD;
            }

            return (int)dp[n];
        }
    }
}
