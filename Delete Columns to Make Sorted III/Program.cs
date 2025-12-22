namespace Delete_Columns_to_Make_Sorted_III
{
    public class Solution
    {
        public int MinDeletionSize(string[] strs)
        {
            int rows = strs.Length;
            int cols = strs[0].Length;

            int[] dp = new int[cols];
            Array.Fill(dp, 1);

            for (int c = 1; c < cols; c++)
            {
                for (int j = 0; j < c; j++)
                {
                    bool valid = true;

                    for (int r = 0; r < rows; r++)
                    {
                        if (strs[r][j] > strs[r][c])
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        dp[c] = Math.Max(dp[c], dp[j] + 1);
                    }
                }
            }

            return cols - dp.Max();
        }
    }
}
