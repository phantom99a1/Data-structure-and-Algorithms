namespace Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times
{
    /*You are given an integer array nums and a positive integer k.
    Return the number of subarrays where the maximum element of nums appears at least k times in that subarray.
    A subarray is a contiguous sequence of elements within an array.
    
    Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^6
    1 <= k <= 10^5
     */
    using System;

    public class Solution
    {
        public int CountSubarrays(int[] nums, int k)
        {
            int maxVal = nums.Max();
            int count = 0, left = 0, occurrences = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == maxVal) occurrences++;

                while (occurrences >= k)
                {
                    count += nums.Length - right;
                    if (nums[left] == maxVal) occurrences--;
                    left++;
                }
            }

            return count;
        }
    }

    // Example Usage
    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.CountSubarrays(new int[] { 1, 3, 3, 3, 2 }, 2)); // Output: 6
        }
    }
}
