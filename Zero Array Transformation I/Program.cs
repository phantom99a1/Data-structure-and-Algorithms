namespace Zero_Array_Transformation_I
{
    /*You are given an integer array nums of length n and a 2D array queries, where queries[i] = [li, ri].
    For each queries[i]:
    Select a subset of indices within the range [li, ri] in nums.
    Decrement the values at the selected indices by 1. A Zero Array is an array where all elements are equal to 0.
    Return true if it is possible to transform nums into a Zero Array after processing all the queries sequentially, 
    otherwise return false.
    
    Constraint:
    1 <= nums.length <= 10^5
    0 <= nums[i] <= 10^5
    1 <= queries.length <= 10^5
    queries[i].length == 2
    0 <= li <= ri < nums.length
     */
    public class Solution
    {
        public bool IsZeroArray(int[] nums, int[][] queries)
        {
            int len = nums.Length;
            var dip = new int[len + 1];
            foreach (var item in queries)
            {
                int temp = item[0], end = item[1];
                dip[temp]++;
                dip[end + 1]--;
            }

            for (int i = 0, s = 0; i < len; i++)
            {
                s += dip[i];
                if (nums[i] > s)
                    return false;
            }
            return true;
        }
    }
}
