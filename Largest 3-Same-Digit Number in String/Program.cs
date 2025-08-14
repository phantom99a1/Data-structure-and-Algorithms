namespace Largest_3_Same_Digit_Number_in_String
{
    public class Solution
    {
        public string LargestGoodInteger(string num)
        {
            for (char c = '9'; c >= '0'; c--)
            {
                string triplet = new string(c, 3);
                if (num.Contains(triplet))
                {
                    return triplet;
                }
            }
            return "";
        }
    }
}
