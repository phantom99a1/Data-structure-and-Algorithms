namespace Trapping_Rain_Water_II
{
    /*Given an m x n integer matrix heightMap representing the height of each unit cell in a 2D elevation map, 
    return the volume of water it can trap after raining.
    
    Constraint:
    m == heightMap.length
    n == heightMap[i].length
    1 <= m, n <= 200
    0 <= heightMap[i][j] <= 2 * 10^4
     */
    
    public class Program
    {
        private static readonly int[][] directions =
        [
            [0, 1],  // right
            [1, 0],  // down
            [0, -1], // left
            [-1, 0]  // up
        ];
        private const int minLength = 1;
        private const int maxLength = 200;
        private const int minValue = 0;
        private const int maxValue = 20000;

        public static void Main()
        {
            int[][] heightMap = GetValidInput("Enter the height map (rows separated by ';', cells by ','): ");
            int result = TrappingRainWater(heightMap);
            Console.WriteLine("Total trapped water: " + result);
            Console.ReadKey();
        }

        public static bool IsValidInput(string input, out List<string> errorMessages, out int[][] heightMap)
        {
            heightMap = [];
            errorMessages = [];

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessages.Add("Input cannot be empty.");
                return false;
            }

            string[] rows = input.Split(';');
            List<int[]> tempHeightMap = [];

            foreach (string row in rows)
            {
                string[] cells = row.Split(',');
                List<int> tempRow = [];

                foreach (string cell in cells)
                {
                    if (!int.TryParse(cell, out int cellValue))
                    {
                        errorMessages.Add($"Invalid element '{cell}' found in row '{row}'. All elements must be integers.");
                        continue;
                    }

                    if (cellValue < minValue || cellValue > maxValue)
                    {
                        errorMessages.Add($"Element '{cellValue}' in row '{row}' must be between 0 and 20000.");
                    }
                    else
                    {
                        tempRow.Add(cellValue);
                    }
                }

                if (tempRow.Count > 0 && tempRow.Count != cells.Length)
                {
                    errorMessages.Add($"Row '{row}' has invalid elements. All rows must have the same length.");
                }

                tempHeightMap.Add([.. tempRow]);
            }

            heightMap = [.. tempHeightMap];
            int m = heightMap.Length;
            if (m < minLength || m > maxLength)
            {
                errorMessages.Add($"The number of rows must be between {minLength} and {maxLength}.");
            }

            int n = heightMap[0].Length;
            if (heightMap.Any(row => row.Length != n))
            {
                errorMessages.Add("All rows must have the same length.");
            }

            return errorMessages.Count == 0;
        }

        public static int[][] GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages, out int[][] heightMap))
                {
                    return heightMap;
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

        public static int TrappingRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            if (m == 0) return 0;
            int n = heightMap[0].Length;
            var visited = new bool[m][];
            for (int i = 0; i < m; i++) visited[i] = new bool[n];
            var heap = new PriorityQueue<(int height, int x, int y), int>();
            int water = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        heap.Enqueue((heightMap[i][j], i, j), heightMap[i][j]);
                        visited[i][j] = true;
                    }
                }
            }

            while (heap.Count > 0)
            {
                var (h, i, j) = heap.Dequeue();
                foreach (var direction in directions)
                {
                    int ni = i + direction[0], nj = j + direction[1];
                    if (ni >= 0 && ni < m && nj >= 0 && nj < n && !visited[ni][nj])
                    {
                        water += Math.Max(0, h - heightMap[ni][nj]);
                        heap.Enqueue((Math.Max(h, heightMap[ni][nj]), ni, nj), Math.Max(h, heightMap[ni][nj]));
                        visited[ni][nj] = true;
                    }
                }
            }

            return water;
        }
    }
}
