namespace Minimum_Limit_of_Balls_in_a_Bag
{
    #region Description
    /*You are given an integer array nums where the ith bag contains nums[i] balls. 
     * You are also given an integer maxOperations.

    You can perform the following operation at most maxOperations times:

    Take any bag of balls and divide it into two new bags with a positive number of balls.
    For example, a bag of 5 balls can become two new bags of 1 and 4 balls, or two new bags of 2 and 3 balls.
    Your penalty is the maximum number of balls in a bag. You want to minimize your penalty after the operations.

    Return the minimum possible penalty after performing the operations.*/
    #endregion
    public class Solution
    {
        public static void Main()
        {
            var nums = ParseArrayInput("Enter the number of balls in each bag (comma-separated): ");
            int maxOperations = GetNonNegativeInteger("Enter the number of max operations: ");

            if (maxOperations < 0)
            {
                Console.WriteLine("Invalid input. The number of max operations must be a non-negative integer.");
                Console.ReadKey();
                return;
            }

            int result = MinimumSize(nums, maxOperations);
            Console.WriteLine($"The minimum possible value of the maximum number of balls in any bag is: {result}");
            Console.ReadKey();
        }

        public static int GetNonNegativeInteger(string prompt)
        {
            int value;
            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out value) || value < 0)
                {
                    Console.WriteLine("Input must be a non-negative integer. Please try again.");
                }
            } while (value < 0);
            return value;
        }

        public static List<int> ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            return input.Split(',').Select(int.Parse).ToList();
        }

        public static bool CanDistribute(List<int> nums, int maxOperations, int mid)
        {
            int operations = 0;
            foreach (int num in nums)
            {
                operations += (num - 1) / mid;
                if (operations > maxOperations)
                {
                    return false;
                }
            }
            return true;
        }

        public static int MinimumSize(List<int> nums, int maxOperations)
        {
            int left = 1;
            int right = nums.Max();
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (CanDistribute(nums, maxOperations, mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
    }
}