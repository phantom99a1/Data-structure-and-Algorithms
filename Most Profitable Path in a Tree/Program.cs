namespace Most_Profitable_Path_in_a_Tree
{
    /*There is an undirected tree with n nodes labeled from 0 to n - 1, rooted at node 0. You are given a 2D integer array 
    edges of length n - 1 where edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi in the tree.
    At every node i, there is a gate. You are also given an array of even integers amount, where amount[i] represents:
    the price needed to open the gate at node i, if amount[i] is negative, or,
    the cash reward obtained on opening the gate at node i, otherwise.
    The game goes on as follows:
    Initially, Alice is at node 0 and Bob is at node bob.
    At every second, Alice and Bob each move to an adjacent node. 
    Alice moves towards some leaf node, while Bob moves towards node 0.
    For every node along their path, Alice and Bob either spend money to open the gate at that node, 
    or accept the reward. Note that:
    If the gate is already open, no price will be required, nor will there be any cash reward.
    If Alice and Bob reach the node simultaneously, they share the price/reward for opening the gate there. 
    In other words, if the price to open the gate is c, then both Alice and Bob pay c / 2 each. Similarly, 
    if the reward at the gate is c, both of them receive c / 2 each.
    If Alice reaches a leaf node, she stops moving. Similarly, if Bob reaches node 0, he stops moving. 
    Note that these events are independent of each other.
    Return the maximum net income Alice can have if she travels towards the optimal leaf node.
    
     Constraint:
    2 <= n <= 10^5
    edges.length == n - 1
    edges[i].length == 2
    0 <= ai, bi < n
    ai != bi
    edges represents a valid tree.
    1 <= bob < n
    amount.length == n
    amount[i] is an even integer in the range [-10^4, 10^4].
     */
    
    public class Solution
    {
        private const int minLength = 2;
        private const int maxLength = 100000;
        private const int minEdge = 0;
        private const int minBob = 1;
        private const int minValue = -10000;
        private const int maxValue = 10000;
        public static int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            int n = amount.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = [];
            }

            // Step 1: Construct adjacency list for the tree
            foreach (var edge in edges)
            {
                int u = edge[0], v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }

            // Step 2: Find the exact path of Bob from `bob` to `0`
            var bobPath = new Dictionary<int, int>();
            FindBobPath(graph, bob, -1, 0, bobPath);

            // Mark Bob's reach time from his path
            int[] bobTime = new int[n];
            Array.Fill(bobTime, int.MaxValue);
            foreach (var kvp in bobPath)
            {
                bobTime[kvp.Key] = kvp.Value;
            }

            int maxIncome = int.MinValue;
            // Step 3: DFS for Alice to find the most profitable path
            DfsAlice(graph, 0, -1, 0, 0, bobTime, amount, ref maxIncome);

            return maxIncome;
        }

        private static bool FindBobPath(List<int>[] graph, int node, int parent, int depth, Dictionary<int, int> bobPath)
        {
            bobPath[node] = depth;
            if (node == 0) return true;
            foreach (var neighbor in graph[node])
            {
                if (neighbor != parent && FindBobPath(graph, neighbor, node, depth + 1, bobPath))
                {
                    return true;
                }
            }
            bobPath.Remove(node);
            return false;
        }

        private static void DfsAlice(List<int>[] graph, int node, int parent, int currTime, int income, int[] bobTime, int[] amount, ref int maxIncome)
        {
            // Case 1: Alice reaches first -> Full reward
            if (currTime < bobTime[node])
            {
                income += amount[node];
            }
            // Case 2: Both reach at the same time -> Half reward
            else if (currTime == bobTime[node])
            {
                income += amount[node] / 2;
            }
            // Case 3: Bob reaches first -> No reward

            bool isLeaf = true;
            foreach (var neighbor in graph[node])
            {
                if (neighbor != parent)
                {
                    isLeaf = false;
                    DfsAlice(graph, neighbor, node, currTime + 1, income, bobTime, amount, ref maxIncome);
                }
            }

            // If it's a leaf, update maxIncome
            if (isLeaf)
            {
                maxIncome = Math.Max(maxIncome, income);
            }
        }

        public static void Main()
        {            
            int n;
            do
            {
                Console.WriteLine("Enter the number of nodes:");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < minLength || n > maxLength);

            int[][] edges = new int[n - 1][];
            Console.WriteLine($"Enter {n - 1} edges (two integers per edge, separated by a space, {minEdge} <= ai, bi < {n}, ai != bi):");
            for (int i = 0; i < n - 1; i++)
            {
                edges[i] = new int[2];
                string[] edgeInput;
                bool validEdge;
                do
                {
                    edgeInput = (Console.ReadLine() ?? "").Split();
                    validEdge = edgeInput.Length == 2 &&
                                int.TryParse(edgeInput[0], out edges[i][0]) && edges[i][0] >= 0 && edges[i][0] < n &&
                                int.TryParse(edgeInput[1], out edges[i][1]) && edges[i][1] >= 0 && edges[i][1] < n &&
                                edges[i][0] != edges[i][1];
                    if (!validEdge)
                    {
                        Console.WriteLine("Invalid edge. Please enter again:");
                    }
                } while (!validEdge);
            }

            int bob;
            do
            {
                Console.WriteLine($"Enter the starting position of Bob ({minBob} <= bob < {n}):");
            } while (!int.TryParse(Console.ReadLine(), out bob) || bob < minBob || bob >= n);

            int[] amount = new int[n];
            Console.WriteLine($"Enter {n} amounts (even integers in the range [{minValue}, {maxValue}]):");
            for (int i = 0; i < n; i++)
            {
                bool validAmount;
                do
                {
                    validAmount = int.TryParse(Console.ReadLine(), out amount[i]) && amount[i] % 2 == 0 && amount[i] >= minValue && amount[i] <= maxValue;
                    if (!validAmount)
                    {
                        Console.WriteLine("Invalid amount. Please enter again:");
                    }
                } while (!validAmount);
            }

            int result = MostProfitablePath(edges, bob, amount);
            Console.WriteLine($"The most profitable path's income is: {result}");
            Console.ReadKey();
        }
    }
}
