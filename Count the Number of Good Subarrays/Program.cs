namespace Count_the_Number_of_Good_Subarrays
{
    /*Given an integer array nums and an integer k, return the number of good subarrays of nums.
    A subarray arr is good if there are at least k pairs of indices (i, j) such that i < j and arr[i] == arr[j].
    A subarray is a contiguous non-empty sequence of elements within an array.
    
     Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i], k <= 10^9
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static long CountGood(int[] nums, int k)
        {
            long count = 0, cur = 0, left = 0;
            var freq = new Dictionary<int, int>();

            for (int right = 0; right < nums.Length; right++)
            {
                int num = nums[right];
                if (!freq.ContainsKey(num))
                    freq[num] = 0;
                freq[num]++;
                cur += freq[num] - 1;

                while (cur >= k)
                {
                    count += nums.Length - right;
                    int leftNum = nums[left];
                    freq[leftNum]--;
                    cur -= freq[leftNum];
                    left++;
                }
            }

            return count;
        }

        static void Main()
        {
            Console.WriteLine("Enter array elements separated by space:");
            var nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine("Enter k:");
            int k = int.Parse(Console.ReadLine());

            if (nums.Length < 1 || nums.Length > 100000 || k < 1 || k > 1000000000)
            {
                Console.WriteLine("Invalid input. Please adhere to constraints.");
                return;
            }

            long result = CountGood(nums, k);
            Console.WriteLine($"Number of good subarrays: {result}");
        }
    }
}
