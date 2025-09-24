using System.Text;

namespace Fraction_to_Recurring_Decimal
{
    public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0) return "0";

            StringBuilder result = new StringBuilder();

            // Handle sign
            if ((numerator < 0) ^ (denominator < 0)) result.Append("-");

            long num = Math.Abs((long)numerator);
            long den = Math.Abs((long)denominator);

            // Integer part
            result.Append(num / den);
            long remainder = num % den;
            if (remainder == 0) return result.ToString();

            result.Append(".");
            Dictionary<long, int> map = new Dictionary<long, int>();
            while (remainder != 0)
            {
                if (map.ContainsKey(remainder))
                {
                    int index = map[remainder];
                    result.Insert(index, "(");
                    result.Append(")");
                    break;
                }
                map[remainder] = result.Length;
                remainder *= 10;
                result.Append(remainder / den);
                remainder %= den;
            }

            return result.ToString();
        }
    }
}
