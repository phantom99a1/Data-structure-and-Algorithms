namespace Find_Champion_II
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public static int FindChampion(int n, int[][] edges)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
            }

            var inDegrees = new int[n];
            foreach (var neighbors in graph.Values)
            {
                foreach (var neighbor in neighbors)
                {
                    inDegrees[neighbor]++;
                }
            }

            var zeroInDegreeTeams = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (inDegrees[i] == 0)
                {
                    zeroInDegreeTeams.Add(i);
                }
            }

            return zeroInDegreeTeams.Count == 1 ? zeroInDegreeTeams[0] : -1;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the number of teams:");
            int n = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Enter the number of edges:");
            int m = int.Parse(Console.ReadLine() ?? "");

            int[][] edges = new int[m][];
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Enter edge {i + 1} (u, v):");
                string[] input = (Console.ReadLine() ?? "").Split(' ');
                edges[i] = [int.Parse(input[0]), int.Parse(input[1])];
            }

            int result = FindChampion(n, edges);
            Console.WriteLine("The champion team is: " + (result == -1 ? "No unique champion" : $"Team {result}"));
            Console.ReadKey();
        }
    }

}
