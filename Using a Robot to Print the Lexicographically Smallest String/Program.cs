using System.Text;

namespace Using_a_Robot_to_Print_the_Lexicographically_Smallest_String
{
    public class Solution
    {
        public string RobotWithString(string s)
        {
            int[] count = new int[26];
            foreach (char ch in s) count[ch - 'a']++;

            Stack<char> stack = new Stack<char>();
            StringBuilder result = new StringBuilder();
            int minChar = 0;

            foreach (char ch in s)
            {
                count[ch - 'a']--;
                stack.Push(ch);

                while (minChar < 26 && count[minChar] == 0) minChar++;

                while (stack.Count > 0 && (stack.Peek() - 'a') <= minChar)
                {
                    result.Append(stack.Pop());
                }
            }

            while (stack.Count > 0) result.Append(stack.Pop());
            return result.ToString();
        }
    }
}
