namespace Count_Binary_Substrings
{
    public class Solution
    {
        public int CountBinarySubstrings(string InputString)
        {
            int PreviousRunLength = 0;
            int CurrentRunLength = 1;
            int TotalSubstrings = 0;

            for (int Index = 1; Index < InputString.Length; Index++)
            {
                if (InputString[Index] == InputString[Index - 1])
                    CurrentRunLength++;
                else
                {
                    PreviousRunLength = CurrentRunLength;
                    CurrentRunLength = 1;
                }

                if (PreviousRunLength >= CurrentRunLength)
                    TotalSubstrings++;
            }

            return TotalSubstrings;
        }
    }
}
