namespace Minimum_Cost_to_Convert_String_I
{
    public class Solution
    {
        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            int[,] conversion = new int[26, 26];
            int max = 0;
            int min = 26;
            // Read conversion 
            for (int i = 0; i < original.Length; i++)
            {
                int row = original[i] - 'a';
                int col = changed[i] - 'a';
                max = Math.Max(Math.Max(max, row), col);
                min = Math.Min(Math.Min(min, row), col);
                if (conversion[row, col] == 0)
                    conversion[row, col] = cost[i];
                else
                    conversion[row, col] = Math.Min(conversion[row, col], cost[i]);
            }
            // Complete / optimize conversion
            for (int i = min; i < max + 1; i++)
            {
                for (int j = min; j < max + 1; j++)
                {
                    if (conversion[i, j] == 0)
                        continue;
                    for (int k = min; k < max + 1; k++)
                    {
                        if (conversion[j, k] == 0 || i == k)
                            continue;
                        int newCost = conversion[i, j] + conversion[j, k];
                        if (conversion[i, k] == 0 || conversion[i, k] > newCost)
                        {
                            conversion[i, k] = newCost;
                            j = Math.Min(j, k) - 1;
                            break;
                        }
                    }
                }
            }
            // Check string for needed conversions
            long ret = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == target[i])
                    continue;
                int newCost = conversion[source[i] - 'a', target[i] - 'a'];
                if (newCost == 0)
                    return -1;
                ret += newCost;
            }
            return ret;
        }
    }
}
