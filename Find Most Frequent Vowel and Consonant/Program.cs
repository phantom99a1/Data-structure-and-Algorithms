namespace Find_Most_Frequent_Vowel_and_Consonant
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MaxFreqSum(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            int con = 0, vow = 0;
            foreach (char c in s)
            {
                if (!freq.ContainsKey(c)) freq[c] = 0;
                freq[c]++;
            }
            foreach (var kv in freq)
            {
                if ("aeiou".Contains(kv.Key))
                    vow = Math.Max(vow, kv.Value);
                else
                    con = Math.Max(con, kv.Value);
            }
            return con + vow;
        }
    }
}
