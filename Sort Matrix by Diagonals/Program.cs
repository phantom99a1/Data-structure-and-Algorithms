namespace Sort_Matrix_by_Diagonals
{
    public class Solution
    {
        public int[][] SortMatrix(int[][] grid)
        {
            int n = grid.Length, m = grid[0].Length;
            var maxHeaps = new Dictionary<int, PriorityQueue<int, int>>();
            var minHeaps = new Dictionary<int, PriorityQueue<int, int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int key = i - j;
                    if (key < 0)
                    {
                        if (!minHeaps.ContainsKey(key))
                            minHeaps[key] = new PriorityQueue<int, int>();
                        minHeaps[key].Enqueue(grid[i][j], grid[i][j]);
                    }
                    else
                    {
                        if (!maxHeaps.ContainsKey(key))
                            maxHeaps[key] = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
                        maxHeaps[key].Enqueue(grid[i][j], grid[i][j]);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int key = i - j;
                    if (key < 0) grid[i][j] = minHeaps[key].Dequeue();
                    else grid[i][j] = maxHeaps[key].Dequeue();
                }
            }
            return grid;
        }
    }
}
