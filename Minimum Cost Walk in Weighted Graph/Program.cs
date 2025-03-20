namespace Minimum_Cost_Walk_in_Weighted_Graph
{
    /*There is an undirected weighted graph with n vertices labeled from 0 to n - 1.
    You are given the integer n and an array edges, where edges[i] = [ui, vi, wi] indicates that there is an edge between 
    vertices ui and vi with a weight of wi.
    A walk on a graph is a sequence of vertices and edges. The walk starts and ends with a vertex, and each edge connects 
    the vertex that comes before it and the vertex that comes after it. It's important to note that a walk may visit the
    same edge or vertex more than once.
    The cost of a walk starting at node u and ending at node v is defined as the bitwise AND of the weights of the edges 
    traversed during the walk. In other words, if the sequence of edge weights encountered during the walk is 
    w0, w1, w2, ..., wk, then the cost is calculated as w0 & w1 & w2 & ... & wk, where & denotes the bitwise AND operator.
    You are also given a 2D array query, where query[i] = [si, ti]. For each query, you need to find the minimum cost of the 
    walk starting at vertex si and ending at vertex ti. If there exists no such walk, the answer is -1.
    Return the array answer, where answer[i] denotes the minimum cost of a walk for query i.
    
    Constraint:
    2 <= n <= 105
    0 <= edges.length <= 10^5
    edges[i].length == 3
    0 <= ui, vi <= n - 1
    ui != vi
    0 <= wi <= 10^5
    1 <= query.length <= 10^5
    query[i].length == 2
    0 <= si, ti <= n - 1
    si != ti
     */
    public class Solution
    {
        public int[] MinimumCost(int n, int[][] edges, int[][] query)
        {
            int[] parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            int[] minPathCost = new int[n];
            Array.Fill(minPathCost, -1);

            int FindRoot(int node)
            {
                if (parent[node] != node)
                {
                    parent[node] = FindRoot(parent[node]);
                }
                return parent[node];
            }

            foreach (var edge in edges)
            {
                int source = edge[0], target = edge[1], weight = edge[2];
                int sourceRoot = FindRoot(source);
                int targetRoot = FindRoot(target);

                minPathCost[targetRoot] &= weight;

                if (sourceRoot != targetRoot)
                {
                    minPathCost[targetRoot] &= minPathCost[sourceRoot];
                    parent[sourceRoot] = targetRoot;
                }
            }

            int[] result = new int[query.Length];

            for (int i = 0; i < query.Length; i++)
            {
                int start = query[i][0], end = query[i][1];

                if (start == end) result[i] = 0;
                else if (FindRoot(start) != FindRoot(end)) result[i] = -1;
                else result[i] = minPathCost[FindRoot(start)];
            }

            return result;
        }
    }
}
