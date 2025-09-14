using System.Text;

namespace Vowel_Spellchecker
{
    public class Solution
    {
        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            HashSet<string> exact = new HashSet<string>(wordlist);
            Dictionary<string, string> caseInsensitive = new Dictionary<string, string>();
            Dictionary<string, string> vowelInsensitive = new Dictionary<string, string>();

            foreach (string word in wordlist)
            {
                string lower = word.ToLower();
                string devoweled = Devowel(lower);

                if (!caseInsensitive.ContainsKey(lower)) caseInsensitive[lower] = word;
                if (!vowelInsensitive.ContainsKey(devoweled)) vowelInsensitive[devoweled] = word;
            }

            string[] result = new string[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                string query = queries[i];
                if (exact.Contains(query))
                {
                    result[i] = query;
                }
                else
                {
                    string lower = query.ToLower();
                    string devoweled = Devowel(lower);

                    if (caseInsensitive.ContainsKey(lower))
                    {
                        result[i] = caseInsensitive[lower];
                    }
                    else if (vowelInsensitive.ContainsKey(devoweled))
                    {
                        result[i] = vowelInsensitive[devoweled];
                    }
                    else
                    {
                        result[i] = "";
                    }
                }
            }

            return result;
        }

        private string Devowel(string word)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in word)
            {
                sb.Append("aeiou".Contains(c) ? '*' : c);
            }
            return sb.ToString();
        }
    }
}
