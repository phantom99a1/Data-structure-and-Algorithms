namespace Maximum_Sum_of_3_Non_Overlapping_Subarrays
{
    /*Given an integer array nums and an integer k, find three non-overlapping subarrays of length k 
     * with maximum sum and return them.

    Return the result as a list of indices representing the starting position of each interval (0-indexed). 
    If there are multiple answers, return the lexicographically smallest one.

    Constraint
    1 <= nums.length <= 2 * 10^4
    1 <= nums[i] < 2^16
    1 <= k <= floor(nums.length / 3)
    */
    public class Solution
    {
        public static int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            int n = nums.Length;
            int[] sum = new int[n + 1];
            int[] left = new int[n];
            int[] right = new int[n];

            for (int i = 0; i < n; i++)
            {
                sum[i + 1] = sum[i] + nums[i];
            }

            int maxSum = sum[k] - sum[0];
            for (int i = k; i < n; i++)
            {
                if (sum[i + 1] - sum[i + 1 - k] > maxSum)
                {
                    maxSum = sum[i + 1] - sum[i + 1 - k];
                    left[i] = i + 1 - k;
                }
                else
                {
                    left[i] = left[i - 1];
                }
            }

            maxSum = sum[n] - sum[n - k];
            for (int i = n - k; i >= 0; i--)
            {
                if (sum[i + k] - sum[i] >= maxSum)
                {
                    maxSum = sum[i + k] - sum[i];
                    right[i] = i;
                }
                else
                {
                    right[i] = right[i + 1];
                }
            }

            int maxTotal = 0;
            int[] result = new int[3];
            for (int i = k; i <= n - 2 * k; i++)
            {
                int l = left[i - 1];
                int r = right[i + k];
                int total = (sum[i + k] - sum[i]) + (sum[l + k] - sum[l]) + (sum[r + k] - sum[r]);
                if (total > maxTotal)
                {
                    maxTotal = total;
                    result[0] = l;
                    result[1] = i;
                    result[2] = r;
                }
            }

            return result;
        }

        public static bool ValidateInput(int[] nums, int k)
        {
            int maxLength = 2 * 10000;
            int maxValue = 65536; //2^16
            if (nums.Length < 1 || nums.Length > maxLength)
            {
                return false;
            }
            if (k < 1 || k > nums.Length / 3)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num >= maxValue)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the nums array (comma-separated):");
            string numsInput = Console.ReadLine() ?? "";
            int[] nums = numsInput.Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("Enter k:");
            int k = int.Parse(Console.ReadLine() ?? "");

            if (ValidateInput(nums, k))
            {
                int[] result = MaxSumOfThreeSubarrays(nums, k);
                Console.WriteLine("Starting indices of the maximum sum of 3 non-overlapping subarrays: [" + string.Join(", ", result) + "]");
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
