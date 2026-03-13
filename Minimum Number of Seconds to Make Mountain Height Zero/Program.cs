namespace Minimum_Number_of_Seconds_to_Make_Mountain_Height_Zero
{
    public class Solution
    {
        public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
        {
            long left = 0;
            long right = (long)1e18;

            while (left < right)
            {
                long mid = left + (right - left) / 2;

                if (CanFinish(mid, mountainHeight, workerTimes))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        private bool CanFinish(long time, int height, int[] workers)
        {
            long total = 0;

            foreach (int t in workers)
            {
                double val = (double)time * 2 / t;
                long x = (long)((Math.Sqrt(1 + 4 * val) - 1) / 2);

                total += x;

                if (total >= height)
                    return true;
            }

            return false;
        }
    }
}
