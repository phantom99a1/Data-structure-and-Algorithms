namespace Jump_Game_III
{
    public class Solution
    {
        public bool CanReach(int[] arr, int start)
        {
            int n = arr.Length;

            bool[] visited = new bool[n];
            Queue<int> q = new Queue<int>();

            q.Enqueue(start);

            while (q.Count > 0)
            {
                int i = q.Dequeue();

                if (i < 0 || i >= n || visited[i])
                    continue;

                if (arr[i] == 0)
                    return true;

                visited[i] = true;

                q.Enqueue(i + arr[i]);
                q.Enqueue(i - arr[i]);
            }

            return false;
        }
    }
}
