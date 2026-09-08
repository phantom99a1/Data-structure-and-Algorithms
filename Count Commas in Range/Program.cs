namespace Count_Commas_in_Range
{
    public class Solution
    {
        public int CountCommas(int n)
        {
            long totalCommas = 0;
            long threshold = 1000;

            while (n >= threshold)
            {
                totalCommas += (n - threshold + 1);
                if (threshold > long.MaxValue / 1000) break;
                threshold *= 1000;
            }

            return (int)totalCommas;
        }
    }
}
