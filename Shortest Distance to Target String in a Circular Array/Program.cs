namespace Shortest_Distance_to_Target_String_in_a_Circular_Array
{
    public class Solution
    {
        public int ClosestTarget(string[] words, string target, int startIndex) => words.Contains(target)
            ? words.Select((m, i) => (m, i)).
                Where(m => m.m == target).
                Min(m => Math.Min(Math.Abs(m.i - startIndex), Math.Abs(words.Length - Math.Abs(m.i - startIndex))))
            : -1;
    }
}
