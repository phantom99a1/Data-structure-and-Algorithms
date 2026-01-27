namespace Minimum_Cost_Path_with_Edge_Reversals
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public int MinCost(int TotalNodes, int[][] Connections)
        {
            var Graph = new List<(int NodeIndex, int Weight)>[TotalNodes];
            for (int Index = 0; Index < TotalNodes; Index++)
            {
                Graph[Index] = new List<(int, int)>();
            }

            foreach (var Connection in Connections)
            {
                int NodeA = Connection[0];
                int NodeB = Connection[1];
                int Weight = Connection[2];

                Graph[NodeA].Add((NodeB, Weight));
                Graph[NodeB].Add((NodeA, 2 * Weight));
            }

            int[] MinDistances = new int[TotalNodes];
            bool[] VisitedNodes = new bool[TotalNodes];
            Array.Fill(MinDistances, int.MaxValue);
            MinDistances[0] = 0;

            var PriorityQueue = new PriorityQueue<(int Distance, int NodeIndex), int>();
            PriorityQueue.Enqueue((0, 0), 0);

            while (PriorityQueue.Count > 0)
            {
                var CurrentState = PriorityQueue.Dequeue();
                int CurrentDistance = CurrentState.Distance;
                int CurrentNode = CurrentState.NodeIndex;

                if (CurrentNode == TotalNodes - 1)
                {
                    return CurrentDistance;
                }

                if (VisitedNodes[CurrentNode])
                {
                    continue;
                }

                VisitedNodes[CurrentNode] = true;

                foreach (var Neighbor in Graph[CurrentNode])
                {
                    int NeighborNode = Neighbor.NodeIndex;
                    int EdgeWeight = Neighbor.Weight;

                    if (CurrentDistance + EdgeWeight < MinDistances[NeighborNode])
                    {
                        MinDistances[NeighborNode] = CurrentDistance + EdgeWeight;
                        PriorityQueue.Enqueue((MinDistances[NeighborNode], NeighborNode), MinDistances[NeighborNode]);
                    }
                }
            }

            return -1;
        }
    }
}
