namespace Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers
{
    public class Solution
    {
        public int MinPartitions(string n) => n.
            ToCharArray().
            Max(m => m - '0');
    }
}
