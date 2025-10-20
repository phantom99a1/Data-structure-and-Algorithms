namespace Final_Value_of_Variable_After_Performing_Operations
{
    public class Solution
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            int x = 0;
            foreach (string op in operations)
            {
                if (op.Contains("+"))
                {
                    x++;
                }
                else
                {
                    x--;
                }
            }
            return x;
        }
    }
}
