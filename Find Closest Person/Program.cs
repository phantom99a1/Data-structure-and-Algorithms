namespace Find_Closest_Person
{
    public class Solution
    {
        public int FindClosest(int x, int y, int z)
        {
            int d1 = Math.Abs(z - x);
            int d2 = Math.Abs(z - y);

            if (d1 < d2) return 1;
            else if (d1 > d2) return 2;
            else return 0;
        }
    }
}
