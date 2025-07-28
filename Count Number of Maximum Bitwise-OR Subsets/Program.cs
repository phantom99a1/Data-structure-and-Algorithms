namespace Count_Number_of_Maximum_Bitwise_OR_Subsets
{
    public class Solution
    {
        public int CountMaxOrSubsets(int[] nums)
        {
            int maxOr = 0, count = 0;

            void Backtrack(int index, int currentOr)
            {
                if (index == nums.Length)
                {
                    if (currentOr > maxOr)
                    {
                        maxOr = currentOr;
                        count = 1;
                    }
                    else if (currentOr == maxOr)
                    {
                        count++;
                    }
                    return;
                }
                // Include nums[index]
                Backtrack(index + 1, currentOr | nums[index]);
                // Exclude nums[index]
                Backtrack(index + 1, currentOr);
            }

            Backtrack(0, 0);
            return count;
        }
    }
}
