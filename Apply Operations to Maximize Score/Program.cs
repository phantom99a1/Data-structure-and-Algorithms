namespace Apply_Operations_to_Maximize_Score
{
    /*You are given an array nums of n positive integers and an integer k.
    Initially, you start with a score of 1. You have to maximize your score by applying the following operation at most k times:
    Choose any non-empty subarray nums[l, ..., r] that you haven't chosen previously.
    Choose an element x of nums[l, ..., r] with the highest prime score. If multiple such elements exist, choose the one with 
    the smallest index. Multiply your score by x.
    Here, nums[l, ..., r] denotes the subarray of nums starting at index l and ending at the index r, both ends being inclusive.
    The prime score of an integer x is equal to the number of distinct prime factors of x. For example, 
    the prime score of 300 is 3 since 300 = 2 * 2 * 3 * 5 * 5.
    Return the maximum possible score after applying at most k operations.
    Since the answer may be large, return it modulo 10^9 + 7.
    
     Constraint:
    1 <= nums.length == n <= 10^5
    1 <= nums[i] <= 10^5
    1 <= k <= min(n * (n + 1) / 2, 10^9)
     */
    public class Solution
    {
        private const int MOD = 1000000007;

        public static int MaximumScore(IList<int> nums, int k)
        {
            int n = nums.Count;
            List<int> primeScores = new List<int>(Enumerable.Repeat(0, n));

            // Calculate the prime score for each number in nums
            for (int index = 0; index < n; index++)
            {
                int num = nums[index];

                // Check for prime factors from 2 to sqrt(n)
                for (int factor = 2; factor <= Math.Sqrt(num); factor++)
                {
                    if (num % factor == 0)
                    {
                        // Increment prime score for each prime factor
                        primeScores[index]++;

                        // Remove all occurrences of the prime factor from num
                        while (num % factor == 0) num /= factor;
                    }
                }

                // If num is still greater than or equal to 2, it's a prime factor
                if (num >= 2) primeScores[index]++;
            }

            // Initialize next and previous dominant index arrays
            int[] nextDominant = new int[n];
            int[] prevDominant = new int[n];
            Array.Fill(nextDominant, n);
            Array.Fill(prevDominant, -1);

            // Stack to store indices for monotonic decreasing prime score
            Stack<int> decreasingPrimeScoreStack = new Stack<int>();

            // Calculate the next and previous dominant indices for each number
            for (int index = 0; index < n; index++)
            {
                // While the stack is not empty and the current prime score is greater than the stack's top
                while (
                    decreasingPrimeScoreStack.Count > 0 &&
                    primeScores[decreasingPrimeScoreStack.Peek()] < primeScores[index]
                )
                {
                    int topIndex = decreasingPrimeScoreStack.Pop();

                    // Set the next dominant element for the popped index
                    nextDominant[topIndex] = index;
                }

                // If the stack is not empty, set the previous dominant element for the current index
                if (decreasingPrimeScoreStack.Count > 0)
                    prevDominant[index] = decreasingPrimeScoreStack.Peek();

                // Push the current index onto the stack
                decreasingPrimeScoreStack.Push(index);
            }

            // Calculate the number of subarrays in which each element is dominant
            long[] numOfSubarrays = new long[n];
            for (int index = 0; index < n; index++)
            {
                numOfSubarrays[index] =
                    ((long)nextDominant[index] - index) *
                    (index - prevDominant[index]);
            }

            // Priority queue to process elements in decreasing order of their value
            var processingQueue = new PriorityQueue<(int value, int index), int>(
                Comparer<int>.Create((a, b) => b.CompareTo(a)));

            // Push each number and its index onto the priority queue
            for (int index = 0; index < n; index++)
            {
                processingQueue.Enqueue((nums[index], index), nums[index]);
            }

            long score = 1;

            // Process elements while there are operations left
            while (k > 0 && processingQueue.Count > 0)
            {
                // Get the element with the maximum value from the queue
                var top = processingQueue.Dequeue();
                int num = top.value;
                int index = top.index;

                // Calculate the number of operations to apply on the current element
                long operations = Math.Min((long)k, numOfSubarrays[index]);

                // Update the score by raising the element to the power of operations
                score = (score * Power(num, operations)) % MOD;

                // Reduce the remaining operations count
                k -= (int)operations;
            }

            return (int)score;
        }

        // Helper function to compute the power of a number modulo MOD
        private static long Power(long baseNum, long exponent)
        {
            long res = 1;

            // Calculate the exponentiation using binary exponentiation
            while (exponent > 0)
            {
                // If the exponent is odd, multiply the result by the base
                if (exponent % 2 == 1)
                {
                    res = (res * baseNum) % MOD;
                }

                // Square the base and halve the exponent
                baseNum = (baseNum * baseNum) % MOD;
                exponent /= 2;
            }

            return res;
        }
    }
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the length of nums (n): ");
                    int n = int.Parse(Console.ReadLine());
                    if (n < 1 || n > 100000) throw new Exception("Invalid n: 1 <= n <= 10^5");

                    Console.Write($"Enter {n} numbers separated by space: ");
                    int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    if (nums.Length != n) throw new Exception("Invalid nums: The length of nums must equal n");
                    if (nums.Any(x => x < 1 || x > 100000)) throw new Exception("Invalid nums: 1 <= nums[i] <= 10^5 for each i");

                    Console.Write("Enter k: ");
                    int k = int.Parse(Console.ReadLine());
                    if (k < 1 || k > Math.Min((long)n * (n + 1) / 2, 1000000000))
                        throw new Exception("Invalid k: 1 <= k <= min(n * (n + 1) / 2, 10^9)");

                    Console.WriteLine("Inputs are valid!");
                    Console.WriteLine($"The result: {Solution.MaximumScore(nums, k)}");
                    Console.ReadKey();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
