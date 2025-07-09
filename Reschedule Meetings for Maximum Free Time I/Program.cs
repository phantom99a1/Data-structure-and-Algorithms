namespace Reschedule_Meetings_for_Maximum_Free_Time_I
{
    internal class Program
    {
        public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
        {
            int n = endTime.Length;
            int[] gaps = new int[n + 1];
            gaps[0] = startTime[0];
            for (int i = 1; i < n; i++)
            {
                gaps[i] = startTime[i] - endTime[i - 1];
            }
            gaps[n] = eventTime - endTime[n - 1];

            int maxFree = 0, sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += gaps[i];
                if (i >= k)
                {
                    maxFree = Math.Max(maxFree, sum);
                    sum -= gaps[i - k];
                }
            }
            return maxFree;
        }
    }
}
