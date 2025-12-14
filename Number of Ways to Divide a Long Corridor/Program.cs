namespace Number_of_Ways_to_Divide_a_Long_Corridor
{
    public class Solution
    {
        public int NumberOfWays(string s)
        {
            const int MOD = 1000000007;
            int seats = 0;

            foreach (char c in s)
            {
                if (c == 'S') seats++;
            }

            if (seats == 0 || seats % 2 == 1) return 0;
            if (seats == 2) return 1;

            List<(int, int)> pairs = new List<(int, int)>();
            int cnt = 0, start = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'S')
                {
                    cnt++;
                    if (cnt % 2 == 1) start = i;
                    else pairs.Add((start, i));
                }
            }

            long ans = 1;
            for (int i = 0; i + 1 < pairs.Count; i++)
            {
                ans = (ans * (pairs[i + 1].Item1 - pairs[i].Item2)) % MOD;
            }

            return (int)ans;
        }
    }
}
