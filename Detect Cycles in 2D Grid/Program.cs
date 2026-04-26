using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detect_Cycles_in_2D_Grid
{
    public class Solution
    {
        public bool ContainsCycle(char[][] a)
        {
            var Y = a.Length;
            var X = a[0].Length;
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { -1, 0, 1, 0 };
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    var c = a[y][x];
                    if (c != Char.ToLower(c))
                        continue;

                    Queue<(int, int)> q = new Queue<(int, int)>();
                    q.Enqueue((x, y));
                    while (q.Count() != 0)
                    {
                        var xy = q.Dequeue();
                        if (a[xy.Item2][xy.Item1] != Char.ToLower(a[xy.Item2][xy.Item1]))
                            return true;

                        a[xy.Item2][xy.Item1] = Char.ToUpper(a[xy.Item2][xy.Item1]);
                        for (int i = 0; i < 4; i++)
                        {
                            int xx = xy.Item1 + dx[i];
                            int yy = xy.Item2 + dy[i];
                            if (xx >= 0 && xx < X && yy >= 0 && yy < Y && a[yy][xx] == c)
                                q.Enqueue((xx, yy));
                        }
                    }
                }
            }

            return false;
        }
    }
}
