namespace Count_Covered_Buildings
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int CountCoveredBuildings(int n, int[][] buildings)
        {
            // Group buildings by row (y) and column (x)
            var rowMap = new Dictionary<int, List<int>>();
            var colMap = new Dictionary<int, List<int>>();

            foreach (var b in buildings)
            {
                int x = b[0], y = b[1];
                if (!rowMap.ContainsKey(y)) rowMap[y] = new List<int>();
                if (!colMap.ContainsKey(x)) colMap[x] = new List<int>();
                rowMap[y].Add(x);
                colMap[x].Add(y);
            }

            // Sort each row and column list
            foreach (var kv in rowMap) kv.Value.Sort();
            foreach (var kv in colMap) kv.Value.Sort();

            int covered = 0;
            foreach (var b in buildings)
            {
                int x = b[0], y = b[1];

                var row = rowMap[y];
                var col = colMap[x];

                // Check if building has left and right neighbors
                int idxRow = row.BinarySearch(x);
                bool hasLeft = idxRow > 0;
                bool hasRight = idxRow < row.Count - 1;

                // Check if building has above and below neighbors
                int idxCol = col.BinarySearch(y);
                bool hasAbove = idxCol > 0;
                bool hasBelow = idxCol < col.Count - 1;

                if (hasLeft && hasRight && hasAbove && hasBelow)
                {
                    covered++;
                }
            }

            return covered;
        }
    }
}
