namespace Find_the_Highest_Altitude
{
    public class Solution
    {
        public int LargestAltitude(int[] gain) => gain.
            Aggregate((0, 0), (acum, current) => (
                acum.Item1 + current,
                Math.Max(acum.Item2, acum.Item1 + current)
            ), result => result.Item2);
    }
}
