namespace Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid
{
    /*Given an m x n grid. Each cell of the grid has a sign pointing to the next cell you should visit 
    if you are currently in this cell. The sign of grid[i][j] can be:
    1 which means go to the cell to the right. (i.e go from grid[i][j] to grid[i][j + 1])
    2 which means go to the cell to the left. (i.e go from grid[i][j] to grid[i][j - 1])
    3 which means go to the lower cell. (i.e go from grid[i][j] to grid[i + 1][j])
    4 which means go to the upper cell. (i.e go from grid[i][j] to grid[i - 1][j])
    Notice that there could be some signs on the cells of the grid that point outside the grid.
    You will initially start at the upper left cell (0, 0). A valid path in the grid is a path that starts from the upper 
    left cell (0, 0) and ends at the bottom-right cell (m - 1, n - 1) following the signs on the grid. 
    The valid path does not have to be the shortest.
    You can modify the sign on a cell with cost = 1. You can modify the sign on a cell one time only.
    Return the minimum cost to make the grid have at least one valid path.
    
    Constraint:
    m == grid.length
    n == grid[i].length
    1 <= m, n <= 100
    1 <= grid[i][j] <= 4
     */
    
    public class Program
    {
        private static readonly int[][] directions =
        [
            [0, 1],  // right
            [0, -1], // left
            [1, 0],  // down
            [-1, 0]  // up
        ];
        private const int minLength = 1;
        private const int maxLength = 100;
        private const int minValue = 1;
        private const int maxValue = 4;
        public static void Main()
        {
            int[][] grid = GetValidInput("Enter the grid (rows separated by ';', cells by ','): ");
            int minCost = MinCost(grid);
            Console.WriteLine("Minimum cost to make at least one valid path: " + minCost);
            Console.ReadKey();
        }

        public static bool IsValidInput(string input, out List<string> errorMessages, out int[][] grid)
        {
            grid = [];
            errorMessages = [];

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessages.Add("Input cannot be empty.");
                return false;
            }

            string[] rows = input.Split(';');
            grid = rows.Select(row => row.Split(',').Select(int.Parse).ToArray()).ToArray();

            int m = grid.Length;
            if (m < minLength || m > maxLength)
            {
                errorMessages.Add($"The number of rows must be between {minLength} and {maxLength}.");
            }

            int n = grid[0].Length;
            if (grid.Any(row => row.Length != n))
            {
                errorMessages.Add("All rows must have the same length.");
            }

            if (grid.Any(row => row.Any(cell => cell < minValue || cell > maxValue)))
            {
                errorMessages.Add($"Each cell value must be between {minValue} and {maxValue}.");
            }

            return errorMessages.Count == 0;
        }

        public static int[][] GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages, out int[][] grid))
                {
                    return grid;
                }
                else
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                }
            }
        }

        public static int MinCost(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var cost = new int[m][];
            for (int i = 0; i < m; i++)
            {
                cost[i] = Enumerable.Repeat(int.MaxValue, n).ToArray();
            }

            var pq = new PriorityQueue<(int, int, int), int>();
            pq.Enqueue((0, 0, 0), 0);
            cost[0][0] = 0;

            while (pq.Count > 0)
            {
                var (i, j, c) = pq.Dequeue();
                if (i == m - 1 && j == n - 1) return c; // Early exit if we reached the target

                for (int d = 0; d < 4; d++)
                {
                    int ni = i + directions[d][0];
                    int nj = j + directions[d][1];
                    int newCost = c + (grid[i][j] == d + 1 ? 0 : 1);
                    if (ni >= 0 && ni < m && nj >= 0 && nj < n && newCost < cost[ni][nj])
                    {
                        cost[ni][nj] = newCost;
                        pq.Enqueue((ni, nj, newCost), newCost);
                    }
                }
            }

            return cost[m - 1][n - 1];
        }
    }
}
