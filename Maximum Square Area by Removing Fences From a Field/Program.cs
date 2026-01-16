namespace Maximum_Square_Area_by_Removing_Fences_From_a_Field
{
    public class Solution
    {
        public int MaximizeSquareArea(int GridHeight, int GridWidth, int[] HorizontalCuts, int[] VerticalCuts)
        {
            long ModuloConstant = 1000000007;

            List<int> PrepareCutsList(int[] RawCuts, int BoundaryLimit)
            {
                Array.Sort(RawCuts);
                var ProcessedCuts = new List<int>()
            {
                1
            };
                ProcessedCuts.AddRange(RawCuts);
                ProcessedCuts.Add(BoundaryLimit);
                return ProcessedCuts;
            }

            var HorizontalPositions = PrepareCutsList(HorizontalCuts, GridHeight);
            var VerticalPositions = PrepareCutsList(VerticalCuts, GridWidth);

            var HorizontalGaps = new HashSet<int>();
            for (int StartIndex = 0; StartIndex < HorizontalPositions.Count; StartIndex++)
            {
                for (int EndIndex = StartIndex + 1; EndIndex < HorizontalPositions.Count; EndIndex++)
                {
                    HorizontalGaps.Add(HorizontalPositions[EndIndex] - HorizontalPositions[StartIndex]);
                }
            }

            long MaxSideLength = 0;
            for (int StartIndex = 0; StartIndex < VerticalPositions.Count; StartIndex++)
            {
                for (int EndIndex = StartIndex + 1; EndIndex < VerticalPositions.Count; EndIndex++)
                {
                    int CurrentGap = VerticalPositions[EndIndex] - VerticalPositions[StartIndex];
                    if (CurrentGap > MaxSideLength && HorizontalGaps.Contains(CurrentGap))
                    {
                        MaxSideLength = CurrentGap;
                    }
                }
            }

            if (MaxSideLength == 0)
            {
                return -1;
            }

            return (int)((MaxSideLength * MaxSideLength) % ModuloConstant);
        }
    }
}
