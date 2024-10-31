namespace TwoSumProblem
{
    public class Solution
    {
        public static int[]? TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>(); 
            for (int i = 0; i < nums.Length; i++) 
            { 
                int complement = target - nums[i]; 
                if (map.TryGetValue(complement, out int value)) 
                { 
                    return [value, i]; 
                } 
                map[nums[i]] = i; 
            }
            return null;
        }
    }
    public class Program
    {
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
            if(string.IsNullOrEmpty(targetString))
            {
                Console.WriteLine("The target isn't empty!");
                Console.ReadKey();
                return;
            }
            if(!int.TryParse(targetString, out int value))
            {
                Console.WriteLine("The target is invalid!");
                Console.ReadKey();
                return;
            }
            var target = int.Parse(targetString);
            int[]? result = Solution.TwoSum(nums, target); 
            if (result != null) { 
                Console.WriteLine($"Indices: {result[0]}, {result[1]}"); 
            } 
            else { 
                Console.WriteLine("No two sum solution found."); 
            }
            Console.ReadKey();
        }
    }
}
