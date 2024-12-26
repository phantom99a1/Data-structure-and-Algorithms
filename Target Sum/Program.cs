namespace Target_Sum
{
    /*You are given an integer array nums and an integer target.

    You want to build an expression out of nums by adding one of the symbols '+' and '-' 
    before each integer in nums and then concatenate all the integers.

    For example, if nums = [2, 1], you can add a '+' before 2 and a '-' 
    before 1 and concatenate them to build the expression "+2-1".
    Return the number of different expressions that you can build, which evaluates to target.
    
    Constraint:
    1 <= nums.length <= 20
    0 <= nums[i] <= 1000
    0 <= sum(nums[i]) <= 1000
    -1000 <= target <= 1000
     */
    
    public class Solution
    {
        private readonly Dictionary<string, int> memo = [];
        
        public int FindTargetSumWays(int[] nums, int target)
        {
            return Calculate(nums, target, 0, 0);
        }
        
        private int Calculate(int[] nums, int target, int i, int sum)
        {
            if (i == nums.Length)
            {
                return sum == target ? 1 : 0;
            }

            string key = $"{i},{sum}";
            if (memo.TryGetValue(key, out int value))
            {
                return value;
            }

            int add = Calculate(nums, target, i + 1, sum + nums[i]);
            int subtract = Calculate(nums, target, i + 1, sum - nums[i]);

            memo[key] = add + subtract;
            return add + subtract;
        }

        public static bool ValidateInput(int[] nums, int target)
        {
            if (nums.Length < 1 || nums.Length > 20)
            {
                return false;
            }
            if (target < -1000 || target > 1000)
            {
                return false;
            }
            int sum = 0;
            foreach (int num in nums)
            {
                if (num < 0 || num > 1000)
                {
                    return false;
                }
                sum += num;
            }
            if (sum < 0 || sum > 1000)
            {
                return false;
            }
            return true;
        }

        public static void Main()
        {
            var solution = new Solution();

            Console.WriteLine("Enter the numbers (comma-separated):");
            string numsInput = Console.ReadLine() ?? "";
            int[] nums = Array.ConvertAll(numsInput.Split(','), int.Parse);

            Console.WriteLine("Enter the target:");
            int target = int.Parse(Console.ReadLine() ?? "");

            if (ValidateInput(nums, target))
            {
                int result = solution.FindTargetSumWays(nums, target);
                Console.WriteLine("Number of ways: " + result);
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
