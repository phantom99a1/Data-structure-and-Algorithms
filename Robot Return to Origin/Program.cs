namespace Robot_Return_to_Origin
{
    public class Solution
    {
        public bool JudgeCircle(string moves)
        {
            int x = 0, y = 0;

            foreach (char m in moves)
            {
                if (m == 'R') x++;
                else if (m == 'L') x--;
                else if (m == 'U') y++;
                else if (m == 'D') y--;
            }

            return x == 0 && y == 0;
        }
    }
}
