namespace Rank_Transform_of_an_Array
{
    public class Solution
    {
        public int[] ArrayRankTransform(int[] arr) => arr
            .Select((num, i) => (num, index: i))
            .GroupBy(t => t.num, t => t.index)
            .OrderBy(gr => gr.Key)
            .Select((gr, i) => (rank: i + 1, indexes: gr))
            .SelectMany(p => p.indexes, (p, index) => (p.rank, index))
            .OrderBy(r => r.index)
            .Select(r => r.rank)
            .ToArray();
    }
}
