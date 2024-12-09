namespace Special_Array_II
{
    /*An array is considered special if every pair of its adjacent elements contains two numbers with different parity.

    You are given an array of integer nums and a 2D integer matrix queries, where for queries[i] = [fromi, toi] 
    your task is to check that 
    subarray
     nums[fromi..toi] is special or not.

    Return an array of booleans answer such that answer[i] is true if nums[fromi..toi] is special.*/
    public class Program
    {
        public static void Main()
        {
            try
            {
                int[] nums = ParseArrayInput("Enter the numbers in the array (comma-separated): ");
                int[][] queries = ParseMatrixInput("Enter the queries (as [[from,to],[from,to],...] format): ");
                bool[] result = IsSpecialArray(nums, queries);
                Console.WriteLine("The result array is: [" + string.Join(", ", result.Select(r => r.ToString()).ToArray()) + "]");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static int[] ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            return input.Split(',').Select(int.Parse).ToArray();
        }

        public static int[][] ParseMatrixInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = (Console.ReadLine() ?? "").Trim('[', ']');
            return input.Split("],[").Select(queryString =>
            {
                var parts = queryString.Split(',').Select(int.Parse).ToArray();
                if (parts.Length != 2)
                {
                    throw new Exception("Invalid input format. Each query must have exactly two numeric values separated by commas.");
                }
                return parts;
            }).ToArray();
        }

        public static bool[] IsSpecialArray(int[] nums, int[][] queries)
        {
            int n = nums.Length;
            int[] prefixParity = new int[n];
            prefixParity[0] = nums[0] % 2;

            for (int i = 1; i < n; i++)
            {
                prefixParity[i] = prefixParity[i - 1];
                if ((nums[i] % 2) != (nums[i - 1] % 2))
                {
                    prefixParity[i]++;
                }
            }

            bool[] result = new bool[queries.Length];

            for (int k = 0; k < queries.Length; k++)
            {
                int from = queries[k][0];
                int to = queries[k][1];

                if (from == to)
                {
                    result[k] = true;
                }
                else
                {
                    result[k] = (prefixParity[to] - prefixParity[from] == (to - from));
                }
            }

            return result;
        }
    }

}
