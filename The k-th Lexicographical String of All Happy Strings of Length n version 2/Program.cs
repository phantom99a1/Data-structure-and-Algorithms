namespace The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n_version_2
{
    public class Solution
    {

        public string GetHappyString(int n, int k)
        {

            int total = 3 * (1 << (n - 1));
            if (k > total) return "";

            k--;

            string res = "";
            char last = '\0';

            for (int pos = 0; pos < n; pos++)
            {

                int branch = 1 << (n - pos - 1);

                List<char> choices = new List<char>();

                foreach (char c in new char[] { 'a', 'b', 'c' })
                    if (c != last) choices.Add(c);

                int idx = k / branch;

                res += choices[idx];
                last = choices[idx];

                k %= branch;
            }

            return res;
        }
    }
}
