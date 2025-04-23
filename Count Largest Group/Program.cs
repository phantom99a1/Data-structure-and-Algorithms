namespace Count_Largest_Group
{
    /*You are given an integer n. Each number from 1 to n is grouped according to the sum of its digits.
    Return the number of groups that have the largest size.
    
     Constraint:
    1 <= n <= 10^4
     */

    public class Solution
    {
        public int CountLargestGroup(int n)
        {
            Dictionary<int, int> digitSumCount = new Dictionary<int, int>();
            int maxSize = 0, largestGroupCount = 0;

            for (int i = 1; i <= n; i++)
            {
                int sum = GetDigitSum(i);
                if (!digitSumCount.ContainsKey(sum))
                {
                    digitSumCount[sum] = 0;
                }
                digitSumCount[sum]++;
                maxSize = Math.Max(maxSize, digitSumCount[sum]);
            }

            foreach (var count in digitSumCount.Values)
            {
                if (count == maxSize) largestGroupCount++;
            }

            return largestGroupCount;
        }

        private int GetDigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
