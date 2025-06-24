namespace Find_All_K_Distant_Indices_in_an_Array
{
    internal class Program
    {
        public IList<int> FindKDistantIndices(int[] nums, int key, int k)
        {
            var result = new List<int>();
            var keyIndices = new List<int>();

            // Collect all indices where nums[i] == key
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == key)
                {
                    keyIndices.Add(i);
                }
            }

            // Check each index to see if it's within k distance of any key index
            for (int i = 0; i < nums.Length; i++)
            {
                foreach (int j in keyIndices)
                {
                    if (Math.Abs(i - j) <= k)
                    {
                        result.Add(i);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
