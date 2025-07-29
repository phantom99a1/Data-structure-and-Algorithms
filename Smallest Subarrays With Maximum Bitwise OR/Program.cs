namespace Smallest_Subarrays_With_Maximum_Bitwise_OR
{
    public class Solution
    {
        public int[] SmallestSubarrays(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int[] lastSeen = new int[32];
            Array.Fill(lastSeen, -1);

            for (int i = n - 1; i >= 0; i--)
            {
                for (int bit = 0; bit < 32; bit++)
                {
                    if (((nums[i] >> bit) & 1) == 1)
                    {
                        lastSeen[bit] = i;
                    }
                }

                int maxLen = 1;
                for (int bit = 0; bit < 32; bit++)
                {
                    if (lastSeen[bit] != -1)
                    {
                        maxLen = Math.Max(maxLen, lastSeen[bit] - i + 1);
                    }
                }

                result[i] = maxLen;
            }

            return result;
        }
    }
}
