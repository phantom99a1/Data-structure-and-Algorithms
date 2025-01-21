namespace Grid_Game
{
    /*You are given a 0-indexed 2D array grid of size 2 x n, where grid[r][c] represents the number of points 
    at position (r, c) on the matrix. Two robots are playing a game on this matrix.
    Both robots initially start at (0, 0) and want to reach (1, n-1). Each robot may only move to the right ((r, c) 
    to (r, c + 1)) or down ((r, c) to (r + 1, c)).
    At the start of the game, the first robot moves from (0, 0) to (1, n-1), collecting all the points from the cells on its path. 
    For all cells (r, c) traversed on the path, grid[r][c] is set to 0. Then, the second robot moves from (0, 0) to (1, n-1), 
    collecting the points on its path. Note that their paths may intersect with one another.
    The first robot wants to minimize the number of points collected by the second robot. 
    In contrast, the second robot wants to maximize the number of points it collects. 
    If both robots play optimally, return the number of points collected by the second robot.
    
    Constraint:
    grid.length == 2
    n == grid[r].length
    1 <= n <= 5 * 10^4
    1 <= grid[r][c] <= 10^5
     */
   
    public class Program
    {
        private const int gridLength = 2;
        private const int minColumnLength = 1;
        private const int maxColumnLength = 50000;
        private const int minValue = 1;
        private const int maxValue = 100000;
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

            long result = GridGame(grid);
            Console.WriteLine("Result of Grid Game: " + result);
            Console.ReadKey();
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split(';');

            if (rows.Length != gridLength)
            {
                errors.Add($"Grid must have exactly {gridLength} rows.");
                return (Array.Empty<int[]>(), errors);
            }

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

            int n = grid[0].Length;
            if (n < minColumnLength || n > maxColumnLength)
            {
                errors.Add($"Each row in the grid must have between {minColumnLength} and {maxColumnLength} columns.");
            }
            if (grid.Any(row => row.Length != n))
            {
                errors.Add("All rows must have the same number of columns.");
            }
            if (grid.SelectMany(row => row).Any(cell => cell < minValue || cell > maxValue))
            {
                errors.Add($"Each cell value must be between {minValue} and {maxValue}.");
            }

            return (grid, errors);
        }

        public static long GridGame(int[][] grid)
        {
            int n = grid[0].Length;

            long topSum = grid[0].Sum(val => (long)val);
            long bottomSum = 0;
            long minPointsForSecondRobot = long.MaxValue;

            for (int i = 0; i < n; i++)
            {
                topSum -= grid[0][i];
                minPointsForSecondRobot = Math.Min(minPointsForSecondRobot, Math.Max(topSum, bottomSum));
                bottomSum += grid[1][i];
            }

            return minPointsForSecondRobot;
        }
    }
}
