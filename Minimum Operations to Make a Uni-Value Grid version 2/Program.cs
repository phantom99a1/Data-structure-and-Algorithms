using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Operations_to_Make_a_Uni_Value_Grid_version_2
{
    using System.Collections.Generic;

    public class Solution
    {
        public int MinOperations(int[][] grid, int x)
        {
            List<int> arr = new List<int>();
            foreach (var row in grid)
            {
                foreach (var num in row)
                {
                    arr.Add(num);
                }
            }

            arr.Sort();
            int median = arr[arr.Count / 2];
            int operations = 0;

            foreach (int num in arr)
            {
                int diff = Math.Abs(num - median);
                if (diff % x != 0) return -1;
                operations += diff / x;
            }
            return operations;
        }
    }
}
