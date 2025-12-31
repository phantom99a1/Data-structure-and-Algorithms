namespace Last_Day_Where_You_Can_Still_Cross
{
    public class Solution
    {
        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            int n = row * col;
            int top = n, bottom = n + 1;

            int[] parent = new int[n + 2];
            int[] rank = new int[n + 2];
            bool[,] grid = new bool[row, col];

            for (int i = 0; i < n + 2; i++) parent[i] = i;

            int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);
                return parent[x];
            }

            void Union(int a, int b)
            {
                a = Find(a);
                b = Find(b);
                if (a == b) return;
                if (rank[a] < rank[b]) parent[a] = b;
                else
                {
                    parent[b] = a;
                    if (rank[a] == rank[b]) rank[a]++;
                }
            }

            int[] dr = { 1, -1, 0, 0 };
            int[] dc = { 0, 0, 1, -1 };

            for (int d = n - 1; d >= 0; d--)
            {
                int r = cells[d][0] - 1;
                int c = cells[d][1] - 1;
                grid[r, c] = true;
                int id = r * col + c;

                if (r == 0) Union(id, top);
                if (r == row - 1) Union(id, bottom);

                for (int k = 0; k < 4; k++)
                {
                    int nr = r + dr[k];
                    int nc = c + dc[k];
                    if (nr >= 0 && nr < row && nc >= 0 && nc < col && grid[nr, nc])
                    {
                        Union(id, nr * col + nc);
                    }
                }

                if (Find(top) == Find(bottom)) return d;
            }
            return 0;
        }
    }
}
