namespace Process_Tasks_Using_Servers
{
    public class Solution
    {
        public int[] AssignTasks(int[] servers, int[] tasks)
        {
            var sFree = new PriorityQueue<int, (int weight, int idx)>(); // SERVER_IDX -> SERVER_WEIGHT
            var sBusy = new PriorityQueue<(int finishTime, int idx), int>(); // (FINISH_TIME, SERVER_IDX) -> FINISH_TIME

            // Init free servers
            for (int i = 0; i < servers.Length; i++)
            {
                sFree.Enqueue(i, (servers[i], i));
            }

            var ans = new int[tasks.Length];

            int time = 0,
                tIdx = 0;
            while (tIdx < tasks.Length)
            {
                // Move finished busy servers from sBusy to sFree
                while (sBusy.Count > 0
                    && time == sBusy.Peek().finishTime)
                {
                    var (_, i) = sBusy.Dequeue();
                    sFree.Enqueue(i, (servers[i], i));
                }

                // Find sFree servers; for each, assign it to a task, and move it from sFree to sBusy
                // Note there may be multiple servers becoming free at the same time, say time = t; in which case, the problem description noted you can assign multiple tasks at time = t. That's why there's a while loop below
                do
                {
                    var sIdx = sFree.Dequeue();
                    ans[tIdx] = sIdx;
                    sBusy.Enqueue((time + tasks[tIdx], sIdx), time + tasks[tIdx]);
                    tIdx++;
                } while (tIdx < tasks.Length
                    && sFree.Count > 0
                    && tIdx <= time);

                if (sFree.Count > 0)
                    time++;
                else
                    time = sBusy.Peek().finishTime;
            }

            return ans;
        }
    }
}
