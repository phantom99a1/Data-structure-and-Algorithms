namespace Sudoku_Solver
{
    /*Write a program to solve a Sudoku puzzle by filling the empty cells.
    A sudoku solution must satisfy all of the following rules:
    Each of the digits 1-9 must occur exactly once in each row.
    Each of the digits 1-9 must occur exactly once in each column.
    Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
    The '.' character indicates empty cells.
    
    Constraint:
    board.length == 9
    board[i].length == 9
    board[i][j] is a digit or '.'.
    It is guaranteed that the input board has only one solution.
     */
    public class Solution
    {
        public static void SolveSudoku(char[][] board)
        {
            var emptyCells = new List<(int, int)>();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        emptyCells.Add((row, col));
                    }
                }
            }

            Solve(board, emptyCells, 0);
        }

        private static bool Solve(char[][] board, List<(int, int)> emptyCells, int index)
        {
            if (index == emptyCells.Count)
            {
                return true;
            }

            (int row, int col) = emptyCells[index];

            for (char num = '1'; num <= '9'; num++)
            {
                if (IsValid(board, row, col, num))
                {
                    board[row][col] = num;
                    if (Solve(board, emptyCells, index + 1))
                    {
                        return true;
                    }
                    board[row][col] = '.';
                }
            }

            return false;
        }

        private static bool IsValid(char[][] board, int row, int col, char num)
        {
            int boxRow = (row / 3) * 3;
            int boxCol = (col / 3) * 3;

            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == num || board[i][col] == num || board[boxRow + i / 3][boxCol + i % 3] == num)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main()
        {
            char[][] board;
            List<string> errors;

            do
            {
                (board, errors) = GetValidInput("Enter the Sudoku board (format: row1|row2|...|row9): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            SolveSudoku(board);
            Console.WriteLine("Solved Sudoku board:");
            PrintBoard(board);
            Console.ReadKey();
        }

        public static (char[][], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] rows = input.Split('|');
            char[][] board = new char[9][];

            if (rows.Length != 9)
            {
                errors.Add("The board must have exactly 9 rows.");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cells = rows[i].Split(',');
                if (cells.Length != 9)
                {
                    errors.Add("Each row must have exactly 9 columns.");
                }
                board[i] = new char[9];
                for (int j = 0; j < cells.Length; j++)
                {
                    if (cells[j].Length != 1 || !(char.IsDigit(cells[j][0]) || cells[j][0] == '.'))
                    {
                        errors.Add($"Cell ({i}, {j}) is invalid.");
                    }
                    board[i][j] = cells[j][0];
                }
            }

            return (board, errors);
        }

        public static void PrintBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(string.Join(" ", board[i]));
            }
        }
    }
}
