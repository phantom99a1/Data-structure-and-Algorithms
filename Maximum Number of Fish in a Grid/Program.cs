namespace Maximum_Number_of_Fish_in_a_Grid
{
    /*You are given a 0-indexed 2D matrix grid of size m x n, where (r, c) represents:
    A land cell if grid[r][c] = 0, or
    A water cell containing grid[r][c] fish, if grid[r][c] > 0.
    A fisher can start at any water cell (r, c) and can do the following operations any number of times:
    Catch all the fish at cell (r, c), or
    Move to any adjacent water cell.
    Return the maximum number of fish the fisher can catch if he chooses his starting cell optimally, 
    or 0 if no water cell exists.
    An adjacent cell of the cell (r, c), is one of the cells (r, c + 1), (r, c - 1), (r + 1, c) or (r - 1, c) if it exists.
    
    Constraint:
    m == grid.length
    n == grid[i].length
    1 <= m, n <= 10
    0 <= grid[i][j] <= 10
     */
    
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 10;
        private const int minValue = 0;
        private const int maxValue = 10;
        public static int FindMaxFish(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[m, n];
            int maxFishCount = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0 && !visited[i, j])
                    {
                        maxFishCount = Math.Max(maxFishCount, DFS(grid, i, j, visited));
                    }
                }
            }

            return maxFishCount;
        }

        private static int DFS(int[][] grid, int i, int j, bool[,] visited)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int fishCount = 0;
            int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

            Stack<(int, int)> stack = new();
            stack.Push((i, j));
            visited[i, j] = true;

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                fishCount += grid[x][y];

                foreach (var dir in directions)
                {
                    int nx = x + dir[0];
                    int ny = y + dir[1];

                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny] && grid[nx][ny] > 0)
                    {
                        stack.Push((nx, ny));
                        visited[nx, ny] = true;
                    }
                }
            }

            return fishCount;
        }

        public static void Main()
        {
            int[][] grid;
            List<string> errors;

            do
            {
                (grid, errors) = GetValidInput("Enter the grid (format: row1_a,row1_b,...;row2_a,row2_b,...;...): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = FindMaxFish(grid);
            Console.WriteLine("Maximum number of fish: " + result);
            Console.ReadKey();
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            List<string> errors = [];
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split(';');
            int m = rows.Length;
            int[][] grid = new int[m][];

            if (m < minLength || m > maxLength)
            {
                errors.Add($"Number of rows (m) must be between {minLength} and {maxLength}.");
            }

            for (int i = 0; i < m; i++)
            {
                string[] cols = rows[i].Split(',');
                if (grid[0] != null && cols.Length != grid[0].Length)
                {
                    errors.Add("All rows must have the same number of columns.");
                    break;
                }

                grid[i] = new int[cols.Length];
                for (int j = 0; j < cols.Length; j++)
                {
                    if (!int.TryParse(cols[j], out grid[i][j]) || grid[i][j] < minValue || grid[i][j] > maxValue)
                    {
                        errors.Add($"Value at ({i}, {j}) must be an integer between {minValue} and {maxValue}.");
                    }
                }
            }

            if (grid[0].Length < minLength || grid[0].Length > maxLength)
            {
                errors.Add($"Number of columns (n) must be between {minLength} and {maxLength}.");
            }

            return (grid, errors);
        }
    }
}
