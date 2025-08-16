namespace Maximum_69_Number
{
    public class Solution
    {
        public int Maximum69Number(int num)
        {
            char[] digits = num.ToString().ToCharArray();

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == '6')
                {
                    digits[i] = '9';
                    break; // Only one change allowed
                }
            }

            return int.Parse(new string(digits));
        }
    }
}
