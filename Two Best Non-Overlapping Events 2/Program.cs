namespace Two_Best_Non_Overlapping_Events_2
{
    public class Solution
    {
        public int MaxTwoEvents(int[][] events)
        {
            Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();

            int maxValueSoFar = 0;
            int result = 0;

            foreach (var e in events)
            {
                int start = e[0];
                int end = e[1];
                int value = e[2];

                while (pq.Count > 0 && pq.Peek()[0] < start)
                {
                    maxValueSoFar = Math.Max(maxValueSoFar, pq.Dequeue()[1]);
                }

                result = Math.Max(result, maxValueSoFar + value);
                pq.Enqueue(new int[] { end, value }, end);
            }

            return result;
        }
    }
}
