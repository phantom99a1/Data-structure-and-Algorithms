namespace Minimum_Obstacle_Removal_to_Reach_Corner
{
    public class Solution
    {
        public static int MinObstacleRemoval(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int[][] directions = [
            [0, 1], [1, 0], [0, -1], [-1, 0]
        ];

            int[,] dist = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dist[i, j] = int.MaxValue;
                }
            }
            dist[0, 0] = 0;

            var deque = new LinkedList<(int dist, int x, int y)>();
            deque.AddFirst((0, 0, 0));

            while (deque.Count > 0)
            {
                var (currentDist, x, y) = deque.First.Value;
                deque.RemoveFirst();

                foreach (var dir in directions)
                {
                    int nx = x + dir[0];
                    int ny = y + dir[1];

                    if (nx >= 0 && ny >= 0 && nx < n && ny < m)
                    {
                        int newDist = currentDist + grid[nx][ny];
                        if (newDist < dist[nx, ny])
                        {
                            dist[nx, ny] = newDist;
                            if (grid[nx][ny] == 1)
                            {
                                deque.AddLast((newDist, nx, ny));
                            }
                            else
                            {
                                deque.AddFirst((newDist, nx, ny));
                            }
                        }
                    }
                }
            }

            return dist[n - 1, m - 1];
        }

        public static void Main()
        {
            Console.WriteLine("Enter the number of rows:");
            int n = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Enter the number of columns:");
            int m = int.Parse(Console.ReadLine() ?? "");

            int[][] grid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter elements of row {i + 1} separated by space:");
                grid[i] = (Console.ReadLine() ?? "").Split(' ').Select(int.Parse).ToArray();
            }

            int result = MinObstacleRemoval(grid);
            Console.WriteLine("Minimum number of obstacles to remove: " + result);
            Console.ReadKey();
        }
    }
}
