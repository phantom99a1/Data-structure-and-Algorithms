namespace Design_Task_Manager
{
    public class TaskManager
    {
        // Maps taskId to its current priority
        private Dictionary<int, int> taskToPriority = new();

        // Maps taskId to the user who owns it
        private Dictionary<int, int> taskToUser = new();

        // PriorityQueue stores (taskId, priority) as element,
        // and uses (-priority, -taskId) as the sorting key to simulate max-heap behavior.
        // Higher priority comes first; if equal, higher taskId comes first.
        private PriorityQueue<(int taskId, int priority), (int negPriority, int negTaskId)>
            taskToPriorityQueue = new();

        // Constructor initializes the system with a list of tasks
        public TaskManager(IList<IList<int>> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                int userId = tasks[i][0];
                int taskId = tasks[i][1];
                int priority = tasks[i][2];

                // Store task's priority and user
                taskToPriority[taskId] = priority;
                taskToUser[taskId] = userId;

                // Enqueue task with negated priority and taskId to simulate max-heap:
                // - Higher priority = lower negative number → dequeued first
                // - If priorities are equal, higher taskId = lower negative → dequeued first
                taskToPriorityQueue.Enqueue((taskId, priority), (-priority, -taskId));
            }
        }

        // Adds a new task to the system
        public void Add(int userId, int taskId, int priority)
        {
            taskToPriority[taskId] = priority;
            taskToUser[taskId] = userId;
            taskToPriorityQueue.Enqueue((taskId, priority), (-priority, -taskId));
        }

        // Edits the priority of an existing task
        public void Edit(int taskId, int newPriority)
        {
            // Update the priority mapping
            taskToPriority[taskId] = newPriority;

            // Enqueue the updated task again.
            // Old entries will be lazily discarded during ExecTop.
            taskToPriorityQueue.Enqueue((taskId, newPriority), (-newPriority, -taskId));
        }

        // Removes a task from the system
        public void Rmv(int taskId)
        {
            taskToPriority.Remove(taskId);
            taskToUser.Remove(taskId);
            // Note: We don't remove from the queue directly.
            // Stale entries will be skipped during ExecTop.
        }

        // Executes the highest priority task across all users
        public int ExecTop()
        {
            // Lazy deletion: skip stale or outdated entries
            while (taskToPriorityQueue.Count > 0)
            {
                var (taskId, priority) = taskToPriorityQueue.Dequeue();

                // If task was removed, skip it
                if (!taskToPriority.ContainsKey(taskId))
                    continue;

                // If priority has changed since it was enqueued, skip it
                int correctPriority = taskToPriority[taskId];
                if (priority != correctPriority)
                    continue;

                // Valid task found; remove it and return associated userId
                int userId = taskToUser[taskId];
                Rmv(taskId);
                return userId;
            }

            // No tasks available
            return -1;
        }
    }

    /**
     * Your TaskManager object will be instantiated and called as such:
     * TaskManager obj = new TaskManager(tasks);
     * obj.Add(userId,taskId,priority);
     * obj.Edit(taskId,newPriority);
     * obj.Rmv(taskId);
     * int param_4 = obj.ExecTop();
     */
}
