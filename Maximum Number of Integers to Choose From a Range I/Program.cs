namespace Maximum_Number_of_Integers_to_Choose_From_a_Range_I
{
    #region Description
    /*You are given an integer array banned and two integers n and maxSum. 
     * You are choosing some number of integers following the below rules:

    The chosen integers have to be in the range [1, n].
    Each integer can be chosen at most once.
    The chosen integers should not be in the array banned.
    The sum of the chosen integers should not exceed maxSum.
    Return the maximum number of integers you can choose following the mentioned rules.*/
    #endregion
    public class Program
    {
        public static void Main()
        {
            var banned = ParseArrayInput("Enter the banned integers (comma-separated): ");
            int n = GetPositiveInteger("Enter the value of n (upper bound of the range): ");
            int maxSum = GetPositiveInteger("Enter the value of maxSum (maximum sum): ");

            int result = MaxIntegers(banned, n, maxSum);
            Console.WriteLine($"The maximum number of integers you can choose is: {result}");
            Console.ReadKey();
        }

        public static int GetPositiveInteger(string prompt)
        {
            int value;
            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out value) || value <= 0)
                {
                    Console.WriteLine("Input must be a positive integer. Please try again.");
                }
            } while (value <= 0);
            return value;
        }

        public static List<int> ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            return input.Split(',').Select(int.Parse).ToList();
        }

        public static int MaxIntegers(List<int> banned, int n, int maxSum)
        {
            var bannedSet = new HashSet<int>(banned);
            int sum = 0;
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (!bannedSet.Contains(i) && (sum + i) <= maxSum)
                {
                    sum += i;
                    count++;
                }
            }

            return count;
        }
    }
}
