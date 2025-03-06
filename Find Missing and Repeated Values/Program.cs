namespace Find_Missing_and_Repeated_Values
{
    /*You are given a 0-indexed 2D integer matrix grid of size n * n with values in the range [1, n2]. Each integer appears exactly 
    once except a which appears twice and b which is missing. The task is to find the repeating and missing numbers a and b.
    Return a 0-indexed integer array ans of size 2 where ans[0] equals to a and ans[1] equals to b.
    
    Constraint:
    2 <= n == grid.length == grid[i].length <= 50
    1 <= grid[i][j] <= n * n
    For all x that 1 <= x <= n * n there is exactly one x that is not equal to any of the grid members.
    For all x that 1 <= x <= n * n there is exactly one x that is equal to exactly two of the grid members.
    For all x that 1 <= x <= n * n except two of them there is exatly one pair of i, j that 0 <= i, j <= n - 1 and grid[i][j] == x.
     */
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter grid size (n): ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 50)
            {
                Console.WriteLine("Error: Enter a valid grid size (2 <= n <= 50).");
            }

            int[,] grid = new int[n, n];
            Console.WriteLine("Enter grid values:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int value;
                    while (!int.TryParse(Console.ReadLine(), out value) || value < 1 || value > n * n)
                    {
                        Console.WriteLine($"Error: Enter a valid value for grid[{i}][{j}] (1 <= grid[i][j] <= {n * n}).");
                    }
                    grid[i, j] = value;
                }
            }

            int[] count = new int[n * n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    count[grid[i, j]]++;
                }
            }

            int missing = -1, repeated = -1;
            for (int i = 1; i <= n * n; i++)
            {
                if (count[i] == 0) missing = i;
                if (count[i] == 2) repeated = i;
            }

            Console.WriteLine($"The result: [{repeated}, {missing}]");
            Console.ReadKey();
        }
    }
}
