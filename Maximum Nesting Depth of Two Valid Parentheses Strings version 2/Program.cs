namespace Maximum_Nesting_Depth_of_Two_Valid_Parentheses_Strings_version_2
{
    public class Solution
    {
        public int[] MaxDepthAfterSplit(string seq)
        {
            var result = new int[seq.Length];
            var currDepth = -1;

            for (var i = 0; i < seq.Length; i++)
            {
                if (seq[i] == '(')
                {
                    currDepth++;
                    result[i] = currDepth % 2;
                }
                else
                {
                    result[i] = currDepth % 2;
                    currDepth--;
                }
            }

            return result;
        }
    }
}
