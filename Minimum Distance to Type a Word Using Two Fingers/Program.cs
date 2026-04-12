namespace Minimum_Distance_to_Type_a_Word_Using_Two_Fingers
{
    public class Solution
    {
        private readonly int[,] coordinates = new int[26, 2];

        public Solution()
        {
            // Set up the coordinates for each letter A-Z
            int index = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (index < 26)
                    {
                        coordinates[index, 0] = x; // x-coordinate
                        coordinates[index, 1] = y; // y-coordinate
                        index++;
                    }
                }
            }
        }

        public int MinimumDistance(string word)
        {
            int[,,] memo = new int[word.Length, 27, 27];
            for (int i = 0; i < word.Length; i++)
                for (int j = 0; j < 27; j++)
                    for (int k = 0; k < 27; k++)
                        memo[i, j, k] = -1; // Initialize memoization array

            return Helper(word, 0, -1, -1, memo);
        }

        private int Helper(string word, int index, int pos1, int pos2, int[,,] memo)
        {
            if (index == word.Length) return 0; // End of the word
            if (memo[index, pos1 + 1, pos2 + 1] != -1) return memo[index, pos1 + 1, pos2 + 1];

            int letterIndex = word[index] - 'A';
            int distance1 = CalculateDistance(pos1, letterIndex);
            int distance2 = CalculateDistance(pos2, letterIndex);

            // Move finger 1 or finger 2 to the current letter
            int option1 = distance1 + Helper(word, index + 1, letterIndex, pos2, memo);
            int option2 = distance2 + Helper(word, index + 1, pos1, letterIndex, memo);

            memo[index, pos1 + 1, pos2 + 1] = (option1 < option2) ? option1 : option2;
            return memo[index, pos1 + 1, pos2 + 1];
        }

        private int CalculateDistance(int finger, int letterIndex)
        {
            if (finger == -1) return 0; // Starting position
            return Math.Abs(coordinates[finger, 0] - coordinates[letterIndex, 0]) +
                   Math.Abs(coordinates[finger, 1] - coordinates[letterIndex, 1]);
        }
    }
}
