namespace Longest_Nice_Subarray
{
    /*You are given an array nums consisting of positive integers.
    We call a subarray of nums nice if the bitwise AND of every pair of elements that are in 
    different positions in the subarray is equal to 0.
    Return the length of the longest nice subarray.
    A subarray is a contiguous part of an array.
    Note that subarrays of length 1 are always considered nice.
    
    Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int LongestNiceSubarray(int[] nums)
        {
            int maxLength = 0, start = 0, bitmask = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                while ((bitmask & nums[end]) != 0)
                {
                    bitmask ^= nums[start++];
                }
                bitmask |= nums[end];
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            return maxLength;
        }

        static int[] GetValidInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter array elements separated by spaces:");
                    string input = Console.ReadLine();
                    string[] inputStrings = input.Split(' ');
                    List<int> nums = new List<int>();

                    foreach (string str in inputStrings)
                    {
                        if (int.TryParse(str, out int num))
                        {
                            if (num < 1 || num > (int)Math.Pow(10, 9))
                            {
                                throw new Exception("Each element must be in the range 1 <= nums[i] <= 10^9.");
                            }
                            nums.Add(num);
                        }
                        else
                        {
                            throw new Exception("Invalid number format.");
                        }
                    }

                    if (nums.Count < 1 || nums.Count > (int)Math.Pow(10, 5))
                    {
                        throw new Exception("Array length must be in the range 1 <= nums.length <= 10^5.");
                    }

                    return nums.ToArray();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input Error: " + e.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] nums = GetValidInput();
            Console.WriteLine("Longest Nice Subarray Length: " + LongestNiceSubarray(nums));
        }
    }

}
