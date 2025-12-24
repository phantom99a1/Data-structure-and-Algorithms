namespace Apple_Redistribution_into_Boxes
{
    public class Solution
    {
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            int total = 0;
            foreach (int a in apple) total += a;

            Array.Sort(capacity);
            Array.Reverse(capacity);

            int curr = 0;
            int count = 0;

            foreach (int cap in capacity)
            {
                curr += cap;
                count++;
                if (curr >= total) break;
            }

            return count;
        }
    }
}
