namespace Subarrays_Distinct_Element_Sum_of_Squares_I
{
    public class Solution
    {
        public int SumCounts(IList<int> nums)
        {

            int res = 1;

            Dictionary<int, int> con = new Dictionary<int, int>();
            con.Add(nums[0], 1);

            Dictionary<int, int> tmp;

            if (nums.Count > 1)
            {
                for (int i = 1; i < nums.Count; i++)
                {
                    if (con.ContainsKey(nums[i]) == true) con[nums[i]]++;
                    else con.Add(nums[i], 1);

                    res += con.Count * con.Count;

                    tmp = new Dictionary<int, int>();
                    tmp = con.ToDictionary();

                    for (int j = 0; j < i; j++)
                    {
                        if (tmp[nums[j]] == 1) tmp.Remove(nums[j]);
                        else tmp[nums[j]]--;

                        res += tmp.Count * tmp.Count;
                    }
                }
            }

            return res;
        }
    }
}
