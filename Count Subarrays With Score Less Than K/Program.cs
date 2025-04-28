namespace Count_Subarrays_With_Score_Less_Than_K
{
    /*The score of an array is defined as the product of its sum and its length.
    For example, the score of [1, 2, 3, 4, 5] is (1 + 2 + 3 + 4 + 5) * 5 = 75.
    Given a positive integer array nums and an integer k, return the number of non-empty subarrays of nums whose score 
    is strictly less than k. A subarray is a contiguous sequence of elements within an array.
    
     Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^5
    1 <= k <= 10^15
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public int CountSubarrays(int[] nums, int k)
        {
            int count = 0, sum = 0, left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum * (right - left + 1) >= k)
                {
                    sum -= nums[left++];
                }
                count += (right - left + 1);
            }

            return count;
        }
    }
}
