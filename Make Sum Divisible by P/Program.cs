namespace Make_Sum_Divisible_by_P
{
    public class Solution
    {
        public int MinSubarray(int[] nums, int p)
        {
            // Step 1: Compute total sum modulo p
            int total = 0;
            foreach (int num in nums)
            {
                total = (total + num) % p;
            }
            if (total == 0) return 0; // Already divisible

            // Step 2: Dictionary to store prefix remainders
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1; // Base case

            int prefix = 0;
            int result = nums.Length;

            // Step 3: Iterate through array
            for (int i = 0; i < nums.Length; i++)
            {
                prefix = (prefix + nums[i]) % p;
                int target = (prefix - total + p) % p;

                if (map.ContainsKey(target))
                {
                    result = Math.Min(result, i - map[target]);
                }

                map[prefix] = i; // Update dictionary
            }

            return result == nums.Length ? -1 : result;
        }
    }
}
