namespace Separate_the_Digits_in_an_Array
{
    public class Solution
    {
        public int[] SeparateDigits(int[] nums)
        {
            return (string.Join(null, nums).ToCharArray()).Select(item => item - '0').ToArray();
        }
    }
}
