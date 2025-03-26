namespace Minimum_Operations_to_Make_a_Uni_Value_Grid
{
    /*You are given a 2D integer grid of size m x n and an integer x. In one operation, you can add x to or subtract 
    x from any element in the grid. A uni-value grid is a grid where all the elements of it are equal.
    Return the minimum number of operations to make the grid uni-value. If it is not possible, return -1.
    
    Constraint:
    m == grid.length
    n == grid[i].length
    1 <= m, n <= 10^5
    1 <= m * n <= 10^5
    1 <= x, grid[i][j] <= 10^4
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter number of rows (m): ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Enter number of columns (n): ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Enter step value (x): ");
                int x = int.Parse(Console.ReadLine());

                if (m <= 0 || n <= 0 || m * n > 100000 || x <= 0 || x > 10000)
                {
                    throw new Exception("Invalid constraints! Please ensure 1 <= m, n and m * n <= 10^5, 1 <= x <= 10^4.");
                }

                Console.WriteLine("Enter the grid values row by row:");
                List<int> flattened = new List<int>();
                for (int i = 0; i < m; i++)
                {
                    int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    if (row.Length != n)
                    {
                        throw new Exception($"Row {i + 1} must have {n} values.");
                    }
                    flattened.AddRange(row);
                }

                int mod = flattened[0] % x;
                if (flattened.Any(val => val % x != mod))
                {
                    Console.WriteLine("Grid cannot be converted to a uni-value grid with the given step value.");
                    Console.ReadKey();
                    return;
                }

                flattened.Sort();
                int median = flattened[flattened.Count / 2];
                long operations = flattened.Sum(val => Math.Abs(val - median) / x);

                Console.WriteLine($"Minimum operations to make the grid uni-value: {operations}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
