namespace Minimum_Operations_to_Convert_All_Elements_to_Zero
{
    public class Solution
    {
        public int MinOperations(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            int operations = 0;

            foreach (int num in nums)
            {
                while (stack.Count > 0 && stack.Peek() > num)
                {
                    stack.Pop();
                }
                if (stack.Count == 0 || stack.Peek() < num)
                {
                    operations++;
                    stack.Push(num);
                }
            }

            return operations;
        }
    }
}
