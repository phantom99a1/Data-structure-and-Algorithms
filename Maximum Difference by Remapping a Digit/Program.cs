namespace Maximum_Difference_by_Remapping_a_Digit
{
    public class Solution
    {
        public int MinMaxDifference(int num)
        {
            string str = num.ToString();

            // Max: replace first non-9 digit with 9
            char maxDigit = str.First(c => c != '9');
            int max = int.Parse(str.Replace(maxDigit, '9'));

            // Min: replace first digit with 0
            char minDigit = str[0];
            int min = int.Parse(str.Replace(minDigit, '0'));

            return max - min;
        }
    }
}
