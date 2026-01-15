namespace Maximize_Area_of_Square_Hole_in_Grid
{
    using System;

    public class Solution
    {
        public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
        {
            int h = Longest(hBars);
            int v = Longest(vBars);
            int side = Math.Min(h, v);
            return side * side;
        }

        private int Longest(int[] a)
        {
            Array.Sort(a);
            int best = 1, cur = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == a[i - 1] + 1) cur++;
                else cur = 1;
                if (cur > best) best = cur;
            }
            return best + 1;
        }
    }
}
