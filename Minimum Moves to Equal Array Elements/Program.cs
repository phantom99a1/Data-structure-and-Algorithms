namespace Minimum_Moves_to_Equal_Array_Elements
{
    public class Solution
    {
        public int MinMoves(int[] nums)
        {
            int min = int.MaxValue;

            // Find the minimum element
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
            }

            int totalMoves = 0;

            // Calculate the total moves needed
            foreach (int num in nums)
            {
                totalMoves += num - min;
            }

            return totalMoves;
        }
    }
}
