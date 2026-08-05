namespace Find_Missing_Elements
{
    public class Solution
    {
        public IList<int> FindMissingElements(int[] nums)
        {
            var st = new HashSet<int>(nums);
            int mn = nums.Min();
            int mx = nums.Max();

            var ans = new List<int>();
            for (int i = mn + 1; i < mx; i++)
            {
                if (!st.Contains(i))
                {
                    ans.Add(i);
                }
            }
            return ans;
        }
    }
}
