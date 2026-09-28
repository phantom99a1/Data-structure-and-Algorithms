namespace Maximum_Nesting_Depth_of_the_Parentheses
{
    public class Solution
    {
        public int MaxDepth(string s)
        {
            int count = 0, max = 0;
            foreach (char c in s)
            {
                if (c == '(')
                    count++;
                max = Math.Max(count, max);
                if (c == ')')
                    count--;
            }
            return max;
        }
    }
}
