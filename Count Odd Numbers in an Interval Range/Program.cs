namespace Count_Odd_Numbers_in_an_Interval_Range
{
    public class Solution
    {
        public int CountOdds(int low, int high)
        {
            int count = (high - low) / 2;

            // If either boundary is odd, add 1
            if (low % 2 != 0 || high % 2 != 0)
            {
                count++;
            }

            return count;
        }
    }
}
