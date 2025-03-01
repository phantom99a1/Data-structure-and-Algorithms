namespace N_Queens_II
{
    /*The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
    Given an integer n, return the number of distinct solutions to the n-queens puzzle.
    
    Constraint:
    1 <= n <= 9
     */

    public class NQueensSolution
    {
        public static int TotalNQueens(int n)
        {
            int count = 0;
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = '.';
                }
            }

            void PlaceQueens(int row)
            {
                if (row == n)
                {
                    count++;
                    return;
                }

                for (int col = 0; col < n; col++)
                {
                    if (IsValid(row, col))
                    {
                        board[row][col] = 'Q';
                        PlaceQueens(row + 1);
                        board[row][col] = '.';
                    }
                }
            }

            bool IsValid(int row, int col)
            {
                for (int i = 0; i < row; i++)
                {
                    if (board[i][col] == 'Q') return false;
                    if (col - (row - i) >= 0 && board[i][col - (row - i)] == 'Q') return false;
                    if (col + (row - i) < n && board[i][col + (row - i)] == 'Q') return false;
                }
                return true;
            }

            PlaceQueens(0);
            return count;
        }
    }

    public class Program
    {
        public static void Main()
        {
            int n;
            while (true)
            {
                Console.Write("Enter the value of n (1 <= n <= 9): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 9) break;
                Console.WriteLine("Invalid input. Please enter an integer between 1 and 9.");
            }

            Console.WriteLine(NQueensSolution.TotalNQueens(n));
            Console.ReadKey();
        }
    }

}
