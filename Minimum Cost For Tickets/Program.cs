namespace Minimum_Cost_For_Tickets
{
    /*You have planned some train traveling one year in advance. 
     * The days of the year in which you will travel are given as an integer array days. Each day is an integer from 1 to 365.
    Train tickets are sold in three different ways:
    a 1-day pass is sold for costs[0] dollars,
    a 7-day pass is sold for costs[1] dollars, and
    a 30-day pass is sold for costs[2] dollars.
    The passes allow that many days of consecutive travel.
    For example, if we get a 7-day pass on day 2, then we can travel for 7 days: 2, 3, 4, 5, 6, 7, and 8.
    Return the minimum number of dollars you need to travel every day in the given list of days.
    
     Constraint:
    1 <= days.length <= 365
    1 <= days[i] <= 365
    days is in strictly increasing order.
    costs.length == 3
    1 <= costs[i] <= 1000
     */
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the days (comma-separated): ");
            var inputDays = Console.ReadLine() ?? "";
            int[] days = inputDays.Split(',').Select(int.Parse).ToArray();

            if (!IsValidDays(days))
            {
                Console.WriteLine("Invalid input for days.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the costs (comma-separated): ");
            var inputCosts = Console.ReadLine() ?? "";
            int[] costs = inputCosts.Split(',').Select(int.Parse).ToArray();

            if (!IsValidCosts(costs))
            {
                Console.WriteLine("Invalid input for costs.");
                Console.ReadKey();
                return;
            }

            int minCost = MinCostTickets(days, costs);
            Console.WriteLine($"The minimum cost is: {minCost}");
            Console.ReadKey();
        }

        public static bool IsValidDays(int[] days)
        {
            if (days.Length < 1 || days.Length > 365) return false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] < 1 || days[i] > 365) return false;
                if (i > 0 && days[i] <= days[i - 1]) return false;
            }
            return true;
        }

        public static bool IsValidCosts(int[] costs)
        {
            return costs.Length == 3 && costs.All(cost => cost >= 1 && cost <= 1000);
        }

        static int MinCostTickets(int[] days, int[] costs)
        {
            int[] dp = new int[366];
            var daySet = new HashSet<int>(days);

            for (int i = 1; i <= 365; i++)
            {
                if (!daySet.Contains(i))
                {
                    dp[i] = dp[i - 1];
                }
                else
                {
                    dp[i] = Math.Min(
                        dp[i - 1] + costs[0],
                        Math.Min(
                            dp[Math.Max(0, i - 7)] + costs[1],
                            dp[Math.Max(0, i - 30)] + costs[2]
                        )
                    );
                }
            }

            return dp[365];
        }
    }
}
