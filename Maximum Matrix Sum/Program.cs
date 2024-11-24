namespace Maximum_Matrix_Sum
{
    /* You are given an n x n integer matrix. You can do the following operation any number of times:

    Choose any two adjacent elements of matrix and multiply each of them by -1.
    Two elements are considered adjacent if and only if they share a border.

    Your goal is to maximize the summation of the matrix's elements. 
    Return the maximum sum of the matrix's elements using the operation mentioned above.
    */
    public class Solution
    {
        public static int MaxMatrixSum(int[][] matrix)
        {
            int totalSum = 0;
            int minAbsValue = int.MaxValue;
            int negativeCount = 0;

            foreach (var row in matrix)
            {
                foreach (var val in row)
                {
                    totalSum += Math.Abs(val);
                    if (val < 0)
                    {
                        negativeCount++;
                    }
                    minAbsValue = Math.Min(minAbsValue, Math.Abs(val));
                }
            }

            if (negativeCount % 2 != 0)
            {
                totalSum -= 2 * minAbsValue;
            }

            return totalSum;
        }

        public static void Main()
        {            
            int numRows;
            do
            {
                Console.Write("Enter the number of rows: ");
            } while (!int.TryParse(Console.ReadLine(), out numRows) || numRows <= 0);

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
            }

            Console.WriteLine("Maximum Matrix Sum: " + MaxMatrixSum(matrix));
            Console.ReadKey();
        }
    }
}
