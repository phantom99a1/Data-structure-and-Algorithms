namespace Sum_of_Squares_of_Special_Elements
{
    public class Solution
    {
        public int SumOfSquares(int[] nums) => nums.Select((m, i) => (m * m, i + 1)).
            Where(m => nums.Length % m.Item2 == 0).
            Sum(m => m.Item1);
    }
}
