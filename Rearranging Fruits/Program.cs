namespace Rearranging_Fruits
{
    internal class Program
    {
        public static long MinCost(int[] basket1, int[] basket2)
        {
            var freq = new Dictionary<int, int>();
            foreach (var fruit in basket1) freq[fruit] = freq.GetValueOrDefault(fruit, 0) + 1;
            foreach (var fruit in basket2) freq[fruit] = freq.GetValueOrDefault(fruit, 0) - 1;

            var excess = new List<int>();
            foreach (var kvp in freq)
            {
                if (kvp.Value % 2 != 0) return -1;
                for (int i = 0; i < Math.Abs(kvp.Value) / 2; i++) excess.Add(kvp.Key);
            }

            excess.Sort();
            int minFruit = freq.Keys.Min();
            long cost = 0;
            for (int i = 0; i < excess.Count / 2; i++)
            {
                cost += Math.Min(excess[i], 2 * minFruit);
            }
            return cost;
        }
    }
}
