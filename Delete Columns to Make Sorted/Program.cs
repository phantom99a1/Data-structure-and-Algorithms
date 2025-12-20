namespace Delete_Columns_to_Make_Sorted
{
    public class Solution
    {
        public int MinDeletionSize(string[] strs)
        {
            int n = strs.Length;
            int stringSize = strs[0].Length;
            int result = 0;

            for (int j = 0; j < stringSize; j++)
            {
                char prev = strs[0][j];

                for (int i = 1; i < n; i++)
                {
                    if (strs[i][j] < prev)
                    {
                        result++;
                        break;
                    }
                    prev = strs[i][j];
                }
            }

            return result;
        }
    }
}
