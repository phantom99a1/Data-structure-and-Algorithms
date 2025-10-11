namespace Find_the_Minimum_Amount_of_Time_to_Brew_Potions
{
    public class Solution
    {
        public long MinTime(int[] skill, int[] mana)
        {
            int n = skill.Length, m = mana.Length;
            long[] done = new long[n + 1];

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                    done[i + 1] = Math.Max(done[i + 1], done[i]) + (long)mana[j] * skill[i];

                for (int i = n - 1; i > 0; i--)
                    done[i] = done[i + 1] - (long)mana[j] * skill[i];
            }

            return done[n];
        }
    }
}
