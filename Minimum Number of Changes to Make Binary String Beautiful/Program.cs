namespace Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful
{
    public class Solution
    {
        public int MinChanges(string s)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i += 2)
            {
                if (s[i] != s[i + 1])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
