namespace Minimum_Difference_Between_Highest_and_Lowest_of_K_Scores
{
    public class Solution
    {
        public int MinimumDifference(int[] InputNumbers, int GroupSize)
        {
            if (InputNumbers.Length == 1)
            {
                return 0;
            }

            Array.Sort(InputNumbers, (First, Second) => Second - First);
            int MinDifference = int.MaxValue;

            for (int Index = 0; Index <= InputNumbers.Length - GroupSize; Index++)
            {
                MinDifference = Math.Min(MinDifference, InputNumbers[Index] - InputNumbers[Index + GroupSize - 1]);
            }

            return MinDifference;
        }
    }
}
