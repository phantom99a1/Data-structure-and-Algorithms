namespace Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_I
{
    /*There exist two undirected trees with n and m nodes, with distinct labels in ranges [0, n - 1] and [0, m - 1], respectively.
    You are given two 2D integer arrays edges1 and edges2 of lengths n - 1 and m - 1, respectively, where edges1[i] = [ai, bi] 
    indicates that there is an edge between nodes ai and bi in the first tree and edges2[i] = [ui, vi] indicates that there is an 
    edge between nodes ui and vi in the second tree. You are also given an integer k.
    Node u is target to node v if the number of edges on the path from u to v is less than or equal to k. Note that a node is 
    always target to itself. Return an array of n integers answer, where answer[i] is the maximum possible number of nodes target 
    to node i of the first tree if you have to connect one node from the first tree to another node in the second tree.
    Note that queries are independent from each other. That is, for every query you will remove the added edge before 
    proceeding to the next query.
    
     Constraint:
    2 <= n, m <= 1000
    edges1.length == n - 1
    edges2.length == m - 1
    edges1[i].length == edges2[i].length == 2
    edges1[i] = [ai, bi]
    0 <= ai, bi < n
    edges2[i] = [ui, vi]
    0 <= ui, vi < m
    The input is generated such that edges1 and edges2 represent valid trees.
    0 <= k <= 1000
     */
    public class Solution
    {
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
        {
            int n = edges1.Length + 1;
            int m = edges2.Length + 1;

            List<int>[] tree1 = BuildTree(n, edges1);
            List<int>[] tree2 = BuildTree(m, edges2);

            // Precompute number of reachable nodes from each node in tree2 within distance (k - 1)
            int maxReachInTree2 = 0;
            for (int i = 0; i < m; i++)
            {
                int reach = BfsCount(tree2, i, k - 1);
                maxReachInTree2 = Math.Max(maxReachInTree2, reach);
            }

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                int reach = BfsCount(tree1, i, k);
                result[i] = reach + maxReachInTree2;
            }

            return result;
        }
        private List<int>[] BuildTree(int size, int[][] edges)
        {
            List<int>[] tree = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                tree[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]);
                tree[edge[1]].Add(edge[0]);
            }
            return tree;
        }

        private int BfsCount(List<int>[] tree, int start, int maxDist)
        {
            if (maxDist < 0) return 0;

            bool[] visited = new bool[tree.Length];
            Queue<(int node, int dist)> queue = new Queue<(int node, int dist)>();
            visited[start] = true;
            queue.Enqueue((start, 0));

            int count = 0;

            while (queue.Count > 0)
            {
                var (node, dist) = queue.Dequeue();
                count++;

                if (dist == maxDist) continue;

                foreach (int neighbor in tree[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue((neighbor, dist + 1));
                    }
                }
            }

            return count;
        }
    }
}
