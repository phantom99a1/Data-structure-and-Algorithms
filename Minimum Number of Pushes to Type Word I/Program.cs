namespace Minimum_Number_of_Pushes_to_Type_Word_I
{
    public class Solution
    {
        public int MinimumPushes(string word)
        {
            int n = word.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += i / 8 + 1;
            }
            return ans;
        }
    }
}
