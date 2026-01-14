namespace Separate_Squares_II
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        const int EventTypeStart = 1;
        const int EventTypeEnd = -1;

        class SweepEvent
        {
            public int StartIndex;
            public int EndIndex;
            public int YCoordinate;
            public int Type;

            public SweepEvent(int startIndex, int endIndex, int yCoordinate, int type)
            {
                this.StartIndex = startIndex;
                this.EndIndex = endIndex;
                this.YCoordinate = yCoordinate;
                this.Type = type;
            }
        }

        class SegmentTreeNode
        {
            public int CoveredCount;
            public int CoveredLength;
            public bool IsLeftCovered = false;
            public bool IsRightCovered = false;
        }

        class IntervalSegmentTree
        {
            List<int> XCoordinates;
            SegmentTreeNode[] TreeNodes;
            int Size;

            public IntervalSegmentTree(SortedSet<int> uniqueCoordinates)
            {
                XCoordinates = uniqueCoordinates.ToList();
                Size = XCoordinates.Count;
                TreeNodes = new SegmentTreeNode[Size * 4];
                for (int Index = 0; Index < TreeNodes.Length; Index++)
                {
                    TreeNodes[Index] = new SegmentTreeNode();
                }
            }

            public void UpdateRange(int targetLeft, int targetRight, int changeAmount)
            {
                UpdateRecursive(targetLeft, targetRight, changeAmount, 1, 0, Size - 1);
            }

            private void UpdateRecursive(int targetLeft, int targetRight, int changeAmount, int nodeIndex, int nodeRangeLeft, int nodeRangeRight)
            {
                if (nodeRangeLeft > targetRight || nodeRangeRight < targetLeft)
                {
                    return;
                }

                if (targetLeft <= nodeRangeLeft && nodeRangeRight <= targetRight)
                {
                    TreeNodes[nodeIndex].CoveredCount += changeAmount;
                }
                else
                {
                    int rangeMid = (nodeRangeLeft + nodeRangeRight) / 2;
                    UpdateRecursive(targetLeft, targetRight, changeAmount, nodeIndex * 2, nodeRangeLeft, rangeMid);
                    UpdateRecursive(targetLeft, targetRight, changeAmount, nodeIndex * 2 + 1, rangeMid + 1, nodeRangeRight);
                }

                if (TreeNodes[nodeIndex].CoveredCount > 0)
                {
                    TreeNodes[nodeIndex].CoveredLength = XCoordinates[nodeRangeRight] - XCoordinates[nodeRangeLeft] + 1;
                    TreeNodes[nodeIndex].IsLeftCovered = true;
                    TreeNodes[nodeIndex].IsRightCovered = true;
                }
                else if (nodeRangeLeft == nodeRangeRight)
                {
                    TreeNodes[nodeIndex].CoveredLength = 0;
                    TreeNodes[nodeIndex].IsLeftCovered = false;
                    TreeNodes[nodeIndex].IsRightCovered = false;
                }
                else
                {
                    TreeNodes[nodeIndex].CoveredLength = TreeNodes[nodeIndex * 2].CoveredLength + TreeNodes[nodeIndex * 2 + 1].CoveredLength;
                    int rangeMid = (nodeRangeLeft + nodeRangeRight) / 2;
                    if (TreeNodes[nodeIndex * 2].IsRightCovered && TreeNodes[nodeIndex * 2 + 1].IsLeftCovered)
                    {
                        TreeNodes[nodeIndex].CoveredLength += XCoordinates[rangeMid + 1] - XCoordinates[rangeMid] - 1;
                    }
                    TreeNodes[nodeIndex].IsLeftCovered = TreeNodes[nodeIndex * 2].IsLeftCovered;
                    TreeNodes[nodeIndex].IsRightCovered = TreeNodes[nodeIndex * 2 + 1].IsRightCovered;
                }
            }

            public int GetTotalCoveredLength()
            {
                return TreeNodes[1].CoveredLength;
            }
        }

        public double SeparateSquares(int[][] squares)
        {
            var XCoordinateSet = new SortedSet<int>();
            foreach (var Square in squares)
            {
                int XPosition = Square[0];
                int SideLength = Square[2];
                XCoordinateSet.Add(XPosition - 1);
                XCoordinateSet.Add(XPosition);
                XCoordinateSet.Add(XPosition + SideLength - 1);
                XCoordinateSet.Add(XPosition + SideLength);
            }

            var CoordinateToIndexMap = new Dictionary<int, int>();
            int CurrentIndex = 0;
            foreach (int XValue in XCoordinateSet)
            {
                CoordinateToIndexMap[XValue] = CurrentIndex++;
            }

            var EventsList = new List<SweepEvent>();
            foreach (var Square in squares)
            {
                int XStart = Square[0];
                int YStart = Square[1];
                int SideLength = Square[2];
                int XEnd = XStart + SideLength - 1;

                EventsList.Add(new SweepEvent(CoordinateToIndexMap[XStart], CoordinateToIndexMap[XEnd], YStart, EventTypeStart));
                EventsList.Add(new SweepEvent(CoordinateToIndexMap[XStart], CoordinateToIndexMap[XEnd], YStart + SideLength, EventTypeEnd));
            }

            EventsList.Sort((FirstEvent, SecondEvent) => FirstEvent.YCoordinate.CompareTo(SecondEvent.YCoordinate));
            var SegmentTree = new IntervalSegmentTree(XCoordinateSet);

            int PreviousY = EventsList[0].YCoordinate;
            long TotalArea = 0;

            foreach (var CurrentEvent in EventsList)
            {
                TotalArea += 1L * (CurrentEvent.YCoordinate - PreviousY) * SegmentTree.GetTotalCoveredLength();
                PreviousY = CurrentEvent.YCoordinate;
                SegmentTree.UpdateRange(CurrentEvent.StartIndex, CurrentEvent.EndIndex, CurrentEvent.Type);
            }

            long CurrentAccumulatedArea = 0;
            PreviousY = EventsList[0].YCoordinate;

            foreach (var CurrentEvent in EventsList)
            {
                long NextAccumulatedArea = CurrentAccumulatedArea + 1L * (CurrentEvent.YCoordinate - PreviousY) * SegmentTree.GetTotalCoveredLength();

                if (NextAccumulatedArea >= (TotalArea + 1) / 2)
                {
                    double RemainingAreaNeeded = (TotalArea / 2.0) - CurrentAccumulatedArea;
                    return PreviousY + RemainingAreaNeeded / SegmentTree.GetTotalCoveredLength();
                }

                CurrentAccumulatedArea = NextAccumulatedArea;
                PreviousY = CurrentEvent.YCoordinate;
                SegmentTree.UpdateRange(CurrentEvent.StartIndex, CurrentEvent.EndIndex, CurrentEvent.Type);
            }

            throw new System.Exception("No valid line found.");
        }
    }
}
