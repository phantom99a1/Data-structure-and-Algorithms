namespace Find_the_Distance_Value_Between_Two_Arrays
{
    public class Solution
    {
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            Array.Sort(arr2);
            int distance = 0;

            foreach (int num in arr1)
            {
                int start = num - d;
                int end = num + d;

                if (!IsValid(arr2, start, end))
                {
                    distance++;
                }
            }

            return distance;
        }

        private bool IsValid(int[] arr, int start, int end)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] >= start && arr[mid] <= end)
                {
                    return true;
                }

                if (arr[mid] < start)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
    }
}
