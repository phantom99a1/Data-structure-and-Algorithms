namespace Sort_Integers_by_The_Number_of_1_Bits
{
    public class Solution
    {
        public int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, (a, b) => {
                var b1 = int.PopCount(a);
                var b2 = int.PopCount(b);

                return b1 == b2 ? a - b : b1 - b2;
            });

            return arr;
        }
    }
}
