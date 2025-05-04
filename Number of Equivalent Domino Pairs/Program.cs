namespace Number_of_Equivalent_Domino_Pairs
{

    /*Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] 
    if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated 
    to be equal to another domino.
    Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].
    
     Constraint:
    1 <= dominoes.length <= 4 * 10^4
    dominoes[i].length == 2
    1 <= dominoes[i][j] <= 9
     */

    public class Solution
    {
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            var counts = new Dictionary<int, int>();
            int result = 0;

            foreach (var domino in dominoes)
            {
                int key = Math.Min(domino[0], domino[1]) * 10 + Math.Max(domino[0], domino[1]);
                if (counts.ContainsKey(key))
                {
                    result += counts[key];
                    counts[key]++;
                }
                else
                {
                    counts[key] = 1;
                }
            }
            return result;
        }
    }
}
