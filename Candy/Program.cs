namespace Candy
{
    /*There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.
    You are giving candies to these children subjected to the following requirements:
    Each child must have at least one candy.
    Children with a higher rating get more candies than their neighbors.
    Return the minimum number of candies you need to have to distribute the candies to the children.
    
    Constraint:
    n == ratings.length
    1 <= n <= 2 * 10^4
    0 <= ratings[i] <= 2 * 10^4
     */
    public class Solution
    {
        public int Candy(int[] ratings)
        {
            int n = ratings.Length;
            int[] candies = new int[n];
            Array.Fill(candies, 1);

            // Left-to-right pass
            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            // Right-to-left pass
            for (int i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
                }
            }

            return candies.Sum();
        }
    }
}
