namespace Kth_Smallest_Product_of_Two_Sorted_Arrays
{
    public class Solution
    {
        public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
        {
            long left = -10000000000, right = 10000000000;

            while (left < right)
            {
                long mid = (left + right) / 2;
                if (CountLessEqual(nums1, nums2, mid) < k)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        private long CountLessEqual(int[] A, int[] B, long x)
        {
            long count = 0;
            foreach (int a in A)
            {
                if (a > 0)
                {
                    int l = 0, r = B.Length;
                    while (l < r)
                    {
                        int m = (l + r) / 2;
                        if ((long)a * B[m] <= x) l = m + 1;
                        else r = m;
                    }
                    count += l;
                }
                else if (a < 0)
                {
                    int l = 0, r = B.Length;
                    while (l < r)
                    {
                        int m = (l + r) / 2;
                        if ((long)a * B[m] <= x) r = m;
                        else l = m + 1;
                    }
                    count += B.Length - l;
                }
                else if (x >= 0)
                {
                    count += B.Length;
                }
            }
            return count;
        }
    }
}
