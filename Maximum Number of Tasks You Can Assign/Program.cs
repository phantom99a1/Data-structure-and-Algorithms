﻿namespace Maximum_Number_of_Tasks_You_Can_Assign
{
    /*You have n tasks and m workers. Each task has a strength requirement stored in a 0-indexed integer array tasks, 
     with the ith task requiring tasks[i] strength to complete. The strength of each worker is stored in a 0-indexed 
    integer array workers, with the jth worker having workers[j] strength. Each worker can only be assigned to a single 
    task and must have a strength greater than or equal to the task's strength requirement (i.e., workers[j] >= tasks[i]).
    Additionally, you have pills magical pills that will increase a worker's strength by strength. You can decide which 
    workers receive the magical pills, however, you may only give each worker at most one magical pill.
    Given the 0-indexed integer arrays tasks and workers and the integers pills and strength, return the maximum number 
    of tasks that can be completed.
    
     Constraint:
    n == tasks.length
    m == workers.length
    1 <= n, m <= 5 * 10^4
    0 <= pills <= m
    0 <= tasks[i], workers[j], strength <= 10^9
     */
    public class Solution
    {
        public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
        {
            int n = tasks.Length, m = workers.Length;
            Array.Sort(tasks);
            Array.Sort(workers);

            Func<int, bool> check = mid => {
                int p = pills;
                var ws = new LinkedList<int>();
                int ptr = m - 1;
                // Enumerate each task from largest to smallest
                for (int i = mid - 1; i >= 0; --i)
                {
                    while (ptr >= m - mid && workers[ptr] + strength >= tasks[i])
                    {
                        ws.AddFirst(workers[ptr]);
                        --ptr;
                    }
                    if (ws.Count == 0)
                    {
                        return false;
                    }
                    else if (ws.Last.Value >= tasks[i])
                    {
                        // If the largest element in the deque is greater than or
                        // equal to tasks[i]
                        ws.RemoveLast();
                    }
                    else
                    {
                        if (p == 0)
                        {
                            return false;
                        }
                        --p;
                        ws.RemoveFirst();
                    }
                }
                return true;
            };

            int left = 1, right = Math.Min(m, n), ans = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (check(mid))
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return ans;
        }
    }
}
