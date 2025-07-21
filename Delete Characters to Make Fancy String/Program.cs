using System.Text;

namespace Delete_Characters_to_Make_Fancy_String
{
    public class Solution
    {
        public string MakeFancyString(string s)
        {
            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (result.Length >= 2 &&
                    result[result.Length - 1] == s[i] &&
                    result[result.Length - 2] == s[i])
                {
                    continue; // Skip the third identical character
                }
                result.Append(s[i]);
            }
            return result.ToString();
        }
    }
}
