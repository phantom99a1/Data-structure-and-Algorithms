namespace Minimum_Cost_to_Acquire_Required_Items
{
    public class Solution
    {
        public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2) =>
            Math.Min(need1, need2) * (long)Math.Min(costBoth, cost1 + cost2) +
                (need1 > need2
                    ? (need1 - need2) * (long)Math.Min(cost1, costBoth)
                    : (need2 - need1) * (long)Math.Min(cost2, costBoth));
    }
}
