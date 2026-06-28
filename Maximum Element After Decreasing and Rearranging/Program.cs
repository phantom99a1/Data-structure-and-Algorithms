namespace Maximum_Element_After_Decreasing_and_Rearranging
{
    public class Solution
    {
        public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
        {
            int n = arr.Length;
            Array.Sort(arr);
            int prev = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] >= prev + 1) prev += 1;
            }

            return prev;
        }
    }
}
