namespace Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_II
{
    /*There exist two undirected trees with n and m nodes, labeled from [0, n - 1] and [0, m - 1], respectively.
    You are given two 2D integer arrays edges1 and edges2 of lengths n - 1 and m - 1, respectively, where edges1[i] = [ai, bi] 
    indicates that there is an edge between nodes ai and bi in the first tree and edges2[i] = [ui, vi] indicates that there 
    is an edge between nodes ui and vi in the second tree. Node u is target to node v if the number of edges on the path 
    from u to v is even. Note that a node is always target to itself. Return an array of n integers answer, where answer[i] 
    is the maximum possible number of nodes that are target to node i of the first tree if you had to connect one node from 
    the first tree to another node in the second tree. Note that queries are independent from each other. 
    That is, for every query you will remove the added edge before proceeding to the next query.
    
     Constraint:
    2 <= n, m <= 10^5
    edges1.length == n - 1
    edges2.length == m - 1
    edges1[i].length == edges2[i].length == 2
    edges1[i] = [ai, bi]
    0 <= ai, bi < n
    edges2[i] = [ui, vi]
    0 <= ui, vi < m
    The input is generated such that edges1 and edges2 represent valid trees.
     */
    public class Solution
    {
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
        {
            int n = edges1.Length + 1, m = edges2.Length + 1;
            int[] color1 = new int[n];
            int[] color2 = new int[m];
            int[] count1 = Build(edges1, color1);
            int[] count2 = Build(edges2, color2);
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                res[i] = count1[color1[i]] + Math.Max(count2[0], count2[1]);
            }
            return res;
        }

        private int[] Build(int[][] edges, int[] color)
        {
            int n = edges.Length + 1;
            List<int>[] children = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                children[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                children[edge[0]].Add(edge[1]);
                children[edge[1]].Add(edge[0]);
            }
            int res = Dfs(0, -1, 0, children, color);
            return new int[] { res, n - res };
        }

        private int Dfs(int node, int parent, int depth, List<int>[] children,
                        int[] color)
        {
            int res = 1 - depth % 2;
            color[node] = depth % 2;
            foreach (int child in children[node])
            {
                if (child == parent)
                {
                    continue;
                }
                res += Dfs(child, node, depth + 1, children, color);
            }
            return res;
        }
    }
}
