namespace Maximum_Number_of_Points_From_Grid_Queries
{
    /*You are given an m x n integer matrix grid and an array queries of size k.
    Find an array answer of size k such that for each integer queries[i] you start in the top left cell 
    of the matrix and repeat the following process:
    If queries[i] is strictly greater than the value of the current cell that you are in, then you get one point if it is 
    your first time visiting this cell, and you can move to any adjacent cell in all 4 directions: up, down, left, and right.
    Otherwise, you do not get any points, and you end this process.
    After the process, answer[i] is the maximum number of points you can get. Note that for each query you are allowed to visit 
    the same cell multiple times. Return the resulting array answer.
    
    Constraint:
    m == grid.length
    n == grid[i].length
    2 <= m, n <= 1000
    4 <= m * n <= 10^5
    k == queries.length
    1 <= k <= 10^4
    1 <= grid[i][j], queries[i] <= 10^6
     */
    public class Solution
    {
        public static int[] MaxPoints(int[][] grid, int[] queries)
        {
            int rows = grid.Length, cols = grid[0].Length;
            int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

            int[] result = new int[queries.Length];
            var sortedQueries = queries
                .Select((val, idx) => new Tuple<int, int>(val, idx))
                .OrderBy(q => q.Item1)
                .ToList();

            var minHeap = new SortedSet<(int val, int row, int col)>(Comparer<(int, int, int)>.Create((a, b) => a.Item1 == b.Item1 ? (a.Item2 == b.Item2 ? a.Item3 - b.Item3 : a.Item2 - b.Item2) : a.Item1 - b.Item1));
            bool[,] visited = new bool[rows, cols];

            minHeap.Add((grid[0][0], 0, 0));
            visited[0, 0] = true;
            int points = 0;

            foreach (var (queryVal, queryIdx) in sortedQueries)
            {
                while (minHeap.Count > 0 && minHeap.Min.val < queryVal)
                {
                    var (val, row, col) = minHeap.Min;
                    minHeap.Remove(minHeap.Min);
                    points++;

                    foreach (var dir in directions)
                    {
                        int nr = row + dir[0], nc = col + dir[1];
                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !visited[nr, nc])
                        {
                            minHeap.Add((grid[nr][nc], nr, nc));
                            visited[nr, nc] = true;
                        }
                    }
                }
                result[queryIdx] = points;
            }

            return result;
        }
        static void Main()
        {
            Console.WriteLine("Enter the grid dimensions (rows and columns):");
            string[] gridDims = Console.ReadLine()?.Split();
            Console.WriteLine("Enter the queries count:");
            int queryCount = int.Parse(Console.ReadLine() ?? "0");

            List<int[]> grid = new List<int[]>();
            Console.WriteLine("Enter the grid row by row:");
            for (int i = 0; i < int.Parse(gridDims[0]); i++)
            {
                grid.Add(Array.ConvertAll(Console.ReadLine()?.Split(), int.Parse));
            }

            Console.WriteLine("Enter the queries:");
            int[] queries = Array.ConvertAll(Console.ReadLine()?.Split(), int.Parse);

            List<string> errors = ValidateInput(grid, queries, int.Parse(gridDims[0]), int.Parse(gridDims[1]), queryCount);

            if (errors.Count > 0)
            {
                Console.WriteLine("Validation errors:");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                Console.WriteLine("Input is valid!");
                Console.WriteLine($"The result: {MaxPoints([.. grid], queries)}");
            }
        }

        static List<string> ValidateInput(List<int[]> grid, int[] queries, int m, int n, int k)
        {
            List<string> errors = new List<string>();

            if (m < 2 || n < 2 || m > 1000 || n > 1000)
            {
                errors.Add("Grid dimensions must satisfy 2 <= m, n <= 1000.");
            }
            if (m * n < 4 || m * n > 100000)
            {
                errors.Add("Product of m * n must satisfy 4 <= m * n <= 10^5.");
            }
            if (k < 1 || k > 10000)
            {
                errors.Add("Query count must satisfy 1 <= k <= 10^4.");
            }
            foreach (var row in grid)
            {
                foreach (var val in row)
                {
                    if (val < 1 || val > 1000000)
                    {
                        errors.Add("Grid values must satisfy 1 <= grid[i][j] <= 10^6.");
                        break;
                    }
                }
            }
            foreach (var val in queries)
            {
                if (val < 1 || val > 1000000)
                {
                    errors.Add("Query values must satisfy 1 <= queries[i] <= 10^6.");
                    break;
                }
            }

            return errors;
        }

    }
}
