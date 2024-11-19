namespace MaximumSumDistinctSubarray
{
    public class Program
    {
        public static int MaximumSumDistinctSubarray(int[] nums, int k)
        {
            int n = nums.Length; 
            int maxSum = 0; 
            int currentSum = 0; 
            int start = 0; 
            var set = new HashSet<int>(); 
            for (int end = 0; end < n; end++) 
            { 
                while (set.Contains(nums[end])) 
                { 
                    set.Remove(nums[start]); 
                    currentSum -= nums[start]; 
                    start++; 
                } 
                set.Add(nums[end]); 
                currentSum += nums[end]; 
                if (end - start + 1 == k) 
                { 
                    maxSum = Math.Max(maxSum, currentSum); 
                    set.Remove(nums[start]); 
                    currentSum -= nums[start]; 
                    start++; 
                } 
            }
            return maxSum;
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
            var result = MaximumSumDistinctSubarray(nums, target);
            Console.WriteLine($"Maximum sum of distinct subarray with length {target} is {result}");
            Console.ReadKey();
        }
    }
}
