namespace Divide_Array_Into_Arrays_With_Max_Difference
{
    internal class Program
    {
        public IList<IList<int>> DivideArray(int[] nums, int k)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i += 3)
            {
                if (nums[i + 2] - nums[i] > k) return new List<IList<int>>();
                result.Add(new List<int> { nums[i], nums[i + 1], nums[i + 2] });
            }

            return result;
        }
    }
}
