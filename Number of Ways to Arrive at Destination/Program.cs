namespace Number_of_Ways_to_Arrive_at_Destination
{
    /*You are in a city that consists of n intersections numbered from 0 to n - 1 with bi-directional roads between some 
    intersections. The inputs are generated such that you can reach any intersection from any other intersection and that there 
     is at most one road between any two intersections.
    You are given an integer n and a 2D integer array roads where roads[i] = [ui, vi, timei] means that there is a 
    road between intersections ui and vi that takes timei minutes to travel. You want to know in how many ways you can travel 
    from intersection 0 to intersection n - 1 in the shortest amount of time.
    Return the number of ways you can arrive at your destination in the shortest amount of time. Since the answer may be large, 
    return it modulo 10^9 + 7.
    
    Constraint:
    1 <= n <= 200
    n - 1 <= roads.length <= n * (n - 1) / 2
    roads[i].length == 3
    0 <= ui, vi <= n - 1
    1 <= timei <= 10^9
    ui != vi
    */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int NumberOfWaysToArriveAtDestination(int n, int[][] roads)
        {
            const int MOD = 1_000_000_007;
            var graph = new List<(int, int)>[n];

            for (int i = 0; i < n; i++) graph[i] = new List<(int, int)>();
            foreach (var road in roads)
            {
                graph[road[0]].Add((road[1], road[2]));
                graph[road[1]].Add((road[0], road[2]));
            }

            var dist = new long[n];
            Array.Fill(dist, long.MaxValue);
            var ways = new int[n];
            dist[0] = 0;
            ways[0] = 1;

            var pq = new SortedSet<(long, int)> { (0, 0) };

            while (pq.Count > 0)
            {
                var (currDist, u) = pq.Min;
                pq.Remove(pq.Min);

                if (currDist > dist[u]) continue;

                foreach (var (v, time) in graph[u])
                {
                    var newDist = currDist + time;
                    if (newDist < dist[v])
                    {
                        pq.Remove((dist[v], v));
                        dist[v] = newDist;
                        ways[v] = ways[u];
                        pq.Add((newDist, v));
                    }
                    else if (newDist == dist[v])
                    {
                        ways[v] = (ways[v] + ways[u]) % MOD;
                    }
                }
            }

            return ways[n - 1];
        }

        static void Main()
        {
            int n;
            var roads = new List<int[]>();
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter n (1 <= n <= 200): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 200)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input for n. Please try again.");
                }
            }

            Console.WriteLine("Enter roads as [u, v, time] (one per line, empty line to stop):");
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                var parts = Array.ConvertAll(line.Split(), int.Parse);
                if (
                    parts.Length != 3 ||
                    parts[0] < 0 || parts[0] >= n ||
                    parts[1] < 0 || parts[1] >= n ||
                    parts[0] == parts[1] ||
                    parts[2] < 1 || parts[2] > 1_000_000_000
                )
                {
                    Console.WriteLine("Invalid road input. Please try again.");
                }
                else
                {
                    roads.Add(parts);
                }
            }

            Console.WriteLine("Number of ways to arrive at destination: " +
                NumberOfWaysToArriveAtDestination(n, roads.ToArray()));
        }
    }
}
