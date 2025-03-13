namespace Zero_Array_Transformation_II
{
    /*You are given an integer array nums of length n and a 2D array queries where queries[i] = [li, ri, vali].
    Each queries[i] represents the following action on nums:
    Decrement the value at each index in the range [li, ri] in nums by at most vali.
    The amount by which each value is decremented can be chosen independently for each index.
    A Zero Array is an array with all its elements equal to 0.
    Return the minimum possible non-negative value of k, such that after processing the first k queries in sequence, 
    nums becomes a Zero Array. If no such k exists, return -1.
    
    Constraint:
    1 <= nums.length <= 10^5
    0 <= nums[i] <= 5 * 10^5
    1 <= queries.length <= 10^5
    queries[i].length == 3
    0 <= li <= ri < nums.length
    1 <= vali <= 5
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            const int numsLengthMin = 1, numsLengthMax = 100000;
            const int numsValueMin = 0, numsValueMax = 500000;
            const int queriesLengthMin = 1, queriesLengthMax = 100000;
            const int valiMin = 1, valiMax = 5;

            // Read and validate nums array
            Console.Write("Enter the nums array (space-separated integers): ");
            var nums = Console.ReadLine()?.Split().Select(int.Parse).ToArray();
            var numsErrors = ValidateNums(nums, numsLengthMin, numsLengthMax, numsValueMin, numsValueMax);

            if (numsErrors.Count > 0)
            {
                Console.WriteLine("Errors:");
                foreach (var error in numsErrors)
                    Console.WriteLine("- " + error);
                return;
            }

            // Read and validate queries
            Console.WriteLine("Enter queries (one per line as 'li ri vali'; type 'END' to finish):");
            var queries = new List<int[]>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var query = input.Split().Select(int.Parse).ToArray();
                queries.Add(query);
            }

            var queriesErrors = ValidateQueries(queries, nums.Length, queriesLengthMin, queriesLengthMax, valiMin, valiMax);
            if (queriesErrors.Count > 0)
            {
                Console.WriteLine("Errors:");
                foreach (var error in queriesErrors)
                    Console.WriteLine("- " + error);
                return;
            }

            // Process queries and find result
            var result = MinZeroArray(nums, queries.ToArray());
            Console.WriteLine("Result: " + result);
        }

        static List<string> ValidateNums(int[] nums, int minLength, int maxLength, int minValue, int maxValue)
        {
            var errors = new List<string>();
            if (nums.Length < minLength || nums.Length > maxLength)
                errors.Add($"nums length must be between {minLength} and {maxLength}.");
            if (nums.Any(num => num < minValue || num > maxValue))
                errors.Add($"Each element in nums must be between {minValue} and {maxValue}.");
            return errors;
        }

        static List<string> ValidateQueries(List<int[]> queries, int numsLength, int minLength, int maxLength, int valiMin, int valiMax)
        {
            var errors = new List<string>();
            if (queries.Count < minLength || queries.Count > maxLength)
                errors.Add($"queries length must be between {minLength} and {maxLength}.");

            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                if (query[0] < 0 || query[0] > query[1] || query[1] >= numsLength)
                    errors.Add($"Query {i + 1}: li and ri must satisfy 0 <= li <= ri < nums.length.");
                if (query[2] < valiMin || query[2] > valiMax)
                    errors.Add($"Query {i + 1}: vali must be between {valiMin} and {valiMax}.");
            }
            return errors;
        }

        public static int MinZeroArray(int[] nums, int[][] queries)
        {
            int n = nums.Length;

            bool CanMakeZeroArray(int k)
            {
                int[] diff = new int[n + 1];
                for (int i = 0; i < k; i++)
                {
                    int left = queries[i][0], right = queries[i][1], val = queries[i][2];
                    diff[left] += val;
                    diff[right + 1] -= val;
                }
                int currVal = 0;
                for (int i = 0; i < n; i++)
                {
                    currVal += diff[i];
                    if (currVal < nums[i]) return false;
                }
                return true;
            }

            if (nums.All(x => x == 0)) return 0;
            int left = 1, right = queries.Length;
            if (!CanMakeZeroArray(right)) return -1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanMakeZeroArray(mid)) right = mid;
                else left = mid + 1;
            }
            return left;
        }
    }

}
