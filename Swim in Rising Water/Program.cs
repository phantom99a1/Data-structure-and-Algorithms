namespace Swim_in_Rising_Water
{
    public class Solution
    {
        private int[][] directions = new int[4][];

        class Path
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public Path(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }

        public Solution()
        {
            directions[0] = new[] { 0, 1 };
            directions[1] = new[] { 1, 0 };
            directions[2] = new[] { -1, 0 };
            directions[3] = new[] { 0, -1 };
        }

        public int SwimInWater(int[][] grid)
        {
            var left = 0;
            var right = int.MinValue;

            foreach (var array in grid)
            {
                foreach (var value in array)
                {
                    right = Math.Max(right, value);
                }
            }

            var answer = int.MaxValue;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (IsValidWaterLevel(grid, mid))
                {
                    answer = Math.Min(answer, mid);
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return answer == int.MaxValue ? -1 : answer;
        }

        bool IsValidWaterLevel(int[][] grid, int waterLevel)
        {
            if (grid[0][0] > waterLevel) return false;

            var queue = new Queue<Path>();
            var visited = new bool[grid.Length, grid[0].Length];

            visited[0, 0] = true;
            queue.Enqueue(new Path(0, 0));

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current.Row == grid.Length - 1 && current.Column == grid[0].Length - 1) return true;

                foreach (var direction in directions)
                {
                    var nextRow = current.Row + direction[0];
                    var nextColumn = current.Column + direction[1];

                    if (IsValidStep(nextColumn, nextRow, grid, waterLevel) && !visited[nextRow, nextColumn])
                    {
                        queue.Enqueue(new Path(nextRow, nextColumn));
                        visited[nextRow, nextColumn] = true;
                    }
                }
            }

            return false;
        }

        bool IsValidStep(int column, int row, int[][] grid, int waterLevel)
        {
            return 0 <= row && row < grid.Length && 0 <= column && column < grid[row].Length && grid[row][column] <= waterLevel;
        }
    }
}
