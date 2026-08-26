namespace Shortest_and_Lexicographically_Smallest_Beautiful_String
{
    public class Solution
    {
        public string ShortestBeautifulSubstring(string s, int k)
        {
            if (s.Count(c => c == '1') < k)
                return "";
            string ans = s;
            int cnt = 0, left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                cnt += s[right] - '0';
                while (cnt > k || s[left] == '0')
                {
                    cnt -= s[left++] - '0';
                }
                if (cnt == k)
                {
                    string t = s.Substring(left, right - left + 1);
                    if (t.Length < ans.Length ||
                        t.Length == ans.Length &&
                            string.CompareOrdinal(t, ans) < 0)
                    {
                        ans = t;
                    }
                }
            }
            return ans;
        }
    }
}
