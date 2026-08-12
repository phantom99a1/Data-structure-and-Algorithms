namespace Length_of_Longest_Subarray_With_at_Most_K_Frequency
{
    public class Solution
    {
        public int MaxSubarrayLength(int[] nums, int k)
        {
            int left = 0;
            int ans = 0;
            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int right = 0; right < nums.Length; right++)
            {
                // добавляем правый элемент в окно
                if (!count.ContainsKey(nums[right]))
                    count[nums[right]] = 0;
                count[nums[right]]++;

                // если частота превысила k, сужаем окно слева
                while (count[nums[right]] > k)
                {
                    count[nums[left]]--;
                    left++;
                }

                // обновляем ответ
                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }
    }
}
