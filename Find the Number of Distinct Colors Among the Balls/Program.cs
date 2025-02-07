namespace Find_the_Number_of_Distinct_Colors_Among_the_Balls
{
    /*You are given an integer limit and a 2D array queries of size n x 2.
    There are limit + 1 balls with distinct labels in the range [0, limit]. 
    Initially, all balls are uncolored. For every query in queries that is of the form [x, y], you mark ball x with the color y. 
    After each query, you need to find the number of distinct colors among the balls.
    Return an array result of length n, where result[i] denotes the number of distinct colors after ith query.
    Note that when answering a query, lack of a color will not be considered as a color.
    
    Constraint:
    1 <= limit <= 10^9
    1 <= n == queries.length <= 10^5
    queries[i].length == 2
    0 <= queries[i][0] <= limit
    1 <= queries[i][1] <= 10^9
     */
    
    public class Solution
    {
        private const int minLimit = 1;
        private const int limitConstraint = 1000000000;
        private const int minLength = 1;
        private const int maxQueries = 100000;
        private const int minColumn = 0;
        private const int minValue = 1;
        private const int maxValue = 1000000000;
        public static void Main()
        {
            int limit = GetValidLimit();
            int n = GetValidNumberOfQueries();

            int[][] queries = new int[n][];
            for (int i = 0; i < n; i++)
            {
                queries[i] = GetValidQuery(limit);
            }

            int[] result = QueryResults(limit, queries);
            Console.WriteLine($"Results: [{string.Join(", ", result)}]");
            Console.ReadKey();
        }

        private static int GetValidLimit()
        {
            while (true)
            {
                Console.WriteLine("Enter limit:");
                if (int.TryParse(Console.ReadLine(), out int limit) && limit >= minLimit && limit <= limitConstraint)
                {
                    return limit;
                }
                else
                {
                    Console.WriteLine($"Limit must be a number between {minLimit} and {limitConstraint}.");
                }
            }
        }

        private static int GetValidNumberOfQueries()
        {
            while (true)
            {
                Console.WriteLine("Enter number of queries:");
                if (int.TryParse(Console.ReadLine(), out int n) && n >= minLength && n <= maxQueries)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine($"Number of queries must be a number between {minLength} and {maxQueries}.");
                }
            }
        }

        private static int[] GetValidQuery(int limit)
        {
            while (true)
            {
                Console.WriteLine("Enter query:");
                string input = Console.ReadLine() ?? "";
                try
                {
                    int[] query = Array.ConvertAll(input.Split(' '), int.Parse);
                    if (query.Length == 2 && query[0] >= minColumn && query[0] <= limit && query[1] >= minValue && query[1] <= limit)
                    {
                        return query;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Each query should contain two numbers: x ({minColumn} <= x <= {limit}) and y ({minValue} <= y <= {limit}).");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                }
            }
        }

        public static int[] QueryResults(int limit, int[][] queries)
        {
            var colorMap = new Dictionary<int, int>();
            var colorCount = new Dictionary<int, int>();
            var result = new List<int>();

            foreach (var query in queries)
            {
                int x = query[0], y = query[1];

                if (colorMap.TryGetValue(x, out int value))
                {
                    int oldColor = value;
                    colorCount[oldColor]--;
                    if (colorCount[oldColor] == 0)
                    {
                        colorCount.Remove(oldColor);
                    }
                }

                colorMap[x] = y;
                if (!colorCount.TryGetValue(y, out _))
                {
                    value = 0;
                    colorCount[y] = value;
                }
                colorCount[y] = ++value;

                result.Add(colorCount.Count);
            }
            return [..result];
        }
    }
}
