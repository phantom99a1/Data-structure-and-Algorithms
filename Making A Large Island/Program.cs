namespace Making_A_Large_Island
{
    /*You are given an n x n binary matrix grid. You are allowed to change at most one 0 to be 1.
    Return the size of the largest island in grid after applying this operation.
    An island is a 4-directionally connected group of 1s.
    
    Constraint:
    n == grid.length
    n == grid[i].length
    1 <= n <= 500
    grid[i][j] is either 0 or 1.
     */
    
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 500;
        public static int LargestIsland(int[][] grid)
        {
            int n = grid.Length;
            int[] islandSizes = new int[n * n + 2];
            int islandIndex = 2;

            int GetIslandSize(int x, int y)
            {
                if (x < 0 || x >= n || y < 0 || y >= n || grid[x][y] != 1) return 0;
                grid[x][y] = islandIndex;
                return 1 + GetIslandSize(x + 1, y) + GetIslandSize(x - 1, y) + GetIslandSize(x, y + 1) + GetIslandSize(x, y - 1);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islandSizes[islandIndex] = GetIslandSize(i, j);
                        islandIndex++;
                    }
                }
            }

            int maxSize = islandSizes.Max();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        var seen = new HashSet<int>();
                        int size = 1;
                        if (i > 0) seen.Add(grid[i - 1][j]);
                        if (i < n - 1) seen.Add(grid[i + 1][j]);
                        if (j > 0) seen.Add(grid[i][j - 1]);
                        if (j < n - 1) seen.Add(grid[i][j + 1]);
                        foreach (int index in seen)
                        {
                            if (index > 1) size += islandSizes[index];
                        }
                        maxSize = Math.Max(maxSize, size);
                    }
                }
            }

            return maxSize;
        }

        public static void Main()
        {
            int[][] grid;
            List<string> errors;

            do
            {
                (grid, errors) = GetValidInput("Enter the grid (format: row1|row2|...|rown): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = LargestIsland(grid);
            Console.WriteLine("Largest possible island size: " + result);
            Console.ReadKey();
        }

        public static (int[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split('|');
            int[][] grid = new int[rows.Length][];

            int n = rows.Length;

            if (n < minLength || n > maxLength)
            {
                errors.Add($"The grid size must be between {minLength} and {maxLength}.");
            }

            for (int i = 0; i < n; i++)
            {
                string[] cells = rows[i].Split(',');
                grid[i] = new int[cells.Length];
                if (cells.Length != n)
                {
                    errors.Add($"Row {i + 1} must have exactly {n} columns.");
                }

                for (int j = 0; j < n; j++)
                {
                    if (int.TryParse(cells[j], out int val) && (val == 0 || val == 1))
                    {
                        grid[i][j] = val;
                    }
                    else
                    {
                        errors.Add($"Cell ({i + 1}, {j + 1}) must be either 0 or 1.");
                    }
                }
            }

            return (grid, errors);
        }
    }
}
