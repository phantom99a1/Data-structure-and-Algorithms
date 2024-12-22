namespace Find_Building_Where_Alice_and_Bob_Can_Meet
{
    /*You are given a 0-indexed array heights of positive integers, where heights[i] represents the height of the ith building.

    If a person is in building i, they can move to any other building j if and only if i < j and heights[i] < heights[j].

    You are also given another array queries where queries[i] = [ai, bi]. On the ith query, 
    Alice is in building ai while Bob is in building bi.

    Return an array ans where ans[i] is the index of the leftmost building 
    where Alice and Bob can meet on the ith query. If Alice and Bob cannot move to a common building on query i, set ans[i] to -1.
    
    Constraints:
    1 <= heights.length <= 5 * 10^4
    1 <= heights[i] <= 10^9
    1 <= queries.length <= 5 * 10^4
    queries[i] = [ai, bi]
    0 <= ai, bi <= heights.length - 1
     */

    public class Solution
    {
        public static int[] FindMeetingBuildings(int[] heights, int[][] queries)
        {
            int n = heights.Length;
            int q = queries.Length;
            int[] result = Enumerable.Repeat(-1, q).ToArray();
            var deferred = new List<(int, int)>[n];
            for (int i = 0; i < n; ++i) deferred[i] = [];
            var minHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                int result = a.Item1.CompareTo(b.Item1);
                if (result == 0)
                    result = a.Item2.CompareTo(b.Item2);
                return result;
            }));

            for (int i = 0; i < q; ++i)
            {
                int a = queries[i][0], b = queries[i][1];
                if (a > b) (a, b) = (b, a);
                if (a == b || heights[a] < heights[b]) result[i] = b;
                else deferred[b].Add((heights[a], i));
            }

            for (int i = 0; i < n; ++i)
            {
                foreach (var query in deferred[i])
                    minHeap.Add(query);

                while (minHeap.Count > 0 && heights[i] > minHeap.Min.Item1)
                {
                    var query = minHeap.Min;
                    minHeap.Remove(minHeap.Min);
                    result[query.Item2] = i;
                }
            }

            return result;
        }

        public static void Main()
        {
            Console.Write("Enter the heights of the buildings as space-separated integers: ");
            int[] heights = Array.ConvertAll((Console.ReadLine() ?? "").Split(' '), int.Parse);

            Console.Write("Enter the queries as space-separated pairs (e.g., '0 1 1 2'): ");
            int[][] queries = ParseQueries(Console.ReadLine() ?? "", heights.Length);

            if (ValidateInput(heights, queries))
            {
                int[] result = FindMeetingBuildings(heights, queries);
                Console.WriteLine("Indexes of leftmost buildings where Alice and Bob can meet: [" + string.Join(", ", result) + "]");
                Console.ReadKey();
            }
        }

        private static bool ValidateInput(int[] heights, int[][] queries)
        {
            int n = heights.Length;
            int maxLength = 50000;
            int maxValue = 1000000000;

            if (n < 1 || n > maxLength)
            {
                Console.WriteLine($"Invalid input: Number of buildings (n) must be between 1 and {maxLength}.");
                Console.ReadKey();
                return false;
            }

            if (!heights.All(h => h > 0 && h <= maxValue))
            {
                Console.WriteLine($"Invalid input: Heights should be positive integers and should not exceed {maxValue}.");
                Console.ReadKey();
                return false;
            }

            if (!queries.All(q => q.Length == 2 && q[0] >= 0 && q[0] < n && q[1] >= 0 && q[1] < n))
            {
                Console.WriteLine("Invalid input: Ensure queries are valid pairs of indices."); 
                Console.ReadKey();
                return false;
            }

            return true;
        }

        private static int[][] ParseQueries(string input, int n)
        {
            string[] parts = input.Split(' ');
            int[][] queries = new int[parts.Length / 2][];
            for (int i = 0; i < parts.Length; i += 2)
            {
                queries[i / 2] = [int.Parse(parts[i]), int.Parse(parts[i + 1])];
            }
            return queries;
        }
    }
}