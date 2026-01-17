namespace Find_the_Largest_Area_of_Square_Inside_Two_Rectangles
{
    public class Solution
    {
        public long LargestSquareArea(int[][] BottomLeftCoordinates, int[][] TopRightCoordinates)
        {
            long MaxSquareArea = 0;
            int RectangleCount = BottomLeftCoordinates.Length;

            for (int FirstRectIndex = 0; FirstRectIndex < RectangleCount; FirstRectIndex++)
            {
                for (int SecondRectIndex = FirstRectIndex + 1; SecondRectIndex < RectangleCount; SecondRectIndex++)
                {
                    int IntersectionRightX = Math.Min(TopRightCoordinates[FirstRectIndex][0], TopRightCoordinates[SecondRectIndex][0]);
                    int IntersectionLeftX = Math.Max(BottomLeftCoordinates[FirstRectIndex][0], BottomLeftCoordinates[SecondRectIndex][0]);
                    int HorizontalOverlap = Math.Max(0, IntersectionRightX - IntersectionLeftX);

                    int IntersectionTopY = Math.Min(TopRightCoordinates[FirstRectIndex][1], TopRightCoordinates[SecondRectIndex][1]);
                    int IntersectionBottomY = Math.Max(BottomLeftCoordinates[FirstRectIndex][1], BottomLeftCoordinates[SecondRectIndex][1]);
                    int VerticalOverlap = Math.Max(0, IntersectionTopY - IntersectionBottomY);

                    int SquareSideLength = Math.Min(HorizontalOverlap, VerticalOverlap);
                    MaxSquareArea = Math.Max(MaxSquareArea, (long)SquareSideLength * SquareSideLength);
                }
            }

            return MaxSquareArea;
        }
    }
}
