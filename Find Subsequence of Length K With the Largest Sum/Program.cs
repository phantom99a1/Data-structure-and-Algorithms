namespace Find_Subsequence_of_Length_K_With_the_Largest_Sum
{
    public class Solution
    {
        public int[] MaxSubsequence(int[] nums, int k)
        {
            int len = nums.Length, index = 0;
            //to keep the order of original array
            var copy = new int[len];
            Array.Copy(nums, copy, len);
            Array.Sort(nums);
            var excludes = nums[0..(len - k)].ToList();
            var res = new int[k];
            foreach (var c in copy)
            {
                if (excludes.Contains(c))
                {
                    excludes.Remove(c);
                }
                else
                {
                    res[index++] = c;
                }
            }
            return res;
        }
    }
}
