namespace Number_of_Sub_arrays_With_Odd_Sum_version_2
{
    public class Solution
    {
        private const int MOD = 1000000000 + 7;
        public int NumOfSubarrays(int[] arr)
        {
            long evenSub = 1, oddSub = 0, cur = 0;
            long answer = 0;
            foreach (var item in arr)
            {
                cur += item;
                if (cur % 2 == 1)
                {
                    oddSub++;
                    answer = (answer + evenSub) % MOD;
                }
                else
                {
                    evenSub++;
                    answer = (answer + oddSub) % MOD;
                }
            }
            return (int)answer;
        }
    }
}
