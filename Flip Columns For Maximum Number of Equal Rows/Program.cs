namespace Flip_Columns_For_Maximum_Number_of_Equal_Rows
{
    public class Solution
    {
        public static int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            var map = new Dictionary<string, int>();

            foreach (var row in matrix)
            {
                string pattern1 = string.Join("", row);
                string pattern2 = string.Join("", row.Select(cell => 1 - cell));

                if (map.TryGetValue(pattern1, out int value1))
                {
                    map[pattern1] = ++value1;
                }
                else
                {
                    map[pattern1] = 1;
                }

                if (map.TryGetValue(pattern2, out int value2))
                {
                    map[pattern2] = ++value2;
                }
                else
                {
                    map[pattern2] = 1;
                }
            }

            int maxRows = 0;
            foreach (var count in map.Values)
            {
                maxRows = Math.Max(maxRows, count);
            }

            return maxRows;
        }

        public static void Main()
        {            
            int numRows;
            do
            {
                Console.Write("Enter the number of rows: ");
            } while (!int.TryParse(Console.ReadLine(), out numRows) || numRows <= 0);

            int numCols;
            do
            {
                Console.Write("Enter the number of columns: ");
            } while (!int.TryParse(Console.ReadLine(), out numCols) || numCols <= 0);

            int[][] matrix = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                string input;
                do
                {
                    Console.Write($"Enter elements of row {i + 1} separated by space: ");
                    input = Console.ReadLine() ?? "";
                } while (string.IsNullOrWhiteSpace(input));

                matrix[i] = input.Split(' ').Select(int.Parse).ToArray();

                if (matrix[i].Length != numCols)
                {
                    Console.WriteLine($"Row must have exactly {numCols} elements.");
                    i--; // Re-prompt for the current row
                }
            }

            int result = MaxEqualRowsAfterFlips(matrix);
            Console.WriteLine("Maximum number of equal rows after flips: " + result);
            Console.ReadKey();
        }
    }
}
