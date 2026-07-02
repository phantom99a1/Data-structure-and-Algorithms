namespace Number_of_Substrings_Containing_All_Three_Characters_version_2
{
    public class Solution
    {
        public int NumberOfSubstrings(string s)
        {
            int count = 0;
            int left = 0;
            Dictionary<char, int> charCount = new() {
            { 'a', 0 }, { 'b', 0 }, { 'c', 0 }
        };

            for (int right = 0; right < s.Length; right++)
            {
                charCount[s[right]]++;

                while (charCount['a'] > 0 && charCount['b'] > 0 && charCount['c'] > 0)
                {
                    count += s.Length - right;
                    charCount[s[left]]--;
                    left++;
                }
            }

            return count;
        }
    }
}
