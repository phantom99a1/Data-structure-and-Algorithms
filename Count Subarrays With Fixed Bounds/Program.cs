namespace Count_Subarrays_With_Fixed_Bounds
{
    /*You are given an integer array nums and two integers minK and maxK.
    A fixed-bound subarray of nums is a subarray that satisfies the following conditions:
    The minimum value in the subarray is equal to minK.
    The maximum value in the subarray is equal to maxK.
    Return the number of fixed-bound subarrays.
    A subarray is a contiguous part of an array.
    
     Constraint:
    2 <= nums.length <= 10^5
    1 <= nums[i], minK, maxK <= 10^6
     */
    public int CountSubarrays(int[] nums, int minK, int maxK)
    {
        int count = 0, minIndex = -1, maxIndex = -1, lastInvalid = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
            {
                lastInvalid = i;
            }
            if (nums[i] == minK)
            {
                minIndex = i;
            }
            if (nums[i] == maxK)
            {
                maxIndex = i;
            }
            count += Math.Max(0, Math.Min(minIndex, maxIndex) - lastInvalid);
        }

        return count;
    }
}
