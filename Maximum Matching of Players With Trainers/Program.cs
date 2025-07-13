namespace Maximum_Matching_of_Players_With_Trainers
{
    public class Solution
    {
        public int MatchPlayersAndTrainers(int[] players, int[] trainers)
        {
            Array.Sort(players);
            Array.Sort(trainers);

            int i = 0, j = 0, matches = 0;

            while (i < players.Length && j < trainers.Length)
            {
                if (players[i] <= trainers[j])
                {
                    matches++;
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            return matches;
        }
    }
}
