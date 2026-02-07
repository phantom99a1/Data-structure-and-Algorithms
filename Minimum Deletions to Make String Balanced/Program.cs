namespace Minimum_Deletions_to_Make_String_Balanced
{
    public class Solution
    {
        public int MinimumDeletions(string s)
        {
            int n = s.Length;

            // Arrays to store the minimum deletions required
            int[] left = new int[n];
            int[] right = new int[n];

            // Initialize the left and right counts
            left[0] = s[0] == 'b' ? 1 : 0;
            right[n - 1] = s[n - 1] == 'a' ? 1 : 0;

            // Fill the left array (cumulative deletions needed to make s[0:i] balanced)
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] + (s[i] == 'b' ? 1 : 0);
            }

            // Fill the right array (cumulative deletions needed to make s[i:n] balanced)
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] + (s[i] == 'a' ? 1 : 0);
            }

            // Calculate the minimum deletions required
            int minDeletions = Math.Min(left[n - 1], right[0]);
            for (int i = 0; i < n - 1; i++)
            {
                minDeletions = Math.Min(minDeletions, left[i] + right[i + 1]);
            }

            return minDeletions;
        }
    }
}
