namespace Minimum_Equal_Sum_of_Two_Arrays_After_Replacing_Zeros
{
    /*You are given two arrays nums1 and nums2 consisting of positive integers. You have to replace all the 0's in both arrays 
    with strictly positive integers such that the sum of elements of both arrays becomes equal.
    Return the minimum equal sum you can obtain, or -1 if it is impossible.

    Constraint:
    1 <= nums1.length, nums2.length <= 10^5
     <= nums1[i], nums2[i] <= 10^6
    */
    public class Solution
    {
        public long MinSum(int[] nums1, int[] nums2)
        {
            long sum1 = 0, sum2 = 0;
            long zero1 = 0, zero2 = 0;

            foreach (int i in nums1)
            {
                sum1 += i;
                if (i == 0)
                {
                    sum1++;
                    zero1++;
                }
            }

            foreach (int i in nums2)
            {
                sum2 += i;
                if (i == 0)
                {
                    sum2++;
                    zero2++;
                }
            }

            if ((zero1 == 0 && sum2 > sum1) || (zero2 == 0 && sum1 > sum2))
            {
                return -1;
            }

            return Math.Max(sum1, sum2);
        }
    }
}
