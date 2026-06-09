namespace Maximum_Total_Subarray_Value_I
{
    public class Solution
    {
        public long MaxTotalValue(int[] A, int k)
        {
            int gMin = A[0], gMax = A[0];

            foreach (int n in A)
            {
                gMin = Math.Min(gMin, n);
                gMax = Math.Max(gMax, n);
            }

            return (long)(gMax - gMin) * k;
        }
    }
}
