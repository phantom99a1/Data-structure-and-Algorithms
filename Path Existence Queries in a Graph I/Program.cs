namespace Path_Existence_Queries_in_a_Graph_I
{
    public class Solution
    {
        public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
        {
            var arr = CreateArr(nums, maxDiff);
            var rs = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                rs[i] = arr[queries[i][0]] == arr[queries[i][1]];
            }
            return rs;
        }
        private int[] CreateArr(int[] nums, int maxDiff)
        {
            var rs = new int[nums.Length];
            var currDicId = 0;
            rs[0] = currDicId;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] > maxDiff)
                {
                    currDicId++;
                }
                rs[i] = currDicId;
            }
            return rs;
        }
    }
}
