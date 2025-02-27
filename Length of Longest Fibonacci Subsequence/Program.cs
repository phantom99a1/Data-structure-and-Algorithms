namespace Length_of_Longest_Fibonacci_Subsequence
{
    /*A sequence x1, x2, ..., xn is Fibonacci-like if:
    n >= 3
    xi + xi+1 == xi+2 for all i + 2 <= n
    Given a strictly increasing array arr of positive integers forming a sequence, return the length of the longest 
    Fibonacci-like subsequence of arr. If one does not exist, return 0.
    A subsequence is derived from another sequence arr by deleting any number of elements (including none) from arr,
    without changing the order of the remaining elements. For example, [3, 5, 8] is a subsequence of [3, 4, 5, 6, 7, 8].
    
    Constraint:
    3 <= arr.length <= 1000
    1 <= arr[i] < arr[i + 1] <= 10^9
     */

    public class Solution
    {
        private const int minLength = 3;
        private const int maxLength = 1000;
        private const int minValue = 1;
        private const int maxValue = 1000000000;
        private static bool ValidateInput(string input, out List<string> errorMessages)
        {
            errorMessages = new List<string>();
            var elements = input.Split(' ');

            if (!elements.All(e => int.TryParse(e, out int _)))
            {
                errorMessages.Add("Input contains non-integer values.");
            }
            else
            {
                var arr = Array.ConvertAll(elements, int.Parse);
                if (arr.Length < minLength || arr.Length > maxLength)
                {
                    errorMessages.Add($"Array length must be between {minLength} and {maxLength}.");
                }
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] >= arr[i + 1] || arr[i] < minValue || arr[i + 1] > maxValue)
                    {
                        errorMessages.Add($"Invalid values at position {i} and {i + 1}.");
                        break;
                    }
                }
            }
            return errorMessages.Count == 0;
        }

        public static int LenLongestFibSubseq(int[] arr)
        {
            int n = arr.Length;
            var indexMap = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                indexMap[arr[i]] = i;
            }

            var dp = new int[n, n];
            int maxLen = 0;

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    int prev = arr[j] - arr[i];
                    if (prev < arr[i] && indexMap.TryGetValue(prev, out int value))
                    {
                        int k = value;
                        dp[i, j] = dp[k, i] + 1;
                        maxLen = Math.Max(maxLen, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = 2;
                    }
                }
            }

            return maxLen > 2 ? maxLen : 0;
        }

        private static int[] GetValidInput()
        {
            List<string> errorMessages;
            int[]? result = null;
            do
            {
                Console.Write("Enter an array of integers: ");
                string input = Console.ReadLine() ?? "";
                if (ValidateInput(input, out errorMessages))
                {
                    result = Array.ConvertAll(input.Split(' '), int.Parse);
                }
                else
                {
                    foreach (var message in errorMessages)
                    {
                        Console.WriteLine(message);
                    }
                }
            } while (result == null);
            return result;
        }

        public static void Main()
        {
            var validInput = GetValidInput();
            Console.WriteLine("Length of Longest Fibonacci Subsequence: " + LenLongestFibSubseq(validInput));
            Console.ReadKey();
        }
    }
}
