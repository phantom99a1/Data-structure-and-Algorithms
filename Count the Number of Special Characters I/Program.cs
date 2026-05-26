namespace Count_the_Number_of_Special_Characters_I
{
    public class Solution
    {
        public int NumberOfSpecialChars(string word) => word.
            ToLower().
            GroupBy(m => m).
            Count(m => word.Contains(char.ToLower(m.Key)) && word.Contains(char.ToUpper(m.Key)));
    }
}
