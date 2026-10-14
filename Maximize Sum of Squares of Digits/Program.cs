using System.Text;

namespace Maximize_Sum_of_Squares_of_Digits
{
    public class Solution
    {
        public string MaxSumOfSquares(int num, int sum)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                if (sum >= 9)
                {
                    ans.Append('9');
                    sum -= 9;
                }
                else
                {
                    ans.Append(sum);
                    sum = 0;
                }
            }
            if (sum > 0) return "";
            return ans.ToString();
        }
    }
}
