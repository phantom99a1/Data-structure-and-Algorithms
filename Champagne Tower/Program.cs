namespace Champagne_Tower
{
    public class Solution
    {
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            //make a 2 dimensional array with double data type
            double[,] champagneTower = new double[102, 102];
            //pour all wine in top glass
            champagneTower[0, 0] = (double)poured;
            //for loop to access every glass in every glass row until quety glass
            for (int glassRow = 0; glassRow <= query_row; glassRow++)
            {
                for (int glass = 0; glass <= glassRow; glass++)
                {
                    //store the value of wine poured from this glass if glass full
                    double pouredFromGlass = (champagneTower[glassRow, glass] - 1.0) / 2.0;
                    //if glass was not full yet then pouredFromGlass will be less then 0
                    //so value of glass below will not incremented by this glass
                    if (pouredFromGlass > 0)
                    {
                        champagneTower[glassRow + 1, glass] += pouredFromGlass;
                        champagneTower[glassRow + 1, glass + 1] += pouredFromGlass;
                    }
                }
            }
            //return 1 if wine in that glass is more than 1 otherwise return how much glass is full
            return Math.Min(1, champagneTower[query_row, query_glass]);
        }
    }
}
