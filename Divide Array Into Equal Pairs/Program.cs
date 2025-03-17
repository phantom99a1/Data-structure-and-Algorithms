namespace Divide_Array_Into_Equal_Pairs
{
    /*You are given an integer array nums consisting of 2 * n integers.
    You need to divide nums into n pairs such that:
    Each element belongs to exactly one pair.
    The elements present in a pair are equal.
    Return true if nums can be divided into n pairs, otherwise return false.
    
    Constraint:
    nums.length == 2 * n
    1 <= n <= 500
    1 <= nums[i] <= 500
     */
    
    class Program
    {
        static bool IsValidInput(List<int> nums, int n)
        {
            if (nums.Count != 2 * n)
            {
                Console.WriteLine($"Error: nums.length must be 2 * n. Current nums.length: {nums.Count}");
                return false;
            }
            if (n < 1 || n > 500)
            {
                Console.WriteLine($"Error: n must be between 1 and 500. Current n: {n}");
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 500)
                {
                    Console.WriteLine($"Error: Each number must be between 1 and 500. Invalid number: {num}");
                    return false;
                }
            }
            return true;
        }

        static bool DivideArray(List<int> nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                    freq[num] = 0;
                freq[num]++;
            }
            return freq.Values.All(count => count % 2 == 0);
        }

        static void Main()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter nums (space-separated): ");
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            if (IsValidInput(nums, n))
            {
                Console.WriteLine("Can divide into equal pairs: " + DivideArray(nums));
            }
        }
    }
}
