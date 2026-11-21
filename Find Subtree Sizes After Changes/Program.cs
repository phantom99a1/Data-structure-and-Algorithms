namespace Find_Subtree_Sizes_After_Changes
{
    public class Solution
    {
        private List<int>[] adj;
        private int[] newParent;
        private int[] charAncestor;
        private int[] subtreeSize;
        private string s;

        public int[] FindSubtreeSizes(int[] parent, string s)
        {
            int n = parent.Length;
            this.s = s;
            adj = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }
            for (int i = 1; i < n; i++)
            {
                adj[parent[i]].Add(i);
            }

            newParent = (int[])parent.Clone();
            charAncestor = new int[26];
            Array.Fill(charAncestor, -1);

            Dfs1(0);

            for (int i = 0; i < n; i++)
            {
                adj[i].Clear();
            }
            for (int i = 1; i < n; i++)
            {
                adj[newParent[i]].Add(i);
            }

            subtreeSize = new int[n];
            Dfs2(0);
            return subtreeSize;
        }

        private void Dfs1(int u)
        {
            int c = s[u] - 'a';
            int prev = charAncestor[c];
            if (prev != -1)
            {
                newParent[u] = prev;
            }
            charAncestor[c] = u;

            foreach (int v in adj[u])
            {
                Dfs1(v);
            }

            charAncestor[c] = prev;
        }

        private int Dfs2(int u)
        {
            int sz = 1;
            foreach (int v in adj[u])
            {
                sz += Dfs2(v);
            }
            return subtreeSize[u] = sz;
        }
    }
}
