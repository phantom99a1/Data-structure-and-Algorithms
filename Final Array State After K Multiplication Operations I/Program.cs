namespace Final_Array_State_After_K_Multiplication_Operations_I
{
    /*You are given an integer array nums, an integer k, and an integer multiplier.

    You need to perform k operations on nums. In each operation:

    Find the minimum value x in nums. If there are multiple occurrences of the minimum value, select the one that appears first.
    Replace the selected minimum value x with x * multiplier.
    Return an integer array denoting the final state of nums after performing all k operations.
    Constraints:

    1 <= nums.length <= 100
    1 <= nums[i] <= 100
    1 <= k <= 10
    1 <= multiplier <= 5
    */

    public class Program
    {
        public static void Main()
        {
            // Read and validate the array of integers
            int[] nums;
            while (true)
            {
                Console.Write("Enter the array of integers (space separated): ");
                var input = Console.ReadLine() ?? "";

                try
                {
                    nums = input.Split(' ').Select(int.Parse).ToArray();
                    if (nums.Length >= 1 && nums.Length <= 100 && nums.All(num => num >= 1 && num <= 100))
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

            // Read and validate the number of operations k
            int k;
            while (true)
            {
                Console.Write("Enter the number of operations k: ");
                var kInput = Console.ReadLine();

                if (int.TryParse(kInput, out k) && k >= 1 && k <= 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid non-negative integer for k.");
                    Console.ReadKey();
                }
            }

            // Read and validate the multiplier
            int multiplier;
            while (true)
            {
                Console.Write("Enter the multiplier: ");
                var multiplierInput = Console.ReadLine();

                if (int.TryParse(multiplierInput, out multiplier) && multiplier > 0 && k <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the multiplier.");
                    Console.ReadKey();
                }
            }

            // Calculate and print the final array state
            var result = FinalArrayState(nums, k, multiplier);
            Console.WriteLine("Final array state: [" + string.Join(' ', result) + "]");
            Console.ReadKey();
        }

        // Function to calculate the final array state after K multiplication operations
        public static int[] FinalArrayState(int[] nums, int k, int multiplier)
        {
            for (int i = 0; i < k; i++)
            {
                // Find the index of the minimum element
                int idx = Array.IndexOf(nums, nums.Min());

                // Multiply the minimum element by the multiplier
                nums[idx] *= multiplier;
            }
            return nums;
        }
    }
}
