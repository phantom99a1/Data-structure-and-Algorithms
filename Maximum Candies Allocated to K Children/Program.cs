namespace Maximum_Candies_Allocated_to_K_Children
{
    /*You are given a 0-indexed integer array candies. Each element in the array denotes a pile of candies of size candies[i]. 
     * You can divide each pile into any number of sub piles, but you cannot merge two piles together.
    You are also given an integer k. You should allocate piles of candies to k children such that each child gets the same 
    number of candies. Each child can be allocated candies from only one pile of candies and some piles of candies may go unused.
    Return the maximum number of candies each child can get.
    
    Constraint:
    1 <= candies.length <= 10^5
    1 <= candies[i] <= 10^7
    1 <= k <= 10^12
     */
    using System;
    using System.Linq;

    class Program
    {
        static bool IsValidInput(int[] candies, long k)
        {
            if (candies.Length < 1 || candies.Length > Math.Pow(10, 5))
            {
                Console.WriteLine("candies.Length must be between 1 and 10^5");
                return false;
            }
            if (candies.Any(c => c < 1 || c > Math.Pow(10, 7)))
            {
                Console.WriteLine("Each candies[i] must be between 1 and 10^7");
                return false;
            }
            if (k < 1 || k > Math.Pow(10, 12))
            {
                Console.WriteLine("k must be between 1 and 10^12");
                return false;
            }
            return true;
        }

        static int MaxCandies(int[] candies, long k)
        {
            int left = 1, right = candies.Max(), result = 0;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                long count = candies.Sum(c => c / mid);

                if (count >= k)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }

        static void Main()
        {
            Console.Write("Enter candies array (comma-separated): ");
            int[] candies = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            Console.Write("Enter number of children (k): ");
            long k = long.Parse(Console.ReadLine());

            if (IsValidInput(candies, k))
            {
                Console.WriteLine("Maximum candies per child: " + MaxCandies(candies, k));
            }
        }
    }

}
