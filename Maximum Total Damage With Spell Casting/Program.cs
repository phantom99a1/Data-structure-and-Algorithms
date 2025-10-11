namespace Maximum_Total_Damage_With_Spell_Casting
{
    public class Solution
    {
        public long MaximumTotalDamage(int[] powerLevels)
        {
            // Count frequency of each power level
            var powerCount = new Dictionary<int, int>();
            foreach (var p in powerLevels)
                powerCount[p] = powerCount.GetValueOrDefault(p, 0) + 1;

            // Build sorted (power, count) list
            var powerPairs = powerCount
                .Select(kv => (power: kv.Key, count: kv.Value))
                .OrderBy(t => t.power)
                .ToList();

            int n = powerPairs.Count;
            var keys = new int[n]; // power values
            var gain = new long[n]; // power * frequency
            for (int i = 0; i < n; i++)
            {
                keys[i] = powerPairs[i].power;
                gain[i] = (long)powerPairs[i].power * powerPairs[i].count;
            }

            var dp = new long[n]; // best including choices up to i
            var best = new long[n]; // prefix max of dp

            for (int i = 0; i < n; i++)
            {
                // Find last index idx with keys[idx] <= keys[i] - 3
                int target = keys[i] - 3;
                int idx = UpperBound(keys, target) - 1;

                long takeCurrent = gain[i] + (idx >= 0 ? best[idx] : 0);
                long skipCurrent = i > 0 ? dp[i - 1] : 0;
                dp[i] = Math.Max(skipCurrent, takeCurrent);
                best[i] = i > 0 ? Math.Max(best[i - 1], dp[i]) : dp[i];
            }

            return best[n - 1];
        }

        // First index > x
        private int UpperBound(int[] a, int x)
        {
            int lo = 0, hi = a.Length;
            while (lo < hi)
            {
                int mid = (lo + hi) >> 1;
                if (a[mid] <= x) lo = mid + 1; else hi = mid;
            }
            return lo;
        }
    }
}
