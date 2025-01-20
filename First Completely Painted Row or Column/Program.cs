namespace First_Completely_Painted_Row_or_Column
{
    /*You are given a 0-indexed integer array arr, and an m x n integer matrix mat. 
     arr and mat both contain all the integers in the range [1, m * n].
    Go through each index i in arr starting from index 0 and paint the cell in mat containing the integer arr[i].
    Return the smallest index i at which either a row or a column will be completely painted in mat.
    
    Constraint:
    m == mat.length
    n = mat[i].length
    arr.length == m * n
    1 <= m, n <= 10^5
    1 <= m * n <= 10^5
    1 <= arr[i], mat[r][c] <= m * n
    All the integers of arr are unique.
    All the integers of mat are unique.
     */

    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        private const int minValue = 1;
        public static void Main()
        {
            int[][] mat;
            int[] arr;
            List<string> errors;

            do
            {
                (mat, arr, errors) = GetValidInput("Enter the matrix (rows separated by ';', cells by ',') and array separated by '|': ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            int result = FirstCompletelyPaintedRowOrColumn(mat, arr);
            Console.WriteLine("First completely painted row or column at index: " + result);
            Console.ReadKey();
        }

        public static (int[][], int[], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] inputs = input.Split('|');

            if (inputs.Length != 2)
            {
                errors.Add("Invalid format. Please enter the matrix and the array separated by '|'.");
                return (Array.Empty<int[]>(), Array.Empty<int>(), errors);
            }

            string[] matRows = inputs[0].Split(';');
            int[][] mat;
            try
            {
                mat = matRows.Select(row => row.Split(',').Select(int.Parse).ToArray()).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in matrix.");
                return (Array.Empty<int[]>(), Array.Empty<int>(), errors);
            }

            int[] arr;
            try
            {
                arr = inputs[1].Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in array.");
                return (Array.Empty<int[]>(), Array.Empty<int>(), errors);
            }

            int m = mat.Length;
            int n = mat[0].Length;

            if (m < minLength || n < minLength || m > maxLength || n > maxLength)
            {
                errors.Add($"Matrix dimensions should be between {minLength} and {maxLength}.");
            }
            if (arr.Length != m * n)
            {
                errors.Add($"The length of the array should be equal to {m * n}.");
            }
            if (arr.Distinct().Count() != arr.Length)
            {
                errors.Add("All elements in the array should be unique.");
            }
            if (mat.SelectMany(row => row).Distinct().Count() != m * n)
            {
                errors.Add($"All elements in the matrix should be unique and within the range {minValue} to {m * n}.");
            }

            return (mat, arr, errors);
        }

        public static int FirstCompletelyPaintedRowOrColumn(int[][] mat, int[] arr)
        {
            int m = mat.Length, n = mat[0].Length;
            int[] rowCount = new int[m];
            int[] colCount = new int[n];
            var valueToPosition = new Dictionary<int, (int, int)>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    valueToPosition[mat[i][j]] = (i, j);
                }
            }

            for (int k = 0; k < arr.Length; k++)
            {
                var (i, j) = valueToPosition[arr[k]];
                rowCount[i]++;
                colCount[j]++;

                if (rowCount[i] == n || colCount[j] == m)
                {
                    return k;
                }
            }

            return -1; // Should not reach here if input is correct
        }
    }
}
