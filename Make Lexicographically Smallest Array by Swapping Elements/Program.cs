namespace Make_Lexicographically_Smallest_Array_by_Swapping_Elements
{
    /*You are given a 0-indexed array of positive integers nums and a positive integer limit.
    In one operation, you can choose any two indices i and j and swap nums[i] and nums[j] if |nums[i] - nums[j]| <= limit.
    Return the lexicographically smallest array that can be obtained by performing the operation any number of times.
    An array a is lexicographically smaller than an array b if in the first position where a and b differ, 
    array a has an element that is less than the corresponding element in b. 
    For example, the array [2,10,3] is lexicographically smaller than the array [10,2,3] because they differ at index 0 and 2 < 10.
    
    Constraint:
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^9
    1 <= limit <= 10^9
     */

    public class Solution
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        private const int minValue = 1;
        private const int maxValue = 1000000000;
        public static int[] MakeLexicographicallySmallest(int[] nums, int limit)
        {
            int n = nums.Length;
            var parent = new int[n];
            var rank = new int[n];

            for (int i = 0; i < n; i++) parent[i] = i;

            int Find(int x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);
                return parent[x];
            }

            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);
                if (rootX != rootY)
                {
                    if (rank[rootX] > rank[rootY])
                    {
                        parent[rootY] = rootX;
                    }
                    else if (rank[rootX] < rank[rootY])
                    {
                        parent[rootX] = rootY;
                    }
                    else
                    {
                        parent[rootY] = rootX;
                        rank[rootX]++;
                    }
                }
            }

            // Create virtual graph by considering only consecutive elements after sorting
            var sortedIndices = Enumerable.Range(0, n).OrderBy(i => nums[i]).ToArray();
            for (int i = 0; i < n - 1; i++)
            {
                if (nums[sortedIndices[i + 1]] - nums[sortedIndices[i]] <= limit)
                {
                    Union(sortedIndices[i], sortedIndices[i + 1]);
                }
            }

            // Group elements by their root parent and sort each group
            var groups = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                int root = Find(i);
                if (!groups.ContainsKey(root))
                {
                    groups[root] = [];
                }
                groups[root].Add(i); // Store indices instead of values
            }

            // Create result array
            var result = new int[n];
            foreach (var group in groups.Values)
            {
                var values = group.Select(index => nums[index]).ToList();
                values.Sort();
                for (int i = 0; i < group.Count; i++)
                {
                    result[group[i]] = values[i];
                }
            }

            return result;
        }

        public static void Main()
        {
            int[] nums;
            int limit;
            List<string> errors;

            do
            {
                (nums, limit, errors) = GetValidInput("Enter the array and limit (array elements separated by ',', followed by ';' and the limit): ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            var result = MakeLexicographicallySmallest(nums, limit);
            Console.WriteLine("Lexicographically Smallest Array: [" + string.Join(",", result) + "]");
            Console.ReadKey();
        }

        public static (int[], int, List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(';');

            int[] nums = [];
            int limit = 0;

            try
            {
                nums = parts[0].Split(',').Select(int.Parse).ToArray();
                limit = int.Parse(parts[1]);
            }
            catch
            {
                errors.Add("Invalid integer value in input.");
                return (Array.Empty<int>(), 0, errors);
            }

            if (nums.Length < minLength || nums.Length > maxLength)
            {
                errors.Add($"Array length must be between {minLength} and {maxLength}.");
            }
            if (nums.Any(num => num < minValue || num > maxValue))
            {
                errors.Add($"Each element in nums must be between {minValue} and {maxValue}.");
            }
            if (limit < minValue || limit > maxValue)
            {
                errors.Add($"Limit must be between {minValue} and {maxValue}.");
            }

            return (nums, limit, errors);
        }
    }
}
