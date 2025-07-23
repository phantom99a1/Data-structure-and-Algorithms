namespace Maximum_Score_From_Removing_Substrings
{
    public class Solution
    {
        public int MaximumGain(string s, int x, int y)
        {
            int score = 0;
            Stack<char> stack = new Stack<char>();

            string Remove(string str, char a, char b, int points)
            {
                foreach (char ch in str)
                {
                    if (stack.Count > 0 && stack.Peek() == a && ch == b)
                    {
                        stack.Pop();
                        score += points;
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
                var result = new string(stack.Reverse().ToArray());
                stack.Clear();
                return result;
            }

            if (x >= y)
            {
                s = Remove(s, 'a', 'b', x);
                Remove(s, 'b', 'a', y);
            }
            else
            {
                s = Remove(s, 'b', 'a', y);
                Remove(s, 'a', 'b', x);
            }

            return score;
        }
    }
}
