namespace Set_Intersection_Size_At_Least_Two
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int IntersectionSizeTwo(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => {
                if (a[1] != b[1]) return a[1].CompareTo(b[1]);
                return b[0].CompareTo(a[0]); // start desc on tie
            });

            int s = -1, t = -1; // s < t, last two chosen points
            int res = 0;

            foreach (var iv in intervals)
            {
                int start = iv[0], end = iv[1];

                int cnt = 0;
                if (s >= start && s <= end) cnt++;
                if (t >= start && t <= end) cnt++;

                if (cnt >= 2)
                {
                    continue;
                }
                else if (cnt == 1)
                {
                    res += 1;
                    s = t;
                    t = end;
                }
                else
                {
                    res += 2;
                    s = end - 1;
                    t = end;
                }
            }

            return res;
        }
    }
}
