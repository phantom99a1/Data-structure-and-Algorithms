namespace K_th_Smallest_in_Lexicographical_Order
{
    public class Solution
    {
        public int FindKthNumber(int n, int k)
        {
            int curr = 1;
            k--;

            while (k > 0)
            {
                long steps = CountSteps(n, curr, curr + 1);
                if (steps <= k)
                {
                    k -= (int)steps;
                    curr++;
                }
                else
                {
                    k--;
                    curr *= 10;
                }
            }

            return curr;
        }

        private long CountSteps(int n, long first, long last)
        {
            long steps = 0;
            while (first <= n)
            {
                steps += Math.Min(n + 1, last) - first;
                first *= 10;
                last *= 10;
            }
            return steps;
        }
    }
}
