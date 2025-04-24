namespace Count_Complete_Subarrays_in_an_Array
{
    /*You are given an array nums consisting of positive integers.
    We call a subarray of an array complete if the following condition is satisfied:
    The number of distinct elements in the subarray is equal to the number of distinct elements in the whole array.
    Return the number of complete subarrays.
    A subarray is a contiguous non-empty part of an array.
    
     Constraint:
    1 <= nums.length <= 1000
    1 <= nums[i] <= 2000
     */
    public class Solution
    {
        public int CountCompleteSubarrays(int[] nums)
        {
            int totalDistinct = new HashSet<int>(nums).Count;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                HashSet<int> seen = new HashSet<int>();
                for (int j = i; j < nums.Length; j++)
                {
                    seen.Add(nums[j]);
                    if (seen.Count == totalDistinct)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
