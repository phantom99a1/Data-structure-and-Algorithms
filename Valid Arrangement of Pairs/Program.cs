namespace Valid_Arrangement_of_Pairs
{
    /* You are given a 0-indexed 2D integer array pairs where pairs[i] = [starti, endi]. 
     * An arrangement of pairs is valid if for every index i where 1 <= i < pairs.length, we have endi-1 == starti.

        Return any valid arrangement of pairs.

        Note: The inputs will be generated such that there exists a valid arrangement of pairs.*/
    public class Solution
    {
        public static IList<IList<int>> ValidArrangement(IList<IList<int>> pairs)
        {
            var adj = new Dictionary<int, Stack<int>>();
            var indegree = new Dictionary<int, int>();
            var outdegree = new Dictionary<int, int>();

            // Build the graph and degrees
            foreach (var pair in pairs)
            {
                int u = pair[0];
                int v = pair[1];
                if (!adj.ContainsKey(u)) adj[u] = new Stack<int>();
                adj[u].Push(v);
                if (!outdegree.ContainsKey(u)) outdegree[u] = 0;
                outdegree[u]++;
                if (!indegree.ContainsKey(v)) indegree[v] = 0;
                indegree[v]++;
            }

            // Find the start node for Eulerian path
            int start = pairs[0][0];
            foreach (var node in outdegree.Keys)
            {
                if ((outdegree[node] - (indegree.TryGetValue(node, out int value) ? value : 0)) == 1)
                {
                    start = node;
                    break;
                }
            }

            // Eulerian path construction using Hierholzer's Algorithm
            var stack = new Stack<int>();
            var path = new List<int>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                int u = stack.Peek();
                if (adj.TryGetValue(u, out Stack<int>? value) && value.Count > 0)
                {
                    int v = value.Pop();
                    stack.Push(v);
                }
                else
                {
                    path.Add(stack.Pop());
                }
            }

            // Reverse path to get the correct order
            path.Reverse();
            var result = new List<IList<int>>();
            for (int i = 0; i < path.Count - 1; i++)
            {
                result.Add([path[i], path[i + 1]]);
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the number of pairs:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of pairs.");
                return;
            }

            var pairs = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter pair {i + 1} (format: u v):");
                var input = (Console.ReadLine() ?? "").Split(' ');
                if (input.Length != 2 || !int.TryParse(input[0], out int u) || !int.TryParse(input[1], out int v))
                {
                    Console.WriteLine("Invalid input. Please enter two integers separated by a space.");
                    i--; // Repeat this iteration
                    continue;
                }
                pairs.Add([u, v]);
            }

            var result = ValidArrangement(pairs);

            Console.WriteLine("Valid arrangement of pairs:");
            foreach (var pair in result)
            {
                Console.WriteLine($"[{pair[0]}, {pair[1]}]");
            }
            Console.ReadKey();
        }
    }

}
