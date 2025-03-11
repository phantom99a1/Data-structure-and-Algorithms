namespace Combination_Sum
{
    /*Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of 
     candidates where the chosen numbers sum to target. You may return the combinations in any order.
    The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of 
    at least one of the chosen numbers is different.
    The test cases are generated such that the number of unique combinations that sum up to target is less than 150 
    combinations for the given input.

    Constraint:
    1 <= candidates.length <= 30
    2 <= candidates[i] <= 40
    All elements of candidates are distinct.
    1 <= target <= 40
     */

    public class Program
    {
        public static int[]? ParseInput(string input)
        {
            try
            {
                int[] candidates = input.Split(' ').Select(int.Parse).ToArray();
                return candidates;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Input contains non-integer values.");
                return null;
            }
        }

        public static bool ValidateCandidates(int[] candidates)
        {
            if (candidates.Length < 1 || candidates.Length > 30)
            {
                Console.WriteLine("Error: Candidates array length must be between 1 and 30.");
                return false;
            }
            if (candidates.Any(num => num < 2 || num > 40))
            {
                Console.WriteLine("Error: Each candidate must be between 2 and 40.");
                return false;
            }
            if (candidates.Distinct().Count() != candidates.Length)
            {
                Console.WriteLine("Error: All candidates must be distinct.");
                return false;
            }
            return true;
        }
        public static bool ValidateTarget(int target)
        {
            if (target < 1 || target > 40)
            {
                Console.WriteLine("Error: Target must be between 1 and 40.");
                return false;
            }
            return true;
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Backtrack(candidates, target, 0, [], result);
            return result;
        }

        public static void Backtrack(int[] candidates, int target, int start, List<int> combination, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target) continue; // Skip if the number exceeds the target
                combination.Add(candidates[i]);
                Backtrack(candidates, target - candidates[i], i, combination, result); // Same index for reuse
                combination.RemoveAt(combination.Count - 1);
            }
        }

        public static void Main()
        {
            int[]? candidates;
            while (true)
            {
                Console.Write("Enter candidates array as space-separated integers: ");
                string input = Console.ReadLine() ?? "";
                candidates = ParseInput(input);
                if (candidates != null && ValidateCandidates(candidates))
                {
                    Console.WriteLine("Valid candidates array: " + string.Join(", ", candidates));
                    break;
                }
            }
            while (true)
            {
                Console.Write("Enter target value: ");
                if (int.TryParse(Console.ReadLine(), out int target) && ValidateTarget(target))
                {
                    var result = CombinationSum(candidates, target);
                    Console.WriteLine("Combinations:");
                    foreach (var combination in result)
                    {
                        Console.WriteLine(string.Join(", ", combination));
                    }
                    Console.ReadKey();
                    return; // Exit the program successfully
                }
            }
        }
    }    
}
