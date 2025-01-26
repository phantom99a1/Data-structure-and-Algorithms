namespace Maximum_Employees_to_Be_Invited_to_a_Meeting
{
    /*A company is organizing a meeting and has a list of n employees, waiting to be invited. 
     * They have arranged for a large circular table, capable of seating any number of employees.
    The employees are numbered from 0 to n - 1. Each employee has a favorite person and they will attend the meeting only 
    if they can sit next to their favorite person at the table. The favorite person of an employee is not themself.
    Given a 0-indexed integer array favorite, where favorite[i] denotes the favorite person of the ith employee, 
    return the maximum number of employees that can be invited to the meeting.
    
    Constraint:
    n == favorite.length
    2 <= n <= 10^5
    0 <= favorite[i] <= n - 1
    favorite[i] != i
     */
    
    public class Solution
    {
        private const int minLength = 2;
        private const int maxLength = 100000;
        private const int minValue = 0;
        public static int MaximumInvitations(int[] favorite)
        {
            int n = favorite.Length;
            int[] indegree = new int[n];
            var pairs = new List<int[]>();
            var map = new Dictionary<int, List<int>>();
            int result = 0;

            // Create indegree array and reverse map
            for (int i = 0; i < n; i++)
            {
                indegree[favorite[i]]++;
                if (favorite[favorite[i]] == i && favorite[i] > i)
                {
                    pairs.Add([i, favorite[i]]);
                }
                if (!map.TryGetValue(favorite[i], out List<int>? value))
                {
                    value = ([]);
                    map[favorite[i]] = value;
                }

                value.Add(i);
            }

            // Start with loose nodes and leave all loop nodes
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (indegree[i] == 0)
                {
                    stack.Push(i);
                }
            }

            while (stack.Count > 0)
            {
                int cur = stack.Pop();
                indegree[favorite[cur]]--;
                if (indegree[favorite[cur]] == 0)
                {
                    stack.Push(favorite[cur]);
                }
            }

            // Go through loop nodes to get a max loop with node count > 2
            for (int i = 0; i < n; i++)
            {
                if (indegree[i] == 1)
                {
                    int count = 1;
                    int start = i;
                    while (favorite[start] != i)
                    {
                        indegree[start]--;
                        start = favorite[start];
                        count++;
                    }
                    result = Math.Max(result, count);
                }
            }

            // Scenario 2: pair favorites can add up
            int pairMax = 0;
            foreach (var pair in pairs)
            {
                int[] max = [1, 1];

                for (int i = 0; i < 2; i++)
                {
                    var pairStack = new Stack<(int, int)>();
                    pairStack.Push((pair[i], 1));

                    while (pairStack.Count > 0)
                    {
                        var (cur, len) = pairStack.Pop();
                        if (!map.ContainsKey(cur))
                        {
                            max[i] = Math.Max(max[i], len);
                            continue;
                        }
                        foreach (int next in map[cur])
                        {
                            if (next == favorite[pair[i]]) continue;
                            pairStack.Push((next, len + 1));
                        }
                    }
                }

                pairMax += max[0] + max[1];
            }
            result = Math.Max(result, pairMax);

            return result;
        }

        public static void Main()
        {
            int[] favorite;
            List<string> errors;

            do
            {
                (favorite, errors) = GetValidInput("Enter the favorite array (elements separated by ','): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = MaximumInvitations(favorite);
            Console.WriteLine("Maximum number of employees to be invited: " + result);
            Console.ReadKey();
        }

        public static (int[], List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            int[] favorite = [];

            try
            {
                favorite = input.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                errors.Add("Invalid integer value in input.");
                return (Array.Empty<int>(), errors);
            }

            int n = favorite.Length;
            if (n < minLength || n > maxLength)
            {
                errors.Add($"The length of the array must be between {minLength} and {maxLength}.");
            }
            if (favorite.Any(val => val < minValue || val >= n))
            {
                errors.Add($"Each element in favorite must be between {minValue} and {n - 1}.");
            }
            if (favorite.Select((val, idx) => new { val, idx }).Any(x => x.val == x.idx))
            {
                errors.Add("Each element must not equal its index.");
            }

            return (favorite, errors);
        }
    }
}
