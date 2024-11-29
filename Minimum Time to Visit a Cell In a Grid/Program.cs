namespace Minimum_Time_to_Visit_a_Cell_In_a_Grid
{
    public class Solution
    {
        private static readonly (int dr, int dc)[] MOVES = [(-1, 0), (0, 1), (1, 0), (0, -1)];

        public static int MinTimeToVisitCell(int[][] grid)
        {
            if (grid[0][1] > 1 && grid[1][0] > 1)
            {
                return -1;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;
            var pq = new PriorityQueue<(int time, int row, int col), int>();
            pq.Enqueue((0, 0, 0), 0); // time, row, col, queue

            bool[][] seen = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                seen[i] = new bool[cols];
            }
            seen[0][0] = true;

            while (pq.Count > 0)
            {
                var (time, row, col) = pq.Dequeue();

                foreach (var (dr, dc) in MOVES)
                {
                    int newRow = row + dr;
                    int newCol = col + dc;

                    if (newRow < 0 || newRow >= rows ||
                        newCol < 0 || newCol >= cols ||
                        seen[newRow][newCol])
                    {
                        continue;
                    }

                    int newTime = time + 1;
                    if (grid[newRow][newCol] > newTime)
                    {
                        newTime += ((grid[newRow][newCol] - time) / 2) * 2;
                    }

                    if (newRow == rows - 1 && newCol == cols - 1)
                    {
                        return newTime;
                    }

                    seen[newRow][newCol] = true;
                    pq.Enqueue((newTime, newRow, newCol), newTime);
                }
            }

            return -1;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Enter the number of columns:");
            int cols = int.Parse(Console.ReadLine() ?? "");

            int[][] grid = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Enter elements of row {i + 1} separated by space:");
                grid[i] = (Console.ReadLine() ?? "").Split(' ').Select(int.Parse).ToArray();
            }

            int result = MinTimeToVisitCell(grid);
            Console.WriteLine("Minimum time to visit the bottom-right corner: " + result);
            Console.ReadKey();
        }
    }
}
