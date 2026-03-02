namespace Number_of_Steps_to_Reduce_a_Number_in_Binary_Representation_to_One
{
    public class Solution
    {
        public int NumSteps(string s)
        {
            int steps = 0, carry = 0;
            for (int i = s.Length - 1; i > 0; i--)
            {
                if ((s[i] == '1' ? 1 : 0) + carry == 1)
                {
                    steps += 2;
                    carry = 1;
                }
                else
                    steps += 1;
            }

            return steps + carry;
        }
    }
}
