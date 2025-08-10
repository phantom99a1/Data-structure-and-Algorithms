namespace Reordered_Power_of_2
{
    public class Solution
    {
        public bool ReorderedPowerOf2(int n)
        {
            string CountDigits(int num)
            {
                char[] digits = num.ToString().ToCharArray();
                Array.Sort(digits);
                return new string(digits);
            }

            string target = CountDigits(n);
            for (int i = 0; i < 31; i++)
            {
                int power = 1 << i;
                if (CountDigits(power) == target)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
