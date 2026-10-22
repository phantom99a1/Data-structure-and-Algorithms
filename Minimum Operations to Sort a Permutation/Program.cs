namespace Minimum_Operations_to_Sort_a_Permutation
{
    public class Solution
    {
        public int MinOperations(int[] nums)
        {
            if (nums.Length <= 2) return nums[0];
            var (sortedType, zeroIndex) = GetSortedTypeAndZeroIndex(nums);
            var rs = -1;
            switch (sortedType)
            {
                case Sorted.Increasing:
                    rs = MinOperationsIncreasing(zeroIndex, nums);
                    break;
                case Sorted.Decreasing:
                    rs = MinOperationsDecreasing(zeroIndex, nums);
                    break;
            }
            return rs;
        }
        private int MinOperationsDecreasing(int zeroIndex, int[] nums)
        {
            var rs = Math.Min(zeroIndex + 2, nums.Length - zeroIndex);
            return rs;
        }
        private int MinOperationsIncreasing(int zeroIndex, int[] nums)
        {
            var rs = Math.Min(zeroIndex, nums.Length - zeroIndex + 2);
            return rs;
        }
        private (Sorted sortedType, int zeroIndex) GetSortedTypeAndZeroIndex(int[] nums)
        {
            var zeroIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroIndex = i;
                    break;
                }
            }
            if (nums[zeroIndex] + 1 == nums[(zeroIndex + 1) % nums.Length])
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i != nums[(zeroIndex + i) % nums.Length])
                    {
                        return (Sorted.Mixed, zeroIndex);
                    }
                }
                return (Sorted.Increasing, zeroIndex);
            }
            if (nums[zeroIndex] + 1 == nums[(zeroIndex + nums.Length - 1) % nums.Length])
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i != nums[(zeroIndex + nums.Length - i) % nums.Length])
                    {
                        return (Sorted.Mixed, zeroIndex);
                    }
                }
                return (Sorted.Decreasing, zeroIndex);
            }
            return (Sorted.Mixed, zeroIndex);
        }
        private enum Sorted
        {
            Increasing,
            Decreasing,
            Mixed
        }
    }
}
