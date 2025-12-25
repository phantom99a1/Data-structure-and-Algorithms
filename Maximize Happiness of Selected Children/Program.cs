namespace Maximize_Happiness_of_Selected_Children
{
    public class Solution
    {
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            Array.Sort(happiness);

            long result = 0;
            int decrease = 0;
            int n = happiness.Length;
            for (int i = n - 1; i >= n - k; i--)
            {
                int current = happiness[i] - decrease;
                if (current > 0)
                {
                    result += current;
                }
                decrease++;
            }

            return result;
        }
    }
}
