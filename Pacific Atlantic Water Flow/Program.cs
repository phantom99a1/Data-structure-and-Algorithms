namespace Pacific_Atlantic_Water_Flow
{
    public class Solution
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int m = heights.Length, n = heights[0].Length;
            var pacific = new bool[m, n];
            var atlantic = new bool[m, n];

            void BFS(Queue<(int, int)> queue, bool[,] visited)
            {
                int[][] dirs = new int[][] {
                new int[]{1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1}
            };

                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int nx = x + dir[0], ny = y + dir[1];
                        if (
                            nx >= 0 && nx < m && ny >= 0 && ny < n &&
                            !visited[nx, ny] &&
                            heights[nx][ny] >= heights[x][y]
                        )
                        {
                            visited[nx, ny] = true;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
            }

            var pacQueue = new Queue<(int, int)>();
            var atlQueue = new Queue<(int, int)>();

            for (int i = 0; i < m; i++)
            {
                pacific[i, 0] = true;
                atlantic[i, n - 1] = true;
                pacQueue.Enqueue((i, 0));
                atlQueue.Enqueue((i, n - 1));
            }
            for (int j = 0; j < n; j++)
            {
                pacific[0, j] = true;
                atlantic[m - 1, j] = true;
                pacQueue.Enqueue((0, j));
                atlQueue.Enqueue((m - 1, j));
            }

            BFS(pacQueue, pacific);
            BFS(atlQueue, atlantic);

            var result = new List<IList<int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pacific[i, j] && atlantic[i, j])
                        result.Add(new List<int> { i, j });
                }
            }
            return result;
        }
    }
}
