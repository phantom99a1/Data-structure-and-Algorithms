namespace Taking_Maximum_Energy_From_the_Mystic_Dungeon
{
    public class Solution
    {
        public int MaximumEnergy(int[] energy, int k)
        {
            int ans = int.MinValue;
            int n = energy.Length;

            for (int i = n - k; i < n; ++i)
            {
                int j = i, sum = 0;
                while (j >= 0)
                {
                    sum += energy[j];
                    ans = Math.Max(ans, sum);
                    j -= k;
                }
            }

            return ans;
        }
    }
}
