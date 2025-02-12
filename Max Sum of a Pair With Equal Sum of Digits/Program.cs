namespace Max_Sum_of_a_Pair_With_Equal_Sum_of_Digits
{
    /*You are given a 0-indexed array nums consisting of positive integers. You can choose two indices i and j, 
     * such that i != j, and the sum of digits of the number nums[i] is equal to that of nums[j].
    Return the maximum value of nums[i] + nums[j] that you can obtain over all possible indices i and j that satisfy the conditions.
    
    Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
     */
    
    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = (int)1e5;
        private const int minValue = 1;
        private const int maxValue = (int)1e9;
        public static bool IsValidInput(string input, out List<string> errors)
        {
            errors = new List<string>();
            int num;
            string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (!int.TryParse(token, out num))
                {
                    errors.Add($"'{token}' is not a valid number.");
                }
                else if (num < 1 || num > 1000000000)
                {
                    errors.Add($"'{num}' must be between 1 and 10^9.");
                }
            }

            return errors.Count == 0;
        }

        public static int[] GetValidInput(string prompt)
        {
            List<int> nums = new List<int>();

            Console.WriteLine(prompt);

            while (true)
            {
                string input = Console.ReadLine() ?? "";
                if (input.ToLower() == "done")
                {
                    if (nums.Count == 0)
                    {
                        Console.WriteLine("Please enter at least one number.");
                        continue;
                    }
                    else
                    {
                        return nums.ToArray();
                    }
                }
                else
                {
                    if (IsValidInput(input, out List<string> errors))
                    {
                        string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string token in tokens)
                        {
                            nums.Add(int.Parse(token));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Errors in input:");
                        foreach (string error in errors)
                        {
                            Console.WriteLine("- " + error);
                        }
                    }
                }
            }
        }

        private static int GetDigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        public static int MaximumSum(int[] nums)
        {
            var sumMap = new Dictionary<int, int>();
            int maxSum = -1;

            foreach (int num in nums)
            {
                int digitSum = GetDigitSum(num);

                if (sumMap.TryGetValue(digitSum, out int value))
                {
                    int prevNum = value;
                    maxSum = Math.Max(maxSum, prevNum + num);
                    sumMap[digitSum] = Math.Max(prevNum, num);
                }
                else
                {
                    sumMap[digitSum] = num;
                }
            }

            return maxSum;
        }

        public static void Main()
        {
            int[] validNums = GetValidInput("Enter numbers separated by commas:");

            Console.WriteLine("Valid numbers entered:");
            foreach (int num in validNums)
            {
                Console.WriteLine(num);
            }

            int result = MaximumSum(validNums);
            Console.WriteLine("Maximum Sum of Pair with Equal Digit Sum: " + result);
            Console.ReadKey();
        }
    }

}
