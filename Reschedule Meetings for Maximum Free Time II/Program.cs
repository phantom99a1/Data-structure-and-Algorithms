namespace Reschedule_Meetings_for_Maximum_Free_Time_II
{
    public class Solution
    {
        public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
        {
            int n = startTime.Length;
            int maxGapBefore = 0, maxFreeTime = 0, lastEnd = 0;

            for (int i = 0; i < n; i++)
            {
                int duration = endTime[i] - startTime[i];
                int nextStart = (i == n - 1) ? eventTime : startTime[i + 1];
                int freeTime = nextStart - lastEnd;

                if (duration > maxGapBefore) freeTime -= duration;
                maxFreeTime = Math.Max(maxFreeTime, freeTime);
                maxGapBefore = Math.Max(maxGapBefore, startTime[i] - lastEnd);
                lastEnd = endTime[i];
            }

            int maxGapAfter = 0, lastStart = eventTime;
            for (int i = n - 1; i >= 0; i--)
            {
                int duration = endTime[i] - startTime[i];
                int prevEnd = (i == 0) ? 0 : endTime[i - 1];
                int freeTime = lastStart - prevEnd;

                if (duration <= maxGapAfter)
                    maxFreeTime = Math.Max(maxFreeTime, freeTime);

                maxGapAfter = Math.Max(maxGapAfter, lastStart - endTime[i]);
                lastStart = startTime[i];
            }

            return maxFreeTime;
        }
    }
}
