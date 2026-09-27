namespace Reverse_Substrings_Between_Each_Pair_of_Parentheses
{
    using System;

    public class Solution
    {
        public string ReverseParentheses(string s)
        {
            Span<char> view = stackalloc char[s.Length];
            s.AsSpan().CopyTo(view);

            Span<int> stack = stackalloc int[s.Length];
            int top = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (view[i] == '(')
                {
                    stack[top++] = i;
                }
                else if (view[i] == ')')
                {
                    int start = stack[--top];

                    view.Slice(start + 1, i - start - 1).Reverse();
                }
            }

            Span<char> ret = stackalloc char[s.Length];
            int writeIndex = 0;

            foreach (char c in view)
            {
                if (c != '(' && c != ')')
                {
                    ret[writeIndex++] = c;
                }
            }

            return ret[..writeIndex].ToString();
        }
    }
}
