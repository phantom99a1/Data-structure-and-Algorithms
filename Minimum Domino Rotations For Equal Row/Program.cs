namespace Minimum_Domino_Rotations_For_Equal_Row
{
    /*In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the ith domino. 
    (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
    We may rotate the ith domino, so that tops[i] and bottoms[i] swap values.
    Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same.
    If it cannot be done, return -1.
    
     Constraint:
    2 <= tops.length <= 2 * 10^4
    bottoms.length == tops.length
    1 <= tops[i], bottoms[i] <= 6
     */
    public class Solution
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            int check(int x)
            {
                int topRotations = 0, bottomRotations = 0;
                for (int i = 0; i < tops.Length; i++)
                {
                    if (tops[i] != x && bottoms[i] != x) return -1;
                    if (tops[i] != x) topRotations++;
                    if (bottoms[i] != x) bottomRotations++;
                }
                return Math.Min(topRotations, bottomRotations);
            }

            int rotations = check(tops[0]);
            if (rotations != -1) return rotations;
            return check(bottoms[0]);
        }
    }
}
