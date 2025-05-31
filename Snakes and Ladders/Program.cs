namespace Snakes_and_Ladders
{
    /**/
    public class Solution
    {
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            int[] flattenBoard = new int[n * n + 1];
            int index = 1;
            bool reverse = false;

            for (int i = n - 1; i >= 0; i--)
            {
                if (reverse)
                {
                    for (int j = n - 1; j >= 0; j--) flattenBoard[index++] = board[i][j];
                }
                else
                {
                    for (int j = 0; j < n; j++) flattenBoard[index++] = board[i][j];
                }
                reverse = !reverse;
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue((1, 0));
            visited.Add(1);

            while (queue.Count > 0)
            {
                var (square, moves) = queue.Dequeue();

                if (square == n * n) return moves;

                for (int dice = 1; dice <= 6; dice++)
                {
                    int nextSquare = square + dice;
                    if (nextSquare > n * n) break;

                    if (flattenBoard[nextSquare] != -1) nextSquare = flattenBoard[nextSquare];

                    if (!visited.Contains(nextSquare))
                    {
                        visited.Add(nextSquare);
                        queue.Enqueue((nextSquare, moves + 1));
                    }
                }
            }

            return -1;
        }
    }
}
