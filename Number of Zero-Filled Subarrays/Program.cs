namespace Number_of_Zero_Filled_Subarrays
{
    public class Solution
    {
        public long ZeroFilledSubarray(int[] nums)
        {
            long count = 0, result = 0;
            foreach (int num in nums)
            {
                if (num == 0)
                {
                    count++;
                    result += count;
                }
                else
                {
                    count = 0;
                }
            }
            return result;
        }
    }
}
