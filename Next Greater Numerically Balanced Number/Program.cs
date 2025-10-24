namespace Next_Greater_Numerically_Balanced_Number
{
    public class Solution
    {
        public int NextBeautifulNumber(int n)
        {
            for (int i = n + 1; i <= 1224444; i++)
            {
                int[] count = new int[10];
                foreach (char ch in i.ToString())
                {
                    count[ch - '0']++;
                }
                bool balanced = true;
                for (int j = 0; j < 10; j++)
                {
                    if (count[j] != 0 && count[j] != j)
                    {
                        balanced = false;
                        break;
                    }
                }
                if (balanced) return i;
            }
            return -1;
        }
    }
}
