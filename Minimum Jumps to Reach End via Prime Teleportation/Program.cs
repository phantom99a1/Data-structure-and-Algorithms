namespace Minimum_Jumps_to_Reach_End_via_Prime_Teleportation
{
    public class Solution
    {
        static readonly bool[] prime = new bool[1000005];

        static Solution()
        {
            prime[0] = prime[1] = true;
            for (int i = 2; i <= 1000; i++)
                if (!prime[i])
                    for (int j = i * i; j < 1000005; j += i)
                        prime[j] = true;
        }

        public int MinJumps(int[] arr)
        {
            int n = arr.Length;
            int max = arr[0];
            for (int i = 1; i < n; i++)
                max = Math.Max(max, arr[i]);

            int[] head = new int[max + 1];
            Array.Fill(head, -1);
            int[] next = new int[n];

            for (int i = 0; i < n; i++)
            {
                next[i] = head[arr[i]];
                head[arr[i]] = i;
            }

            int[] res = new int[n];
            Array.Fill(res, -1);
            res[0] = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            HashSet<int> seen = new HashSet<int>();

            while (queue.Count > 0)
            {
                int idx = queue.Dequeue();

                if (idx == n - 1)
                    return res[idx];

                int right = idx + 1;
                if (right < n && res[right] == -1)
                {
                    res[right] = res[idx] + 1;
                    queue.Enqueue(right);
                }

                int left = idx - 1;
                if (left >= 0 && res[left] == -1)
                {
                    res[left] = res[idx] + 1;
                    queue.Enqueue(left);
                }

                int val = arr[idx];
                if (!prime[val] && !seen.Contains(val))
                {
                    seen.Add(val);
                    for (int i = val; i <= max; i += val)
                    {
                        for (int j = head[i]; j != -1; j = next[j])
                        {
                            if (res[j] == -1)
                            {
                                res[j] = res[idx] + 1;
                                queue.Enqueue(j);
                            }
                        }
                        head[i] = -1;
                    }
                }
            }

            return -1;
        }
    }
}
