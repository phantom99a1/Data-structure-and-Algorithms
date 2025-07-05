namespace Find_Lucky_Integer_in_an_Array
{
    internal class Program
    {
        public int FindLucky(int[] arr)
        {
            var dict = new Dictionary<int, int>();

            foreach (int num in arr)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            int result = -1;
            foreach (var kvp in dict)
            {
                if (kvp.Key == kvp.Value)
                    result = Math.Max(result, kvp.Key);
            }

            return result;
        }
    }
}
