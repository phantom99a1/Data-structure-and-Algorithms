namespace Water_Bottles_II
{
    public class Solution
    {
        public int MaxBottlesDrunk(int numBottles, int numExchange)
        {
            int totalDrunk = numBottles;

            while (numBottles >= numExchange)
            {
                numBottles -= numExchange;
                numExchange++;
                totalDrunk++;
                numBottles++; // drink one more bottle
            }

            return totalDrunk;
        }
    }
}
