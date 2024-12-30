namespace Count_Ways_To_Build_Good_Strings
{
    /*Given the integers zero, one, low, and high, we can construct a string by starting with an empty string, 
     and then at each step perform either of the following:
    Append the character '0' zero times.
    Append the character '1' one times.
    This can be performed any number of times.
    A good string is a string constructed by the above process having a length between low and high (inclusive).
    Return the number of different good strings that can be constructed satisfying these properties. 
    Since the answer can be large, return it modulo 10^9 + 7.
    
    Constraint:
    1 <= low <= high <= 10^5
    1 <= zero, one <= low
     */

    public class Solution
    {
        public static int CountGoodStrings(int low, int high, int zero, int one)
        {
            const int MOD = 1000000007;
            int[] dp = new int[high + 1];
            dp[0] = 1;

            for (int i = 1; i <= high; i++)
            {
                if (i >= zero) dp[i] = (dp[i] + dp[i - zero]) % MOD;
                if (i >= one) dp[i] = (dp[i] + dp[i - one]) % MOD;
            }

            int result = 0;
            for (int i = low; i <= high; i++)
            {
                result = (result + dp[i]) % MOD;
            }

            return result;
        }

        public static bool ValidateInput(int low, int high, int zero, int one)
        {
            int maxValue = 100000;
            int minValue = 1;
            return minValue <= low && low <= high && high <= maxValue &&
                   minValue <= zero && zero <= low &&
                   minValue <= one && one <= low;
        }

        public static void Main()
        {
            Console.WriteLine("Enter low, high, zero, one (comma-separated):");
            string input = Console.ReadLine() ?? "";
            int[] values = input.Split(',').Select(int.Parse).ToArray();

            if (ValidateInput(values[0], values[1], values[2], values[3]))
            {
                int result = CountGoodStrings(values[0], values[1], values[2], values[3]);
                Console.WriteLine("Number of ways to build good strings: " + result);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please follow the constraints.");
                Console.ReadKey();
            }
        }
    }
}
