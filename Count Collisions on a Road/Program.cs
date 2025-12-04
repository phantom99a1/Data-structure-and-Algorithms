namespace Count_Collisions_on_a_Road
{
    public class Solution
    {
        public int CountCollisions(string directions)
        {
            int n = directions.Length;
            int left = 0, right = n - 1;

            // Skip cars moving left at the start
            while (left < n && directions[left] == 'L')
            {
                left++;
            }

            // Skip cars moving right at the end
            while (right >= 0 && directions[right] == 'R')
            {
                right--;
            }

            int collisions = 0;
            for (int i = left; i <= right; i++)
            {
                if (directions[i] != 'S')
                {
                    collisions++;
                }
            }

            return collisions;
        }
    }
}
