namespace Count_of_Interesting_Subarrays
{
    /*You are given a 0-indexed integer array nums, an integer modulo, and an integer k.
    Your task is to find the count of subarrays that are interesting.
    A subarray nums[l..r] is interesting if the following condition holds:
    Let cnt be the number of indices i in the range [l, r] such that nums[i] % modulo == k. Then, cnt % modulo == k.
    Return an integer denoting the count of interesting subarrays.
    Note: A subarray is a contiguous non-empty sequence of elements within an array.
    
     Constraint:
    1 <= nums.length <= 10^5 
    1 <= nums[i] <= 10^9
    1 <= modulo <= 10^9
    0 <= k < modulo
     */
    
    public class Solution
    {
        public int CountInterestingSubarrays(int[] nums, int modulo, int k)
        {
            int prefixSum = 0;
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            countMap[0] = 1;
            int result = 0;

            foreach (int num in nums)
            {
                prefixSum = (prefixSum + (num % modulo == k ? 1 : 0)) % modulo;
                int target = (prefixSum - k + modulo) % modulo;
                if (countMap.ContainsKey(target))
                {
                    result += countMap[target];
                }
                if (!countMap.ContainsKey(prefixSum))
                {
                    countMap[prefixSum] = 0;
                }
                countMap[prefixSum]++;
            }

            return result;
        }
    }
}
