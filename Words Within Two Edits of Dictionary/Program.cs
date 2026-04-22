using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_Within_Two_Edits_of_Dictionary
{
    public class Solution
    {
        public IList<string> TwoEditWords(string[] queries, string[] dictionary)
        {
            List<string> ans = new List<string>();

            foreach (string q in queries)
            {
                foreach (string d in dictionary)
                {
                    int diff = 0;

                    for (int i = 0; i < q.Length; i++)
                    {
                        if (q[i] != d[i])
                        {
                            diff++;
                        }

                        if (diff > 2) break;
                    }

                    if (diff <= 2)
                    {
                        ans.Add(q);
                        break;
                    }
                }
            }

            return ans;
        }
    }
}
