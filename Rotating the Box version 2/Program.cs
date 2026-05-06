namespace Rotating_the_Box_version_2
{
    public class Solution
    {
        public char[][] RotateTheBox(char[][] boxGrid)
        {
            int ROWS = boxGrid.Length;
            int COLS = boxGrid[0].Length;

            char[][] res = new char[COLS][];
            for (int i = 0; i < COLS; i++)
            {
                res[i] = new char[ROWS];
                Array.Fill(res[i], '.');
            }

            for (int r = 0; r < ROWS; r++)
            {
                int i = COLS - 1;
                for (int c = COLS - 1; c >= 0; c--)
                {
                    if (boxGrid[r][c] == '#')
                    {
                        res[i][ROWS - r - 1] = '#';
                        i--;
                    }
                    else if (boxGrid[r][c] == '*')
                    {
                        res[c][ROWS - r - 1] = '*';
                        i = c - 1;
                    }
                }
            }
            return res;
        }
    }
}
