namespace Maximum_Candies_You_Can_Get_from_Boxes
{
    /*You have n boxes labeled from 0 to n - 1. You are given four arrays: status, candies, keys, and containedBoxes where:
    status[i] is 1 if the ith box is open and 0 if the ith box is closed, candies[i] is the number of candies in the ith box,
    keys[i] is a list of the labels of the boxes you can open after opening the ith box.
    containedBoxes[i] is a list of the boxes you found inside the ith box.
    You are given an integer array initialBoxes that contains the labels of the boxes you initially have. 
    You can take all the candies in any open box and you can use the keys in it to open new boxes and 
    you also can use the boxes you find in it. Return the maximum number of candies you can get following the rules above.
    
     Constraint:
    n == status.length == candies.length == keys.length == containedBoxes.length
    1 <= n <= 1000
    status[i] is either 0 or 1.
    1 <= candies[i] <= 1000
    0 <= keys[i].length <= n
    0 <= keys[i][j] < n
    All values of keys[i] are unique.
    0 <= containedBoxes[i].length <= n
    0 <= containedBoxes[i][j] < n
    All values of containedBoxes[i] are unique.
    Each box is contained in one box at most.
    0 <= initialBoxes.length <= n
    0 <= initialBoxes[i] < n
     */
    public class Solution
    {
        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            int n = status.Length;
            bool[] hasKey = new bool[n];
            bool[] boxOwned = new bool[n];
            bool[] boxVisited = new bool[n];

            Queue<int> queue = new Queue<int>();

            foreach (int box in initialBoxes)
            {
                boxOwned[box] = true;
                queue.Enqueue(box);
            }

            int totalCandies = 0;
            bool progress = true;

            while (progress)
            {
                progress = false;
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int box = queue.Dequeue();
                    if (!boxVisited[box] && (status[box] == 1 || hasKey[box]))
                    {
                        boxVisited[box] = true;
                        progress = true;

                        totalCandies += candies[box];

                        foreach (int key in keys[box])
                        {
                            hasKey[key] = true;
                            if (boxOwned[key] && !boxVisited[key])
                            {
                                queue.Enqueue(key);
                            }
                        }

                        foreach (int contained in containedBoxes[box])
                        {
                            boxOwned[contained] = true;
                            queue.Enqueue(contained);
                        }
                    }
                    else
                    {
                        queue.Enqueue(box);
                    }
                }
            }

            return totalCandies;
        }
    }
}
