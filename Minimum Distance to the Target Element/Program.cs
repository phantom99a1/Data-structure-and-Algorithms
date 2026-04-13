namespace Minimum_Distance_to_the_Target_Element
{
    public class Solution
    {
        public int GetMinDistance(int[] nums, int target, int start) => nums.
            Select((m, i) => new { value = m, index = i }).
            Where(m => m.value == target).
            Select((m, i) => Math.Abs(m.index - start)).
            Min();
    }
}
