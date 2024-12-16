namespace Count_the_number_of_pair_sum_greater_than_k
{
    /*
    Given an array a consisting of n elements and a positive integer k. 
    Count the number of pairs of numbers ai, aj (i != j) whose sum is greater than k.

    Constraints
    2<=n<=10^6;
    1<=k<=10^6;
    0<=a[i]<=10^6;
    */

    public class Program
    {
        public static void Main()
        {
            // Read and validate the number of test cases
            int t;
            while (true)
            {
                Console.Write("Enter the number of test cases: ");
                var tInput = Console.ReadLine();

                if (int.TryParse(tInput, out t) && t > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of test cases.");
                    Console.ReadKey();
                }
            }

            for (int testCase = 1; testCase <= t; testCase++)
            {
                Console.WriteLine($"Test Case {testCase}:");

                int[]? nums = null;
                int k = 0;

                // Read and validate the array of integers
                while (true)
                {
                    Console.Write("Enter the array of integers (space separated): ");
                    var input = Console.ReadLine() ?? "";

                    try
                    {
                        nums = input.Split(' ').Select(int.Parse).ToArray();
                        if (nums.Length > 1 && nums.Length <= Math.Pow(10,6) && nums.All(num => num >= 0 && num <= Math.Pow(10, 6)))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a non-empty array of integers.");
                            Console.ReadKey();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please enter valid integers.");
                        Console.ReadKey();
                    }
                }

                // Read and validate the positive integer k
                while (true)
                {
                    Console.Write("Enter the positive integer k: ");
                    var kInput = Console.ReadLine();

                    if (int.TryParse(kInput, out k) && k >= 1 && k <= Math.Pow(10, 6))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for k.");
                        Console.ReadKey();
                    }
                }

                // Calculate and print the number of pairs whose sum is greater than k
                long count = CountPairsWithSumGreaterThanK(nums, k);
                Console.WriteLine($"Number of pairs whose sum is greater than {k}: {count}");
                Console.ReadKey();
            }
        }

        // Function to count pairs whose sum is greater than k
        public static long CountPairsWithSumGreaterThanK(int[] nums, int k)
        {
            long count = 0;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int target = k - nums[i];
                int index = BinarySearch(nums, target, i + 1);

                if (index != -1)
                {
                    count += nums.Length - index;
                }
            }

            return count;
        }

        // Binary search to find the first element greater than target
        public static int BinarySearch(int[] nums, int target, int start)
        {
            int left = start, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left < nums.Length ? left : -1;
        }
    }
}
