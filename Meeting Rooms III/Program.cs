namespace Meeting_Rooms_III
{
    public class Solution
    {
        public int MostBooked(int n, int[][] meetings)
        {
            long[] roomAvailabilityTime = new long[n];
            int[] meetingCount = new int[n];

            Array.Sort(meetings, (a, b) => a[0] - b[0]);

            for (int i = 0; i < meetings.Length; i++)
            {
                int start = meetings[i][0], end = meetings[i][1];
                long minRoomAvailabilityTime = long.MaxValue;
                int minAvailableTimeRoom = 0;
                bool foundUnusedRoom = false;

                for (int j = 0; j < n; j++)
                {
                    if (roomAvailabilityTime[j] <= start)
                    {
                        foundUnusedRoom = true;
                        meetingCount[j]++;
                        roomAvailabilityTime[j] = end;
                        break;
                    }

                    if (minRoomAvailabilityTime > roomAvailabilityTime[j])
                    {
                        minRoomAvailabilityTime = roomAvailabilityTime[j];
                        minAvailableTimeRoom = j;
                    }
                }

                if (!foundUnusedRoom)
                {
                    roomAvailabilityTime[minAvailableTimeRoom] += end - start;
                    meetingCount[minAvailableTimeRoom]++;
                }
            }

            int maxMeetingCount = 0, maxMeetingCountRoom = 0;
            for (int i = 0; i < n; i++)
            {
                if (meetingCount[i] > maxMeetingCount)
                {
                    maxMeetingCount = meetingCount[i];
                    maxMeetingCountRoom = i;
                }
            }

            return maxMeetingCountRoom;
        }
    }
}
