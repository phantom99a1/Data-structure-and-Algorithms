namespace Minimum_Deletions_to_Make_String_K_Special
{
    public class Solution
    {
        public int MinimumDeletions(string word, int k)
        {
            int[] freq = new int[26];
            foreach (char c in word)
            {
                freq[c - 'a']++;
            }

            List<int> nums = freq.Where(x => x > 0).ToList();

            int f(int v)
            {
                int deletions = 0;
                foreach (int x in nums)
                {
                    if (x < v) deletions += x;
                    else if (x > v + k) deletions += x - v - k;
                }
                return deletions;
            }

            int minDel = word.Length;
            for (int v = 0; v <= word.Length; v++)
            {
                minDel = Math.Min(minDel, f(v));
            }
            return minDel;
        }
    }
}
