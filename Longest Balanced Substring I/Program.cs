namespace Longest_Balanced_Substring_I
{
    public class Solution
    {
        private bool IsValid(int[] FrequencyArray)
        {
            int TargetCount = 0;

            for (int Index = 0; Index < FrequencyArray.Length; Index++)
            {
                if (FrequencyArray[Index] == 0)
                    continue;

                if (TargetCount == 0)
                    TargetCount = FrequencyArray[Index];
                else if (FrequencyArray[Index] != TargetCount)
                    return false;
            }

            return true;
        }

        public int LongestBalanced(string InputString)
        {
            int MaxLength = int.MinValue;

            for (int StartIndex = 0; StartIndex < InputString.Length; StartIndex++)
            {
                int[] FrequencyArray = new int[26];

                for (int EndIndex = StartIndex; EndIndex < InputString.Length; EndIndex++)
                {
                    FrequencyArray[InputString[EndIndex] - 'a']++;

                    if (IsValid(FrequencyArray))
                        MaxLength = Math.Max(MaxLength, EndIndex - StartIndex + 1);
                }
            }

            return MaxLength;
        }
    }
}
