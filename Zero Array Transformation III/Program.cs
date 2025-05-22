namespace Zero_Array_Transformation_III
{
    /*You are given an integer array nums of length n and a 2D array queries where queries[i] = [li, ri].
    Each queries[i] represents the following action on nums:
    Decrement the value at each index in the range [li, ri] in nums by at most 1.
    The amount by which the value is decremented can be chosen independently for each index.
    A Zero Array is an array with all its elements equal to 0. Return the maximum number of elements that can be removed from 
    queries, such that nums can still be converted to a zero array using the remaining queries. 
    If it is not possible to convert nums to a zero array, return -1.
    
     Constraint:
    1 <= nums.length <= 10^5
    0 <= nums[i] <= 10^5
    1 <= queries.length <= 10^5
    queries[i].length == 2
    0 <= li <= ri < nums.length
     */
    public class Solution
    {
        public int MaxRemoval(int[] nums, int[][] queries)
        {
            Array.Sort(queries, (a, b) => a[0] - b[0]);
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(
                Comparer<int>.Create((a, b) => -1 * a.CompareTo(b)));
            int[] sweep = new int[nums.Length + 1];
            int index = 0, cs = 0, taken = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                cs += sweep[i];
                while (index < queries.Length && queries[index][0] <= i)
                {
                    pq.Enqueue(queries[index][1], queries[index][1]);
                    index++;
                }
                while (pq.Count > 0 && cs < nums[i])
                {
                    int top = pq.Peek();
                    pq.Dequeue();
                    if (top < i)
                    {
                        continue;
                    }
                    cs++;
                    taken++;
                    sweep[top + 1] += -1;
                }
                if (cs < nums[i])
                    return -1;
            }
            return queries.Length - taken;
        }
    }
}
