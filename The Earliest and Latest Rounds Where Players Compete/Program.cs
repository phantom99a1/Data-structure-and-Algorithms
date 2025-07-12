namespace The_Earliest_and_Latest_Rounds_Where_Players_Compete
{
    public class Solution
    {
        public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
        {
            int left = Math.Min(firstPlayer, secondPlayer);
            int right = Math.Max(firstPlayer, secondPlayer);

            if (left + right == n + 1) return new[] { 1, 1 };
            if (n == 3 || n == 4) return new[] { 2, 2 };

            if (left - 1 > n - right)
            {
                int temp = n + 1 - left;
                left = n + 1 - right;
                right = temp;
            }

            int nextRound = (n + 1) >> 1;
            List<int[]> results = new();

            if (right * 2 <= n + 1)
            {
                int preLeft = left - 1;
                int midGap = right - left - 1;

                for (int i = 0; i <= preLeft; i++)
                {
                    for (int j = 0; j <= midGap; j++)
                    {
                        int[] subResult = EarliestAndLatest(nextRound, i + 1, i + j + 2);
                        results.Add(new[] { 1 + subResult[0], 1 + subResult[1] });
                    }
                }
            }
            else
            {
                int mirrored = n + 1 - right;
                int preLeft = left - 1;
                int midGap = mirrored - left - 1;
                int innerGap = right - mirrored - 1;

                for (int i = 0; i <= preLeft; i++)
                {
                    for (int j = 0; j <= midGap; j++)
                    {
                        int second = i + j + 1 + ((innerGap + 1) >> 1) + 1;
                        int[] subResult = EarliestAndLatest(nextRound, i + 1, second);
                        results.Add(new[] { 1 + subResult[0], 1 + subResult[1] });
                    }
                }
            }

            int minRound = results.Min(res => res[0]);
            int maxRound = results.Max(res => res[1]);

            return [minRound, maxRound];
        }
    }
}
