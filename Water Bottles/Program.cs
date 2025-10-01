namespace Water_Bottles
{
    public class Solution
    {
        int sum = 0;

        public int NumWaterBottles(int numBottles, int numExchange)
        {
            return numBottles + Solve(numBottles, numExchange);
        }
        public int Solve(int num, int numExchange)
        {
            if (num < numExchange)
                return 0;

            return sum += num / numExchange + Solve((num / numExchange) + (num % numExchange), numExchange);
        }
    }
}
