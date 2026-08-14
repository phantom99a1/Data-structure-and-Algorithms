namespace Maximum_Length_Substring_With_Two_Occurrences
{
    public class Solution
    {
        public int MaximumLengthSubstring(string s)
        {
            int[] count = new int[26];
            int left = 0;
            int res = 0;
            for (int right = 0; right < s.Length; right++)
            {
                int ch = s[right] - 'a';
                count[ch]++;
                while (count[ch] > 2)
                {
                    int ch2 = s[left] - 'a';
                    count[ch2]--;
                    left++;
                }
                res = Math.Max(res, right - left + 1);
            }
            return res;
        }
    }
}
