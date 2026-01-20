namespace Construct_the_Minimum_Bitwise_Array_I
{
    public class Solution
    {
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int n = nums.Count;
            int[] ans = new int[n]; ;

            for (int i = 0; i < n; i++)
            {
                int x = nums[i];
                //Case 1: if nums[i] is even , even numbers cannot be formed by ans[i] OR (ans[i] + 1) == nums[i]\
                //a and a+1 always have different parities (one even, one odd).
                //The result of Even | Odd always has the last bit as 1 (Odd).
                //Therefore, if x is Even, it is impossible to form. Result is -1.
                if (x % 2 == 0) ans[i] = -1;

                //Case 2 : for odd numbers
                else
                {
                    //We need to find the position of first 0 bit starting from the right
                    int currentBit = 0;
                    int temp = x;

                    //Shift right until we found a 0 bit
                    while ((temp & 1) == 1)
                    {
                        temp >>= 1;
                        currentBit++;
                    }

                    //currentBit is the index where we found first 0
                    //to find minimum a, we turn off the bit immediately to the right of 0(currentBit-1);
                    //formula : a=x XOR(1<<(currentBit-1)); 
                    ans[i] = x ^ (1 << (currentBit - 1));
                }
            }
            return ans;
        }
    }
}
