namespace Lexicographically_Minimum_String_After_Removing_Stars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Solution
    {
        static readonly int ALPHABET_SIZE = 26;
        static readonly char CHAR_MARK = '*';

        public string ClearStars(string s)
        {
            Stack<int>[] indexesPerLetter = new Stack<int>[ALPHABET_SIZE];
            for (int letter = 0; letter < ALPHABET_SIZE; ++letter)
            {
                indexesPerLetter[letter] = new Stack<int>();
            }

            char[] input = s.ToCharArray();
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == CHAR_MARK)
                {
                    MarkLexicographicallySmallestLetterForRemovalInInput(indexesPerLetter, input);
                }
                else
                {
                    indexesPerLetter[input[i] - 'a'].Push(i);
                }
            }

            return CreateLexicographicallyMinimumStringAfterRemovingStars(input);
        }

        private void MarkLexicographicallySmallestLetterForRemovalInInput(Stack<int>[] indexesPerLetter, char[] input)
        {
            for (int letter = 0; letter < ALPHABET_SIZE; ++letter)
            {
                if (indexesPerLetter[letter].Count > 0)
                {
                    int index = indexesPerLetter[letter].Pop();
                    input[index] = CHAR_MARK;
                    return;
                }
            }
        }

        private String CreateLexicographicallyMinimumStringAfterRemovingStars(char[] input)
        {
            StringBuilder lexicographicallyMinimumString = new StringBuilder();
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] != CHAR_MARK)
                {
                    lexicographicallyMinimumString.Append(input[i]);
                }
            }
            return lexicographicallyMinimumString.ToString();
        }
    }
}
