namespace Find_Servers_That_Handled_Most_Number_of_Requests
{
    public class Solution
    {
        public IList<int> BusiestServers(int k, int[] arrival, int[] load)
        {
            int[] count = new int[k];
            IList<int> result = new List<int>();
            PriorityQueue<int, int> free = new PriorityQueue<int, int>();
            PriorityQueue<(int, int), int> busy = new PriorityQueue<(int, int), int>();

            //All servers free at beginning
            for (int i = 0; i < k; i++)
            {
                free.Enqueue(i, i);
            }

            for (int i = 0; i < arrival.Length; i++)
            {
                int start = arrival[i];

                //Remove free servers from busy , modify their IDs and add them to free
                while (busy.Count > 0 && busy.Peek().Item1 <= start)
                {
                    var curr = busy.Dequeue();
                    int serverId = curr.Item2;
                    int modifiedId = ((serverId - i) % k + k) % k + i;
                    free.Enqueue(modifiedId, modifiedId);
                }

                //Get the original server ID by taking the remainder of the modified ID to k
                if (free.Count > 0)
                {
                    int busyId = free.Dequeue() % k;
                    busy.Enqueue((start + load[i], busyId), start + load[i]);
                    count[busyId]++;
                }
            }
            int max = Int32.MinValue;
            foreach (int c in count)
            {
                max = Math.Max(max, c);
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (max == count[i])
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
