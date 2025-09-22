namespace Count_Elements_With_Maximum_Frequency
{
    internal class Program
    {
        public int MaxFrequencyElements(int[] nums)
        {
            int[] freq = new int[101];
            int maxFreq = 0;
            int result = 0;

            foreach (int num in nums)
            {
                freq[num]++;
                maxFreq = Math.Max(maxFreq, freq[num]);
            }

            foreach (int count in freq)
            {
                if (count == maxFreq)
                {
                    result += count;
                }
            }

            return result;
        }
    }
}
