namespace Unique_3_Digit_Even_Numbers
{
    public class Solution
    {
        public int TotalNumbers(int[] digits) =>
            digits.SelectMany((a, i) =>
                digits.Where((_, j) => j != i).
                    SelectMany((b, j) => digits.Where((_, k) => k != i && k != (j >= i ? j + 1 : j)).
                        Where(c => a != 0 && c % 2 == 0).
            Select(c => a * 100 + b * 10 + c))).
            Distinct().
            Count();
    }
}
