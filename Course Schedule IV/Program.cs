namespace Course_Schedule_IV
{
    /*There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array 
     * prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course ai first if you want to take course bi.
    For example, the pair [0, 1] indicates that you have to take course 0 before you can take course 1.
    Prerequisites can also be indirect. If course a is a prerequisite of course b, and course b is a prerequisite of course c, 
    then course a is a prerequisite of course c.
    You are also given an array queries where queries[j] = [uj, vj]. 
    For the jth query, you should answer whether course uj is a prerequisite of course vj or not.
    Return a boolean array answer, where answer[j] is the answer to the jth query.
    
    Constraint:
    2 <= numCourses <= 100
    0 <= prerequisites.length <= (numCourses * (numCourses - 1) / 2)
    prerequisites[i].length == 2
    0 <= ai, bi <= numCourses - 1
    ai != bi
    All the pairs [ai, bi] are unique.
    The prerequisites graph has no cycles.
    1 <= queries.length <= 10^4
    0 <= ui, vi <= numCourses - 1
    ui != vi
     */
    public class Solution
    {
        private const int minCourses = 2;
        private const int maxCourses = 100;
        private const int minPrerequisitesLength = 0;
        private const int minCoursesValue = 0;
        private const int minQueriesLength = 1;
        private const int maxQueriesLength = 10000;
        private const int minQueriesValue = 0;
        public static void Main()
        {
            int numCourses;
            List<(int, int)> prerequisites;
            List<(int, int)> queries;
            List<string> errors;

            do
            {
                (numCourses, prerequisites, queries, errors) = GetValidInput("Enter the number of courses, prerequisites, and queries (format: numCourses;prerequisite1_a,prerequisite1_b|...;query1_u,query1_v|...): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = checkIfPrerequisite(numCourses, prerequisites, queries);
            Console.WriteLine("Query Results: " + string.Join(", ", result));
            Console.ReadKey();
        }

        public static (int, List<(int, int)>, List<(int, int)>, List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(';');
            var prerequisites = new List<(int, int)>();
            var queries = new List<(int, int)>();

            if (!int.TryParse(parts[0], out int numCourses))
            {
                errors.Add("Number of courses must be a number.");
            }
            else
            {
                if (numCourses < minCourses || numCourses > maxCourses)
                {
                    errors.Add($"Number of courses must be between {minCourses} and {maxCourses}.");
                }
            }

            if (parts.Length > 1)
            {
                var prerequisitesInput = parts[1].Split('|');
                if (prerequisitesInput.Length > (numCourses * (numCourses - 1)) / 2)
                {
                    errors.Add($"Number of prerequisites must be between {minPrerequisitesLength} and {(numCourses * (numCourses - 1)) / 2}.");
                }
                foreach (var pr in prerequisitesInput)
                {
                    var pair = pr.Split(',');
                    if (pair.Length != 2 || !int.TryParse(pair[0], out int a) || !int.TryParse(pair[1], out int b))
                    {
                        errors.Add($"Prerequisite pair [{pr}] is invalid.");
                    }
                    else
                    {
                        if (a < minCoursesValue || a >= numCourses || b < minCoursesValue || b >= numCourses || a == b)
                        {
                            errors.Add($"Prerequisite pair [{a}, {b}] is invalid.");
                        }
                        else
                        {
                            prerequisites.Add((a, b));
                        }
                    }
                }
            }

            if (parts.Length > 2)
            {
                var queriesInput = parts[2].Split('|');
                if (queriesInput.Length < minQueriesLength || queriesInput.Length > maxQueriesLength)
                {
                    errors.Add($"Number of queries must be between {minQueriesLength} and {maxQueriesLength}.");
                }
                foreach (var q in queriesInput)
                {
                    var pair = q.Split(',');
                    if (pair.Length != 2 || !int.TryParse(pair[0], out int u) || !int.TryParse(pair[1], out int v))
                    {
                        errors.Add($"Query pair [{q}] is invalid.");
                    }
                    else
                    {
                        if (u < minQueriesValue || u >= numCourses || v < minQueriesValue || v >= numCourses || u == v)
                        {
                            errors.Add($"Query pair [{u}, {v}] is invalid.");
                        }
                        else
                        {
                            queries.Add((u, v));
                        }
                    }
                }
            }

            return (numCourses, prerequisites, queries, errors);
        }

        public static List<bool> checkIfPrerequisite(int numCourses, List<(int, int)> prerequisites, List<(int, int)> queries)
        {
            bool[,] reachability = new bool[numCourses, numCourses];
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
                reachability[i, i] = true;
            }

            foreach (var (a, b) in prerequisites)
            {
                graph[a].Add(b);
            }

            for (int i = 0; i < numCourses; i++)
            {
                DFS(i, i, graph, reachability);
            }

            return queries.Select(query => reachability[query.Item1, query.Item2]).ToList();
        }

        public static void DFS(int start, int node, List<int>[] graph, bool[,] reachability)
        {
            foreach (var neighbor in graph[node])
            {
                if (!reachability[start, neighbor])
                {
                    reachability[start, neighbor] = true;
                    DFS(start, neighbor, graph, reachability);
                }
            }
        }
    }
}
