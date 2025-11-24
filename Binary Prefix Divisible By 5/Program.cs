namespace Binary_Prefix_Divisible_By_5
{
    public class Solution
    {
        public IList<bool> PrefixesDivBy5(int[] nums)
        {
            var result = new List<bool>(nums.Length);
            int mod = 0;
            foreach (var bit in nums)
            {
                mod = (mod * 2 + bit) % 5;
                result.Add(mod == 0);
            }
            return result;
        }
    }
}
