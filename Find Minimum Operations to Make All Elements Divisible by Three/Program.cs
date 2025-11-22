namespace Find_Minimum_Operations_to_Make_All_Elements_Divisible_by_Three
{
    public class Solution
    {
        public int MinimumOperations(int[] nums)
        {
            int operations = 0;
            foreach (int num in nums)
            {
                int remainder = num % 3;
                operations += Math.Min(remainder, 3 - remainder);
            }
            return operations;
        }
    }

    // Example usage:
    // var sol = new Solution();
    // Console.WriteLine(sol.MinimumOperations(new int[]{1,2,3,4})); // Output: 3
    // Console.WriteLine(sol.MinimumOperations(new int[]{3,6,9}));   // Output: 0
}
