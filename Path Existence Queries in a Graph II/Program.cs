namespace Path_Existence_Queries_in_a_Graph_II
{
    public class Solution
    {
        public int[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
        {
            // Step 1: Sort values and create mappings
            var (sortedValues, originalPositionMap) = CreateSortedNodeMapping(n, nums);

            // Step 2: Precompute maximum reachable indices
            int[] furthestReachable = PrecomputeFurthestReachable(sortedValues, n, maxDiff);

            // Step 3: Build jump table for binary lifting
            const int maxLiftingLevels = 17;
            int[][] jumpTable = BuildBinaryLiftingTable(furthestReachable, n, maxLiftingLevels);

            // Step 4: Assign connected components
            int[] nodeComponents = DetermineConnectedComponents(furthestReachable, n);

            // Step 5: Process each query
            int[] results = new int[queries.Length];

            for (int q = 0; q < queries.Length; q++)
            {
                int u = queries[q][0];
                int v = queries[q][1];

                if (u == v)
                {
                    results[q] = 0;
                    continue;
                }

                if (Math.Abs(nums[u] - nums[v]) <= maxDiff)
                {
                    results[q] = 1;
                    continue;
                }

                int positionU = originalPositionMap[u];
                int positionV = originalPositionMap[v];
                int a = Math.Min(positionU, positionV);
                int b = Math.Max(positionU, positionV);

                if (nodeComponents[a] != nodeComponents[b])
                {
                    results[q] = -1;
                    continue;
                }

                results[q] = ComputeMinimumSteps(a, b, jumpTable, maxLiftingLevels);
            }

            return results;
        }

        static (int[] SortedValues, int[] OriginalPositionMap) CreateSortedNodeMapping(int n, int[] nums)
        {
            var sortedList = new List<(int Value, int Index)>();

            for (int i = 0; i < n; i++)
                sortedList.Add((nums[i], i));

            sortedList.Sort();

            int[] sortedValues = new int[n];
            int[] sortedIndices = new int[n];
            int[] originalPositionMap = new int[n];

            for (int pos = 0; pos < n; pos++)
            {
                sortedValues[pos] = sortedList[pos].Value;
                sortedIndices[pos] = sortedList[pos].Index;
            }

            for (int pos = 0; pos < n; pos++)
                originalPositionMap[sortedIndices[pos]] = pos;

            return (sortedValues, originalPositionMap);
        }

        static int[] PrecomputeFurthestReachable(int[] sortedValues, int n, int maxDiff)
        {
            int[] furthestReachable = new int[n];

            for (int i = 0; i < n; i++)
            {
                int targetUpper = sortedValues[i] + maxDiff;
                int left = i, right = n - 1;
                int result = i;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (sortedValues[mid] <= targetUpper)
                    {
                        result = mid;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                furthestReachable[i] = result;
            }

            return furthestReachable;
        }

        static int[][] BuildBinaryLiftingTable(int[] reachable, int n, int maxLevels)
        {
            int[][] jumpTable = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jumpTable[i] = new int[maxLevels];
                jumpTable[i][0] = reachable[i];
            }

            for (int level = 1; level < maxLevels; level++)
            {
                for (int i = 0; i < n; i++)
                {
                    int previousJump = jumpTable[i][level - 1];

                    if (previousJump >= n)
                        jumpTable[i][level] = previousJump;
                    else
                        jumpTable[i][level] = Math.Max(previousJump, jumpTable[previousJump][level - 1]);
                }
            }

            return jumpTable;
        }

        static int[] DetermineConnectedComponents(int[] reachable, int n)
        {
            int[] components = new int[n];
            int currentComponent = 0;
            int currentReach = reachable[0];
            components[0] = currentComponent;

            for (int i = 1; i < n; i++)
            {
                if (i > currentReach)
                {
                    currentComponent++;
                    currentReach = reachable[i];
                }

                components[i] = currentComponent;
                currentReach = Math.Max(currentReach, reachable[i]);
            }

            return components;
        }

        static int ComputeMinimumSteps(int a, int b, int[][] jumpTable, int maxLevels)
        {
            if (a >= b)
                return 0;

            int steps = 0;
            int current = a;

            for (int level = maxLevels - 1; level >= 0; level--)
            {
                if (jumpTable[current][level] >= b)
                    continue;

                steps += 1 << level;
                current = jumpTable[current][level];

                if (current >= b)
                    return steps;
            }

            return steps + 1;
        }
    }
}
