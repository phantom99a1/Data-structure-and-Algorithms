namespace Meeting_Rooms_III_ver2
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MostBooked(int n, int[][] meetings)
        {
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

            // Min-heap of free rooms (smallest index first)
            var freeRooms = new PriorityQueue<int, int>();
            for (int i = 0; i < n; i++)
                freeRooms.Enqueue(i, i);

            // Min-heap of busy rooms: (endTime, roomIndex)
            var busyRooms = new PriorityQueue<(long endTime, int room), (long, int)>();

            int[] count = new int[n];

            foreach (var meeting in meetings)
            {
                long start = meeting[0];
                long end = meeting[1];

                // Free rooms that have finished before current meeting starts
                while (busyRooms.Count > 0 && busyRooms.Peek().endTime <= start)
                {
                    var finished = busyRooms.Dequeue();
                    freeRooms.Enqueue(finished.room, finished.room);
                }

                int room;
                long newEnd;

                if (freeRooms.Count > 0)
                {
                    room = freeRooms.Dequeue();
                    newEnd = end;
                }
                else
                {
                    var earliest = busyRooms.Dequeue();
                    room = earliest.room;
                    newEnd = earliest.endTime + (end - start);
                }

                busyRooms.Enqueue((newEnd, room), (newEnd, room));
                count[room]++;
            }

            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                if (count[i] > count[ans])
                    ans = i;
            }

            return ans;
        }
    }
}
