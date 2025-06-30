namespace Longest_Harmonious_Subsequence
{
    public class Solution
    {
        public int FindLHS(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            int maxLen = 0;

            foreach (int num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                dict[num]++;
            }

            foreach (var kvp in dict)
            {
                if (dict.ContainsKey(kvp.Key + 1))
                {
                    maxLen = Math.Max(maxLen, kvp.Value + dict[kvp.Key + 1]);
                }
            }

            return maxLen;
        }
    }
}
