namespace Number_of_Unique_XOR_Triplets_II
{
    public class Solution
    {
        public int UniqueXorTriplets(int[] nums)
        {
            int m = 0;
            foreach (int v in nums)
            {
                m = Math.Max(m, v);
            }
            int u = 1;
            while (u <= m)
            {
                u <<= 1;
            }
            bool[] one = new bool[u];
            bool[] two = new bool[u];
            bool[] three = new bool[u];
            foreach (int v in nums)
            {
                one[v] = true;
                for (int x = 0; x < u; x++)
                {
                    if (one[x])
                    {
                        two[x ^ v] = true;
                    }
                }
            }
            foreach (int v in nums)
            {
                for (int x = 0; x < u; x++)
                {
                    if (two[x])
                    {
                        three[x ^ v] = true;
                    }
                }
            }
            int ans = 0;
            foreach (bool b in three)
            {
                if (b)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
