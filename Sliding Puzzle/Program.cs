namespace Sliding_Puzzle
{
    /*On an 2 x 3 board, there are five tiles labeled from 1 to 5, and an empty square represented by 0. 
     * A move consists of choosing 0 and a 4-directionally adjacent number and swapping it.

    The state of the board is solved if and only if the board is [[1,2,3],[4,5,0]].

    Given the puzzle board board, return the least number of moves required so that the state of the board is solved. 
    If it is impossible for the state of the board to be solved, return -1.
    */
    public class Solution
    {
        public static int SlidingPuzzle(int[][] board)
        {
            string target = "123450";
            string start = string.Join("", board.SelectMany(row => row));
            int[][] directions = [
            [1, 3], [0, 2, 4], [1, 5],
            [0, 4], [1, 3, 5], [2, 4]
        ];
            var queue = new Queue<(string, int, int)>();
            var visited = new HashSet<string> { start };

            queue.Enqueue((start, start.IndexOf('0'), 0));

            while (queue.Count > 0)
            {
                var (current, zeroIndex, step) = queue.Dequeue();
                if (current == target) return step;

                foreach (var dir in directions[zeroIndex])
                {
                    char[] newBoard = current.ToCharArray();
                    (newBoard[zeroIndex], newBoard[dir]) = (newBoard[dir], newBoard[zeroIndex]);
                    string newBoardStr = new string(newBoard);

                    if (!visited.Contains(newBoardStr))
                    {
                        visited.Add(newBoardStr);
                        queue.Enqueue((newBoardStr, dir, step + 1));
                    }
                }
            }

            return -1;
        }

        public static void Main()
        {
            int[][] board = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                string input;
                do
                {
                    Console.Write($"Enter elements of row {i + 1} separated by space: ");
                    input = Console.ReadLine() ?? "";
                } while (string.IsNullOrWhiteSpace(input));

                board[i] = input.Split(' ').Select(int.Parse).ToArray();
            }

            int result = SlidingPuzzle(board);
            Console.WriteLine("Minimum number of moves: " + result);
            Console.ReadKey();
        }
    }
}
