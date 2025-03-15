namespace House_Robber_IV
{
    /*There are several consecutive houses along a street, each of which has some money inside. There is also a robber, 
     * who wants to steal money from the homes, but he refuses to steal from adjacent homes.
    The capability of the robber is the maximum amount of money he steals from one house of all the houses he robbed.
    You are given an integer array nums representing how much money is stashed in each house. 
    More formally, the ith house from the left has nums[i] dollars.
    You are also given an integer k, representing the minimum number of houses the robber will steal from. 
    It is always possible to steal at least k houses.
    Return the minimum capability of the robber out of all the possible ways to steal at least k houses.*/

    /*Constraint:
     1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
    1 <= k <= (nums.length + 1)/2
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter numbers separated by spaces:");
                string numsInput = Console.ReadLine() ?? "";
                int[] nums = Array.ConvertAll(numsInput.Split(' '), int.Parse);

                Console.WriteLine("Enter k:");
                if (!int.TryParse(Console.ReadLine(), out int k))
                {
                    Console.WriteLine("k must be a valid integer.");
                    continue;
                }

                List<string> errors = ValidateInput(nums, k);

                if (errors.Count != 0)
                {
                    Console.WriteLine("Input Errors:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
                else
                {
                    Console.WriteLine("Valid input!");
                    Console.WriteLine($"The result: {MinCapability(nums, k)}");
                    Console.ReadKey();
                    break; // Exit the loop for valid input
                }
            }
        }

        static List<string> ValidateInput(int[] nums, int k)
        {
            List<string> errors = new List<string>();

            if (nums.Length < 1 || nums.Length > Math.Pow(10, 5))
            {
                errors.Add("nums.length must be between 1 and 10^5.");
            }
            if (nums.Any(num => num < 1 || num > Math.Pow(10, 9)))
            {
                errors.Add("Each nums[i] must be between 1 and 10^9.");
            }
            if (k < 1 || k > (nums.Length + 1) / 2)
            {
                errors.Add("k must be between 1 and (nums.length + 1) / 2.");
            }

            return errors;
        }

        static int MinCapability(int[] nums, int k)
        {
            int left = int.MaxValue, right = int.MinValue;

            foreach (var num in nums)
            {
                left = Math.Min(left, num);
                right = Math.Max(right, num);
            }

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanRob(nums, k, mid))
                {
                    right = mid; // Try a lower capability
                }
                else
                {
                    left = mid + 1; // Increase the capability
                }
            }

            return left;
        }

        static bool CanRob(int[] nums, int k, int capability)
        {
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= capability)
                {
                    count++;
                    i++; // Skip the next house
                }
            }

            return count >= k;
        }
    }    
}
