namespace Minimum_Element_After_Replacement_With_Digit_Sum
{
    public class Solution
    {
        public int MinElement(int[] nums) => nums.
            Select(n => n.ToString().
                    ToCharArray().
                    Sum(n => (int)char.GetNumericValue(n))).
            Min();
    }
}
