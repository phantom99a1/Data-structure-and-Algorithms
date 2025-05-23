namespace Find_the_Maximum_Sum_of_Node_Values
{
    /*There exists an undirected tree with n nodes numbered 0 to n - 1. You are given a 0-indexed 2D integer array edges of 
     length n - 1, where edges[i] = [ui, vi] indicates that there is an edge between nodes ui and vi in the tree. 
    You are also given a positive integer k, and a 0-indexed array of non-negative integers nums of length n, 
    where nums[i] represents the value of the node numbered i. Alice wants the sum of values of tree nodes to be maximum, 
    for which Alice can perform the following operation any number of times (including zero) on the tree:
    Choose any edge [u, v] connecting the nodes u and v, and update their values as follows:
    nums[u] = nums[u] XOR k
    nums[v] = nums[v] XOR k
    Return the maximum possible sum of the values Alice can achieve by performing the operation any number of times.
    
     Constraint:
    2 <= n == nums.length <= 2 * 10^4
    1 <= k <= 10^9
    0 <= nums[i] <= 10^9
    edges.length == n - 1
    edges[i].length == 2
    0 <= edges[i][0], edges[i][1] <= n - 1
    The input is generated such that edges represent a valid tree.
     */
    internal class Program
    {
        public static long MaximumValueSum(int[] nums, int k, int[][] edges)
        {
            long maxSum = 0, changedCount = 0, minChangeDiff = int.MaxValue;
            foreach (int num in nums)
            {
                maxSum += Math.Max(num, num ^ k);
                changedCount += (num ^ k) > num ? 1 : 0;
                minChangeDiff = Math.Min(minChangeDiff, Math.Abs(num - (num ^ k)));
            }
            return changedCount % 2 == 0 ? maxSum : maxSum - minChangeDiff;
        }
    }
}
