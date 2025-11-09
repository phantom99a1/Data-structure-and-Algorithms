namespace Count_Operations_to_Obtain_Zero
{
    public class Solution
    {
        public int CountOperations(int num1, int num2)
        {
            int result = 0;
            while (num1 > 0 && num2 > 0)
            {
                if (num1 >= num2)
                {
                    num1 -= num2;
                }
                else
                {
                    num2 -= num1;
                }
                result++;
            }
            return result;
        }
    }
}
