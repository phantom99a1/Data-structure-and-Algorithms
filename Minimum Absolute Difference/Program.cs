namespace Minimum_Absolute_Difference
{
    public class Solution
    {
        public IList<IList<int>> MinimumAbsDifference(int[] InputArray)
        {
            int MinValue = InputArray[0];
            int MaxValue = InputArray[0];

            for (int Index = 1; Index < InputArray.Length; ++Index)
            {
                int CurrentNumber = InputArray[Index];
                MinValue = Math.Min(MinValue, CurrentNumber);
                MaxValue = Math.Max(MaxValue, CurrentNumber);
            }

            int ValueRange = MaxValue - MinValue;
            bool[] NumberExists = new bool[ValueRange + 1];

            for (int Index = 0; Index < InputArray.Length; ++Index)
            {
                NumberExists[InputArray[Index] - MinValue] = true;
            }

            var ResultPairs = new List<IList<int>>();
            int PreviousValue = MinValue;
            int MinDifference = ValueRange;

            for (int Offset = 1; Offset < NumberExists.Length; ++Offset)
            {
                if (!NumberExists[Offset])
                {
                    continue;
                }

                int CurrentValue = MinValue + Offset;
                int CurrentDifference = CurrentValue - PreviousValue;
                int LeftValue = PreviousValue;

                PreviousValue = CurrentValue;

                if (CurrentDifference > MinDifference)
                {
                    continue;
                }

                if (CurrentDifference < MinDifference)
                {
                    MinDifference = CurrentDifference;
                    ResultPairs.Clear();
                }

                ResultPairs.Add(new int[] { LeftValue, CurrentValue });
            }

            return ResultPairs;
        }
    }
}
