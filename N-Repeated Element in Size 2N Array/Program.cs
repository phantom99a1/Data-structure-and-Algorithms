namespace N_Repeated_Element_in_Size_2N_Array
{
    public class Solution
    {
        public int RepeatedNTimes(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (var x in nums)
            {
                if (!set.Add(x)) return x;
            }
            return -1;
        }
    }
}
