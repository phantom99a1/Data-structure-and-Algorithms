namespace Lexicographical_Numbers
{
    public class Solution
    {
        public IList<int> LexicalOrder(int n)
        {
            List<int> result = new List<int>();
            void DFS(int num)
            {
                if (num > n) return;
                result.Add(num);
                for (int i = 0; i <= 9; i++)
                {
                    DFS(num * 10 + i);
                }
            }
            for (int i = 1; i <= 9; i++)
            {
                DFS(i);
            }
            return result;
        }
    }
}
