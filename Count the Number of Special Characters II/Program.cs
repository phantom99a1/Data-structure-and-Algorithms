namespace Count_the_Number_of_Special_Characters_II
{
    using System.Collections.Generic;

    public class Solution
    {
        public int NumberOfSpecialChars(string word)
        {
            int[] lastLower = new int[26];
            int[] firstUpper = new int[26];

            for (int i = 0; i < 26; i++)
            {
                lastLower[i] = -1;
                firstUpper[i] = -1;
            }

            HashSet<int> invalid = new HashSet<int>();

            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];

                if (ch >= 'a' && ch <= 'z')
                {
                    int idx = ch - 'a';

                    lastLower[idx] = i;

                    if (firstUpper[idx] != -1)
                    {
                        invalid.Add(idx);
                    }

                }
                else
                {
                    int idx = ch - 'A';

                    if (firstUpper[idx] == -1)
                    {
                        firstUpper[idx] = i;
                    }
                }
            }

            int specialCount = 0;

            for (int i = 0; i < 26; i++)
            {
                if (lastLower[i] != -1 &&
                    firstUpper[i] != -1 &&
                    !invalid.Contains(i))
                {

                    specialCount++;
                }
            }

            return specialCount;
        }
    }
}
