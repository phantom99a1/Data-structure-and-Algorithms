namespace Longest_Substring_of_One_Repeating_Character
{
    public class Solution
    {
        public int[] LongestRepeating(string s, string queryCharacters,
                                      int[] queryIndices)
        {
            int n = s.Length;
            char[] arr = s.ToCharArray();
            SortedSet<int> keys = new SortedSet<int>();
            Dictionary<int, int> segs = new Dictionary<int, int>();
            int[] lenCnt = new int[n + 1];
            SortedSet<int> activeLens = new SortedSet<int>();

            for (int i = 0; i < n;)
            {
                int j = i;
                while (j < n && arr[j] == arr[i])
                {
                    j++;
                }
                keys.Add(i);
                segs[i] = j - 1;
                int len = j - i;
                if (lenCnt[len] == 0)
                {
                    activeLens.Add(len);
                }
                lenCnt[len]++;
                i = j;
            }

            int k = queryIndices.Length;
            int[] ans = new int[k];

            for (int q = 0; q < k; q++)
            {
                int pos = queryIndices[q];
                char ch = queryCharacters[q];

                if (arr[pos] != ch)
                {
                    int L = keys.GetViewBetween(0, pos).Max;
                    int R = segs[L];
                    keys.Remove(L);
                    segs.Remove(L);
                    int oldLen = R - L + 1;
                    lenCnt[oldLen]--;
                    if (lenCnt[oldLen] == 0)
                    {
                        activeLens.Remove(oldLen);
                    }

                    int newL = pos, newR = pos;

                    if (L < pos)
                    {
                        if (arr[pos - 1] == ch)
                        {
                            newL = L;
                        }
                        else
                        {
                            keys.Add(L);
                            segs[L] = pos - 1;
                            int lLen = pos - L;
                            if (lenCnt[lLen] == 0)
                            {
                                activeLens.Add(lLen);
                            }
                            lenCnt[lLen]++;
                        }
                    }

                    if (pos < R)
                    {
                        if (arr[pos + 1] == ch)
                        {
                            newR = R;
                        }
                        else
                        {
                            keys.Add(pos + 1);
                            segs[pos + 1] = R;
                            int rLen = R - pos;
                            if (lenCnt[rLen] == 0)
                            {
                                activeLens.Add(rLen);
                            }
                            lenCnt[rLen]++;
                        }
                    }

                    if (L == pos && pos > 0 && arr[pos - 1] == ch)
                    {
                        int lk = keys.GetViewBetween(0, pos - 1).Max;
                        if (segs.ContainsKey(lk) && segs[lk] == pos - 1)
                        {
                            keys.Remove(lk);
                            int ll = segs[lk] - lk + 1;
                            lenCnt[ll]--;
                            if (lenCnt[ll] == 0)
                            {
                                activeLens.Remove(ll);
                            }
                            segs.Remove(lk);
                            newL = lk;
                        }
                    }

                    if (R == pos && pos + 1 < n && arr[pos + 1] == ch)
                    {
                        int rk = keys.GetViewBetween(pos + 1, n).Min;
                        if (segs.ContainsKey(rk))
                        {
                            keys.Remove(rk);
                            int rl = segs[rk] - rk + 1;
                            lenCnt[rl]--;
                            if (lenCnt[rl] == 0)
                            {
                                activeLens.Remove(rl);
                            }
                            int rR = segs[rk];
                            segs.Remove(rk);
                            newR = rR;
                        }
                    }

                    keys.Add(newL);
                    segs[newL] = newR;
                    int newLen = newR - newL + 1;
                    if (lenCnt[newLen] == 0)
                    {
                        activeLens.Add(newLen);
                    }
                    lenCnt[newLen]++;
                    arr[pos] = ch;
                }

                ans[q] = activeLens.Max;
            }

            return ans;
        }
    }
}
