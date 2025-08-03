namespace Maximum_Fruits_Harvested_After_at_Most_K_Steps
{
    public class Solution
    {
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int maxFruits = 0, total = 0, left = 0;

            for (int right = 0; right < fruits.Length; right++)
            {
                total += fruits[right][1];

                while (left <= right && !IsReachable(fruits, startPos, k, left, right))
                {
                    total -= fruits[left][1];
                    left++;
                }

                maxFruits = Math.Max(maxFruits, total);
            }

            return maxFruits;
        }

        private bool IsReachable(int[][] fruits, int startPos, int k, int left, int right)
        {
            int leftDist = Math.Abs(startPos - fruits[left][0]);
            int rightDist = Math.Abs(startPos - fruits[right][0]);
            int minSteps = Math.Min(leftDist, rightDist) + (fruits[right][0] - fruits[left][0]);
            return minSteps <= k;
        }
    }
}
