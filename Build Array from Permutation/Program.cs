namespace Build_Array_from_Permutation
{
    /*Given a zero-based permutation nums (0-indexed), build an array ans of the same 
     length where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
    A zero-based permutation nums is an array of distinct integers from 0 to nums.length - 1 (inclusive).
    
     Constraint:
    1 <= nums.length <= 1000
    0 <= nums[i] < nums.length
    The elements in nums are distinct.
     */
    public class Solution
    {
        public int[] BuildArray(int[] nums)
        {
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }
            return ans;
        }
    }
}
