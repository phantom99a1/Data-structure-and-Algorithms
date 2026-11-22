namespace Check_if_All_A_s_Appears_Before_All_B_s
{
    public class Solution
    {
        public bool CheckString(string s)
        {
            for (int i = 0; i + 1 < s.Length; i++)
            {
                if (s[i] == 'b' && s[i + 1] == 'a')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
