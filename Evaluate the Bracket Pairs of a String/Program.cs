using System.Text;

namespace Evaluate_the_Bracket_Pairs_of_a_String
{
    public class Solution
    {
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (IList<string> kd in knowledge)
            {
                dict.Add(kd[0], kd[1]);
            }
            bool addKey = false;
            StringBuilder key = new();
            StringBuilder res = new();
            foreach (char c in s)
            {
                if (c == '(')
                {
                    addKey = true;
                }
                else if (c == ')')
                {
                    if (dict.ContainsKey(key.ToString()))
                    {
                        res.Append(dict[key.ToString()]);
                    }
                    else
                    {
                        res.Append('?');
                    }
                    addKey = false;
                    key.Length = 0;
                }
                else if (addKey)
                {
                    key.Append(c);
                }
                else
                {
                    res.Append(c);
                }
            }
            return res.ToString();
        }
    }
}
