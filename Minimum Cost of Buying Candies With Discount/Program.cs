namespace Minimum_Cost_of_Buying_Candies_With_Discount
{
    public class Solution
    {
        public int MinimumCost(int[] cost)
        {
            Array.Sort(cost, (a, b) => b.CompareTo(a));
            (int i, int total) = (0, 0);
            while (i < cost.Length)
            {
                total += cost[i];
                if (i + 1 < cost.Length)
                {
                    total += cost[i + 1];
                }

                i += 3;
            }

            return total;
        }
    }
}
