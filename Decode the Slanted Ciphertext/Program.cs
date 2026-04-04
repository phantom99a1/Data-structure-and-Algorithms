using System.Text;

namespace Decode_the_Slanted_Ciphertext
{
    public class Solution
    {
        private static readonly string NO_TEXT = "";

        public string DecodeCiphertext(string encodedText, int rows)
        {
            if (rows == 1)
            {
                return encodedText;
            }
            if (encodedText.Length == 0)
            {
                return NO_TEXT;
            }

            int lastNonSpaceIndexInOriginalText = 0;
            int columns = encodedText.Length / rows;
            StringBuilder originalText = new();

            for (int column = 0; column < columns; ++column)
            {
                int index = column;

                while (index < encodedText.Length)
                {
                    if (encodedText[index] != ' ')
                    {
                        lastNonSpaceIndexInOriginalText = originalText.Length;
                    }
                    originalText.Append(encodedText[index]);
                    index += columns + 1;
                }
            }

            return originalText.ToString().Substring(0, lastNonSpaceIndexInOriginalText + 1);
        }
    }
}
