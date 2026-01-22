namespace Minimum_Pair_Removal_to_Sort_Array_I
{
    public class Solution
    {
        bool IsSorted(List<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i + 1] >= nums[i]) continue;
                return false;
            }
            return true;
        }
        public int MinimumPairRemoval(int[] nums)
        {
            List<int> temp = new(nums);
            int count = 0;
            while (!IsSorted(temp))
            {
                int idx = FindMinIdx(temp);
                count++;
                temp[idx] = temp[idx] + temp[idx + 1];
                temp.RemoveAt(idx + 1);
            }
            return count;
        }
        int FindMinIdx(List<int> temp)
        {
            int cur = -1, min = int.MaxValue;
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (min > (temp[i] + temp[i + 1]))
                {
                    min = temp[i] + temp[i + 1];
                    cur = i;
                }
            }
            return cur;
        }
    }
}
