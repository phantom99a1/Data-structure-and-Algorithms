namespace Check_if_Binary_String_Has_at_Most_One_Segment_of_Ones
{
    public class Solution
    {
        public bool CheckOnesSegment(string s)
        {
            return !s.Contains("01");
        }
    }
}
