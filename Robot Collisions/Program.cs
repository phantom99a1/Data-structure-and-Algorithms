namespace Robot_Collisions
{
    public class Solution
    {
        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            int n = positions.Length;
            int[] index = new int[n];
            for (int i = 0; i < n; i++)
            {
                index[i] = i;
            }
            Array.Sort(positions, index);
            int[] survivors = new int[n];
            Stack<int> st = [];
            foreach (int i in index)
            {
                if (directions[i] == 'R')
                {
                    st.Push(i);
                }
                else
                {
                    while (st.Count > 0 && healths[i] > 0)
                    {
                        int id = st.Pop();
                        if (healths[i] == healths[id])
                        {
                            healths[i] = 0;
                        }
                        else if (healths[i] < healths[id])
                        {
                            healths[i] = 0;
                            healths[id]--;
                            st.Push(id);
                        }
                        else
                        {
                            healths[i]--;
                        }
                    }
                    if (healths[i] > 0) survivors[i] = healths[i];
                }
            }
            while (st.Count > 0)
            {
                int id = st.Pop();
                survivors[id] = healths[id];
            }
            IList<int> res = [];
            for (int i = 0; i < n; i++)
            {
                if (survivors[i] > 0) res.Add(survivors[i]);
            }
            return res;
        }
    }
}
