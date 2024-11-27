namespace Shortest_Distance_After_Road_Addition_Queries_I
{
    /*You are given an integer n and a 2D integer array queries.

    There are n cities numbered from 0 to n - 1. Initially, 
    there is a unidirectional road from city i to city i + 1 for all 0 <= i < n - 1.

    queries[i] = [ui, vi] represents the addition of a new unidirectional road from city ui to city vi. 
    After each query, you need to find the length of the shortest path from city 0 to city n - 1.

    Return an array answer where for each i in the range [0, queries.length - 1], 
    answer[i] is the length of the shortest path from city 0 to city n - 1 after processing the first i + 1 queries.
    */
    public class Program
    {
        private static void UpdateDistances(List<int>[] graph, int current, int[] distances)
        {
            int newDist = distances[current] + 1;

            foreach (int neighbor in graph[current])
            {
                if (distances[neighbor] <= newDist)
                {
                    continue;
                }

                distances[neighbor] = newDist;
                UpdateDistances(graph, neighbor, distances);
            }
        }

        public static int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            int[] distances = new int[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = n - 1 - i;
            }

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            for (int i = 0; i < n - 1; i++)
            {
                graph[i + 1].Add(i);
            }

            var answer = new List<int>();

            foreach (var query in queries)
            {
                int source = query[0];
                int target = query[1];

                graph[target].Add(source);
                distances[source] = Math.Min(distances[source], distances[target] + 1);
                UpdateDistances(graph, source, distances);

                answer.Add(distances[0]);
            }

            return [.. answer];
        }

        public static void Main()
        {
            Console.WriteLine("Enter the number of cities (n):");
            int n = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Enter the number of queries:");
            int q = int.Parse(Console.ReadLine() ?? "");
            int[][] queries = new int[q][];
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine($"Enter query {i + 1} (u v):");
                string[] input = (Console.ReadLine() ?? "").Split(' ');
                queries[i] = [int.Parse(input[0]), int.Parse(input[1])];
            }
            var result = ShortestDistanceAfterQueries(n, queries);
            Console.WriteLine("The lengths of the shortest paths after each query are: [{0}", string.Join(",", result) + "]");
            Console.ReadKey();
        }
    }
}