namespace Calculate_Digit_Sum_of_a_String
{
    public class Solution
    {
        public string DigitSum(string s, int k) => s.Length <= k
            ? s
            : DigitSum(string.Concat(s.Chunk(k).Select(m => m.Sum(n => char.GetNumericValue(n)).ToString())), k);
    }
}
