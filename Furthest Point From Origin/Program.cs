using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furthest_Point_From_Origin
{
    public class Solution
    {
        public int FurthestDistanceFromOrigin(string moves)
        {
            int L = 0, R = 0, B = 0;
            foreach (char c in moves)
            {
                if (c == 'L')
                {
                    L++;
                }
                else if (c == 'R')
                {
                    R++;
                }
                else
                {
                    B++;
                }
            }
            return Math.Abs(L - R) + B;
        }
    }
}
