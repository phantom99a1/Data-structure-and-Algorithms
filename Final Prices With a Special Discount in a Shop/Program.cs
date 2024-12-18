namespace Final_Prices_With_a_Special_Discount_in_a_Shop
{
    /*You are given an integer array prices where prices[i] is the price of the ith item in a shop.

    There is a special discount for items in the shop. If you buy the ith item, 
    then you will receive a discount equivalent to prices[j] where j is the minimum index such that j > i 
    and prices[j] <= prices[i]. Otherwise, you will not receive any discount at all.

    Return an integer array answer where answer[i] is the final price you will pay for the ith item of the shop, 
    considering the special discount.

    Constraints:
    1 <= prices.length <= 500
    1 <= prices[i] <= 1000
    */

    public class Program
    {
        public static void Main()
        {
            int[]? prices = null;

            // Read and validate the input prices
            while (true)
            {
                Console.Write("Enter the prices as space-separated integers: ");
                var input = Console.ReadLine() ?? "";

                try
                {
                    prices = input.Split(' ').Select(int.Parse).ToArray();
                    if (prices.Length > 0 && prices.Length <= 500 && prices.All(price => price >= 1 && price <= 1000))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a list of space-separated non-negative integers.");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a list of space-separated integers.");
                    Console.ReadKey();
                }
            }

            // Calculate the final prices with discount
            int[] finalPrices = CalculateFinalPrices(prices);
            Console.WriteLine("Final prices with discount: [" + string.Join(" ", finalPrices) + "]");
            Console.ReadKey();
        }

        public static int[] CalculateFinalPrices(int[] prices)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                {
                    prices[stack.Pop()] -= prices[i];
                }
                stack.Push(i);
            }
            return prices;
        }
    }
}
