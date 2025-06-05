namespace Lexicographically_Smallest_Equivalent_String
{
    using System;

    public class UnionFind
    {
        private int[] parent;

        public UnionFind()
        {
            parent = new int[26];
            for (int i = 0; i < 26; i++) parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]); // Path compression
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX != rootY)
            {
                if (rootX < rootY) parent[rootY] = rootX;
                else parent[rootX] = rootY;
            }
        }
    }

    public class Solution
    {
        public static string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            UnionFind uf = new UnionFind();

            for (int i = 0; i < s1.Length; i++)
            {
                uf.Union(s1[i] - 'a', s2[i] - 'a');
            }

            char[] result = new char[baseStr.Length];
            for (int i = 0; i < baseStr.Length; i++)
            {
                result[i] = (char)(uf.Find(baseStr[i] - 'a') + 'a');
            }

            return new string(result);
        }

        public static void Main()
        {
            Console.WriteLine(SmallestEquivalentString("parker", "morris", "parser")); // Output: "makkek"
        }
    }
}
