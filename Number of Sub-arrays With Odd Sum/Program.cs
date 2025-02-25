namespace Number_of_Sub_arrays_With_Odd_Sum
{
    /*Given an array of integers arr, return the number of subarrays with an odd sum.
    Since the answer can be very large, return it modulo 10^9 + 7.
    
    Constraint:
    1 <= arr.length <= 10^5
    1 <= arr[i] <= 100
     */
    
    public class Program
    {
        public static int CountOddSumSubarrays(int[] arr)
        {
            const int MOD = 1000000007;
            int count = 0, prefixSum = 0, even = 1, odd = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                prefixSum += arr[i];
                if (prefixSum % 2 == 0)
                {
                    count = (count + odd) % MOD;
                    even++;
                }
                else
                {
                    count = (count + even) % MOD;
                    odd++;
                }
            }

            return count;
        }

        public static bool ValidateInput(int[] arr)
        {
            if (arr.Length < 1 || arr.Length > Math.Pow(10, 5))
            {
                Console.WriteLine("Error: Array length must be between 1 and 100000.");
                return false;
            }
            if (arr.Any(n => n < 1 || n > 100))
            {
                Console.WriteLine("Error: Array elements must be between 1 and 100.");
                return false;
            }
            return true;
        }

        public static void Main()
        {
            Console.WriteLine("Enter array elements separated by spaces:");
            string input = Console.ReadLine() ?? "";
            int[] arr = input.Split(' ').Select(int.Parse).ToArray();

            if (ValidateInput(arr))
            {
                Console.WriteLine("Number of sub-arrays with an odd sum: " + CountOddSumSubarrays(arr));
            }
        }
    }
}
