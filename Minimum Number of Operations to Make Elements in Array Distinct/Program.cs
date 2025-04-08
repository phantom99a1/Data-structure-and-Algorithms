namespace Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct
{
    /*You are given an integer array nums. You need to ensure that the elements in the array are distinct. 
    To achieve this, you can perform the following operation any number of times:
    Remove 3 elements from the beginning of the array. If the array has fewer than 3 elements, remove all remaining elements.
    Note that an empty array is considered to have distinct elements. 
    Return the minimum number of operations needed to make the elements in the array distinct.
    
     Constraint:
    1 <= nums.length <= 100
    1 <= nums[i] <= 100 
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System;
    using System.Collections.Generic;

    class Program
    {
        static int CalculateOperations(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (seen.Contains(nums[i]))
                {
                    return (i / 3) + 1;
                }
                seen.Add(nums[i]);
            }

            return 0; // Default if no duplicate is found
        }

        static void Main()
        {
            Console.WriteLine("Enter the array elements separated by space:");
            string input = Console.ReadLine();
            int[] nums = Array.ConvertAll(input.Split(' '), int.Parse);

            int result = CalculateOperations(nums);
            Console.WriteLine($"Result: {result}");
        }
    }
}
