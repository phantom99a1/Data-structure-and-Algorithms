namespace Search_in_Rotated_Sorted_Array
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            (int l, int r) = (0, nums.Length - 1);
            while (l < r)
            {
                if (nums[l] == target)
                {
                    return l;
                }

                if (nums[r] == target)
                {
                    return r;
                }

                int pivot = l + (r - l) / 2;
                if (nums[pivot] == target)
                {
                    return pivot;
                }
                else if (nums[pivot] > nums[r])
                {
                    l = pivot + 1;
                }
                else
                {
                    r = pivot;
                }
            }

            (int mid, l, r) = (l, 0, nums.Length - 1);
            if (target >= nums[mid] && target <= nums[r])
            {
                l = mid;
            }
            else
            {
                r = mid - 1;
            }

            while (l <= r)
            {
                int pivot = l + (r - l) / 2;
                if (nums[pivot] == target)
                {
                    return pivot;
                }
                else if (target < nums[pivot])
                {
                    r = pivot - 1;
                }
                else
                {
                    l = pivot + 1;
                }
            }

            return -1;
        }
    }
}
