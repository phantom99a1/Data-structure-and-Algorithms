namespace The_Two_Sneaky_Numbers_of_Digitville
{
    public class Solution
    {
        public int[] GetSneakyNumbers(int[] nums)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            List<int> result = new List<int>();

            foreach (int num in nums)
            {
                if (!count.ContainsKey(num)) count[num] = 0;
                count[num]++;
                if (count[num] == 2)
                {
                    result.Add(num);
                    if (result.Count == 2) break;
                }
            }

            return result.ToArray();
        }
    }
}
