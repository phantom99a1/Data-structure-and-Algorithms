namespace Find_the_Power_of_K_Size_Subarrays_I
{
    /* You are given an array of integers nums of length n and a positive integer k.

    The power of an array is defined as:

    Its maximum element if all of its elements are consecutive and sorted in ascending order.
    -1 otherwise.
    You need to find the power of all subarrays of nums of size k.

    Return an integer array results of size n - k + 1, where results[i] is the power of nums[i..(i + k - 1)].
    */
    public class Program
    {
        public static int[] ResultsArray(int[] nums, int k)
        {
            int n = nums.Length;
            int m = n - k + 1;
            int[] arr = new int[m];

            // Calculate the sum of the first (k-1) elements
            int preSum = 0;
            for (int l = 0; l < k - 1; l++)
            {
                preSum += nums[l];
            }

            int idx = 0;
            for (int i = 0, j = k - 1; j < n; i++, j++, idx++)
            {
                preSum += nums[j]; // Add the new element to the sum

                if (k * (nums[i] + nums[i] + k - 1) / 2 == preSum && nums[i] <= nums[j])
                {
                    arr[idx] = nums[j];
                }
                else
                {
                    arr[idx] = -1;
                }

                preSum -= nums[i]; // Remove the i-th element for the next iteration
            }

            return arr;
        }
        public static void Main(string[] args)
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
            var result = ResultsArray(nums, target);
            Console.WriteLine("The array that statisfy is: {0}", string.Join(", ", result));
            Console.ReadKey();
        }
    }
}
