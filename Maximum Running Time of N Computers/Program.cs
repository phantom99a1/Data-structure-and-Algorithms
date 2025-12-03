namespace Maximum_Running_Time_of_N_Computers
{
    using System;
    using System.Linq;

    public class Solution
    {
        public long MaxRunTime(int n, int[] batteries)
        {
            // Sort to enable safe upper bound estimation and potential pruning
            Array.Sort(batteries);

            long total = 0;
            foreach (int b in batteries) total += b;

            // Upper bound: you can't run longer than total / n minutes
            long left = 0, right = total / n;

            while (left < right)
            {
                long mid = (left + right + 1) / 2; // bias upward to avoid infinite loop
                if (CanRun(n, batteries, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private bool CanRun(int n, int[] batteries, long T)
        {
            long sum = 0;
            // Each battery can contribute at most T minutes within the window
            foreach (int b in batteries)
            {
                sum += Math.Min((long)b, T);
                if (sum >= T * n) return true; // early exit
            }
            return sum >= T * n;
        }
    }
}
