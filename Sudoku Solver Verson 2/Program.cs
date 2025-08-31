namespace Sudoku_Solver_Verson_2
{
    public class Solution
    {
        private bool isValid = false;
        private HashSet<int>[] cols = new HashSet<int>[9];
        private HashSet<int>[] rows = new HashSet<int>[9];
        private HashSet<int>[] grid = new HashSet<int>[9];

        public void SolveSudoku(char[][] board)
        {

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<int>();
                cols[i] = new HashSet<int>();
                grid[i] = new HashSet<int>();
            }


            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    char val = board[r][c];
                    if (val == '.') continue;
                    int num = board[r][c] - '0';
                    rows[r].Add(num);
                    cols[c].Add(num);
                    int idx = (r / 3) * 3 + c / 3;
                    grid[idx].Add(num);
                }
            }
            bool isValid = false;
            Backtracking(0, 0);
            void Backtracking(int r, int c)
            {
                if (r == 9)
                {
                    isValid = true;
                    return;
                }
                int new_row = r + (c + 1) / 9, new_col = (c + 1) % 9;
                if (board[r][c] != '.') Backtracking(new_row, new_col);
                else
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        int idx = (r / 3) * 3 + c / 3;
                        if (!rows[r].Contains(i) && !cols[c].Contains(i) && !grid[idx].Contains(i))
                        {
                            rows[r].Add(i);
                            cols[c].Add(i);
                            grid[idx].Add(i);

                            board[r][c] = (char)(i + '0');
                            Backtracking(new_row, new_col);

                            if (isValid) return;
                            rows[r].Remove(i);
                            cols[c].Remove(i);
                            grid[idx].Remove(i);
                            board[r][c] = '.';
                        }
                    }
                }
            }
        }
    }
}
