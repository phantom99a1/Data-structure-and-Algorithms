namespace Minimum_Moves_to_Equal_Array_Elements_III
{
    public class Solution
    {
        public int MinMoves(int[] nums) => nums.Aggregate((nums.Max(), 0), (a, b) => (a.Item1, a.Item2 + a.Item1 - b)).Item2;
    }
}
