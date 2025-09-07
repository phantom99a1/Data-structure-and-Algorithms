namespace Find_N_Unique_Integers_Sum_up_to_Zero
{
    internal class Program
    {
        public int[] SumZero(int n)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= n / 2; i++)
            {
                result.Add(i);
                result.Add(-i);
            }
            if (n % 2 != 0)
            {
                result.Add(0);
            }
            return result.ToArray();
        }
    }
}
