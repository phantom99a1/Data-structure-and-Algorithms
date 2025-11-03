namespace Minimum_Time_to_Make_Rope_Colorful
{
    internal class Program
    {
        public int MinCost(string colors, int[] neededTime)
        {
            int totalTime = 0;
            for (int i = 1; i < colors.Length; i++)
            {
                if (colors[i] == colors[i - 1])
                {
                    totalTime += Math.Min(neededTime[i], neededTime[i - 1]);
                    neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
                }
            }
            return totalTime;
        }
    }
}
