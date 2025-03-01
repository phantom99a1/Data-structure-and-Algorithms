namespace N_Queens
{
    /*The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
    Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.
    Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' 
    both indicate a queen and an empty space, respectively.
    
    Constraint:
    1 <= n <= 9
     */
   
    public class NQueensSolution
    {
        public static IList<IList<string>> SolveNQueens(int n)
        {
            var solutions = new List<IList<string>>();
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
                    var solution = new List<string>();
                    for (int i = 0; i < n; i++)
                    {
                        solution.Add(new string(board[i]));
                    }
                    solutions.Add(solution);
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
            return solutions;
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

            var results = NQueensSolution.SolveNQueens(n); // Outputs the board configurations for N-Queens

            foreach (var result in results)
            {
                foreach (var row in result)
                {
                    Console.WriteLine("[" + string.Join(", ", row) + "]");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
