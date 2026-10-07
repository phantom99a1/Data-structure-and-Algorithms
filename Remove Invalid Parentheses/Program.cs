namespace Remove_Invalid_Parentheses
{
    public class Solution
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var result = new List<string>();
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            bool found = false;

            queue.Enqueue(s);
            visited.Add(s);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                var level = new HashSet<string>();

                for (int i = 0; i < size; i++)
                {
                    var str = queue.Dequeue();
                    if (IsValid(str))
                    {
                        result.Add(str);
                        found = true;
                    }

                    if (found) continue; // skip deeper levels

                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] != '(' && str[j] != ')') continue;
                        var newStr = str.Substring(0, j) + str.Substring(j + 1);
                        if (!visited.Contains(newStr))
                        {
                            queue.Enqueue(newStr);
                            visited.Add(newStr);
                        }
                    }
                }

                if (found) break;
            }

            return result;
        }

        private bool IsValid(string s)
        {
            int count = 0;
            foreach (char c in s)
            {
                if (c == '(') count++;
                else if (c == ')')
                {
                    count--;
                    if (count < 0) return false;
                }
            }
            return count == 0;
        }
    }
}
