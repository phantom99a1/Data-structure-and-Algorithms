namespace Map_of_Highest_Peak
{
    /*You are given an integer matrix isWater of size m x n that represents a map of land and water cells.
    If isWater[i][j] == 0, cell (i, j) is a land cell.
    If isWater[i][j] == 1, cell (i, j) is a water cell.
    You must assign each cell a height in a way that follows these rules:
    The height of each cell must be non-negative.
    If the cell is a water cell, its height must be 0.
    Any two adjacent cells must have an absolute height difference of at most 1. 
    A cell is adjacent to another cell if the former is directly north, east, south, or west of the latter 
    (i.e., their sides are touching).
    Find an assignment of heights such that the maximum height in the matrix is maximized.
    Return an integer matrix height of size m x n where height[i][j] is cell (i, j)'s height. 
    If there are multiple solutions, return any of them.
    
    Constraint:
    m == isWater.length
    n == isWater[i].length
    1 <= m, n <= 1000
    isWater[i][j] is 0 or 1.
    There is at least one water cell.
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 1000;
        public static void Main()
        {
            int[][] grid;
            List<string> errors;

            do
            {
                (grid, errors) = GetValidInput("Enter the grid (rows separated by ';', cells by ','): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            int[][] result = HighestPeak(grid);
            Console.WriteLine("Resulting Highest Peak Map:");
            Console.WriteLine("[[" + string.Join("],[", result.Select(row => string.Join(",", row))) + "]]");    
            Console.ReadKey();
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split(';');

            int[][] grid;
            try
            {
                grid = rows.Select(row => row.Split(',').Select(int.Parse).ToArray()).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in grid.");
                return (Array.Empty<int[]>(), errors);
            }

            int m = grid.Length;
            int n = grid[0].Length;

            if (m < minLength || m > maxLength || n < minLength || n > maxLength)
            {
                errors.Add($"Grid dimensions should be between {minLength} and {maxLength}.");
            }
            if (grid.Any(row => row.Length != n))
            {
                errors.Add("All rows must have the same number of columns.");
            }
            if (grid.SelectMany(row => row).Any(cell => cell != 0 && cell != 1))
            {
                errors.Add("Each cell value must be either 0 or 1.");
            }
            if (!grid.SelectMany(row => row).Contains(1))
            {
                errors.Add("There must be at least one water cell.");
            }

            return (grid, errors);
        }

        public static int[][] HighestPeak(int[][] isWater)
        {
            int m = isWater.Length;
            int n = isWater[0].Length;
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = -1;
                }
            }

            var queue = new Queue<(int, int)>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isWater[i][j] == 1)
                    {
                        result[i][j] = 0;
                        queue.Enqueue((i, j));
                    }
                }
            }

            int[][] directions =
            [
                [1, 0],
                [-1, 0],
                [0, 1],
                [0, -1]
            ];

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int nx = x + dir[0], ny = y + dir[1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && result[nx][ny] == -1)
                    {
                        result[nx][ny] = result[x][y] + 1;
                        queue.Enqueue((nx, ny));
                    }
                }
            }

            return result;
        }
    }
}
