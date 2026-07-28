namespace Smallest_Palindromic_Rearrangement_I
{
    public class Solution
    {
        public string SmallestPalindrome(string s)
        {
            int n = s.Length;
            int[] bucket = new int[26];

            for (int i = 0; i < n / 2; i++)
            {
                bucket[s[i] - 'a']++;
            }

            char[] res = new char[n];
            int left = 0;
            int right = n - 1;

            for (int i = 0; i < 26; i++)
            {
                while (bucket[i] > 0)
                {
                    char c = (char)(i + 'a');
                    res[left++] = c;
                    res[right--] = c;
                    bucket[i]--;
                }
            }

            if (n % 2 != 0)
            {
                res[left] = s[n / 2];
            }

            return new string(res);
        }
    }
}
