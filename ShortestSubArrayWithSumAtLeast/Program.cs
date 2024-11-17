namespace ShortestSubArrayWithSumAtLeast
{
    //  Given an integer array nums and an integer k, return the length of the
    //  shortest non-empty subarray of nums with a sum of at least k.If there is no such subarray, return -1.
    //  A subarray is a contiguous part of an array.
    public class Program
    {
        public static int ShortestSubarrayWithSumAtLeastK(int[] nums, int k)
        {
            int n = nums.Length; long[] prefixSum = new long[n + 1]; 
            for (int i = 0; i < n; i++) { 
                prefixSum[i + 1] = prefixSum[i] + nums[i]; 
            }
            var deque = new LinkedList<int>(); 
            int minLength = int.MaxValue; for (int i = 0; i <= n; i++) {
                while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First.Value] >= k) { 
                    minLength = Math.Min(minLength, i - deque.First.Value); deque.RemoveFirst(); 
                } 
                while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last.Value]) {
                    deque.RemoveLast(); 
                } 
                deque.AddLast(i); 
            }
            return minLength == int.MaxValue ? -1 : minLength;
        }
        public static void Main()
        {
            Console.Write("Please enter the elements of the array: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The array isn't empty!");
                Console.ReadKey();
                return;
            }
            string[] stringArray = input.Split(' ');
            int[] nums = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                nums[i] = int.Parse(stringArray[i]);
            }
            Console.WriteLine("Please enter the target: ");
            var targetString = Console.ReadLine();
            if (string.IsNullOrEmpty(targetString))
            {
                Console.WriteLine("The target isn't empty!");
                Console.ReadKey();
                return;
            }

            if (!int.TryParse(targetString, out _))
            {
                Console.WriteLine("The target is invalid!");
                Console.ReadKey();
                return;
            }
            var target = int.Parse(targetString);
            var minLength = ShortestSubarrayWithSumAtLeastK(nums, target);
            Console.WriteLine($"The length of shortest non-subarray of nums with sum at least {target} is: {minLength}");
            Console.ReadKey();
        }
    }
}
