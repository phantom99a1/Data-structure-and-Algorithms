namespace Count_Servers_that_Communicate
{
    /*You are given a map of a server center, represented as a m * n integer matrix grid, 
    where 1 means that on that cell there is a server and 0 means that it is no server. 
    Two servers are said to communicate if they are on the same row or on the same column.
    Return the number of servers that communicate with any other server.
    
    Constraint:
    m == grid.length
    n == grid[i].length
    1 <= m <= 250
    1 <= n <= 250
    grid[i][j] == 0 or 1
     */
    
    public class Program
    {
        private const int minDimension = 1;
        private const int maxDimension = 250;
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

            int result = CountServers(grid);
            Console.WriteLine("Count of Servers that Communicate: " + result);
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
                errors.Add("Invalid integer value in input.");
                return (Array.Empty<int[]>(), errors);
            }

            int m = grid.Length;
            int n = grid[0].Length;

            if (m < minDimension || m > maxDimension || n < minDimension || n > maxDimension)
            {
                errors.Add($"Grid dimensions should be between {minDimension} and {maxDimension}.");
            }
            if (grid.Any(row => row.Length != n))
            {
                errors.Add("All rows must have the same number of columns.");
            }
            if (grid.SelectMany(row => row).Any(cell => cell != 0 && cell != 1))
            {
                errors.Add("Each cell value must be either 0 or 1.");
            }

            return (grid, errors);
        }

        public static int CountServers(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[] rowCount = new int[m];
            int[] colCount = new int[n];

            // Count the number of servers in each row and column
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        rowCount[i]++;
                        colCount[j]++;
                    }
                }
            }

            int count = 0;
            // Count the servers that can communicate
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && (rowCount[i] > 1 || colCount[j] > 1))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
