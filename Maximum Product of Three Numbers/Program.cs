namespace Maximum_Product_of_Three_Numbers
{
    public class Solution
    {
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            PriorityQueue<int, int> max = new PriorityQueue<int, int>();
            PriorityQueue<int, int> min = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            foreach (int i in nums)
            {
                if (max.Count < 3)
                {
                    max.Enqueue(i, i);
                }
                else if (max.Peek() < i)
                {
                    max.Dequeue();
                    max.Enqueue(i, i);
                }

                if (min.Count < 2)
                {
                    min.Enqueue(i, i);
                }
                else if (min.Peek() > i)
                {
                    min.Dequeue();
                    min.Enqueue(i, i);
                }
            }

            // Compare smallest * 2nd_smallest vs 2nd_largest * 3rd_largest
            int j = min.Dequeue() * min.Dequeue();
            int k = max.Dequeue() * max.Dequeue();
            return Math.Max(max.Peek() * j, max.Peek() * k);
        }
    }
}
