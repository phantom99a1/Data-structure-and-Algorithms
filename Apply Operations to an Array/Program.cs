namespace Apply_Operations_to_an_Array
{
    /*You are given a 0-indexed array nums of size n consisting of non-negative integers.
    You need to apply n - 1 operations to this array where, in the ith operation (0-indexed), 
    you will apply the following on the ith element of nums:
    If nums[i] == nums[i + 1], then multiply nums[i] by 2 and set nums[i + 1] to 0. Otherwise, you skip this operation.
    After performing all the operations, shift all the 0's to the end of the array.
    For example, the array [1,0,2,0,0,1] after shifting all its 0's to the end, is [1,2,1,0,0,0].
    Return the resulting array.
    Note that the operations are applied sequentially, not all at once.
    
    Constraint:
    2 <= nums.length <= 2000
    0 <= nums[i] <= 1000
     */
    
    public class Program
    {
        private const int MIN_LENGTH = 2;
        private const int MAX_LENGTH = 2000;
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 1000;

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter an array of non-negative integers separated by spaces: ");
                string input = Console.ReadLine() ?? "";
                int[] nums = input.Split(' ').Select(n =>
                {
                    bool success = int.TryParse(n, out int result);
                    if (!success || result < MIN_VALUE || result > MAX_VALUE)
                    {
                        Console.WriteLine($"Error: {n} is not a valid number. Each number should be a non-negative integer between {MIN_VALUE} and {MAX_VALUE}.");
                        return -1; // This is for representation purposes, it will be validated in IsValidInput.
                    }
                    return result;
                }).ToArray();

                if (IsValidInput(nums))
                {
                    int[] result = ApplyOperations(nums);
                    Console.WriteLine("Resulting array: " + string.Join(", ", result));
                    Console.ReadKey();
                    break;
                }
            }
        }

        public static bool IsValidInput(int[] nums)
        {
            if (nums.Length < MIN_LENGTH || nums.Length > MAX_LENGTH)
            {
                Console.WriteLine($"Error: Array length should be between {MIN_LENGTH} and {MAX_LENGTH}.");
                return false;
            }
            foreach (var num in nums)
            {
                if (num < MIN_VALUE || num > MAX_VALUE)
                {
                    return false; // Error already printed in the main function.
                }
            }
            return true;
        }

        public static int[] ApplyOperations(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] *= 2;
                    nums[i + 1] = 0;
                }
            }
            // Shift all 0's to the end
            List<int> result = [];
            int countZero = 0;
            foreach (int num in nums)
            {
                if (num != 0)
                {
                    result.Add(num);
                }
                else
                {
                    countZero++;
                }
            }
            for (int i = 0; i < countZero; i++)
            {
                result.Add(0);
            }
            return [.. result];
        }
    }
}
