namespace Best_Sightseeing_Pair
{
    /*You are given an integer array values where values[i] represents the value of the ith sightseeing spot. 
     Two sightseeing spots i and j have a distance j - i between them.

    The score of a pair (i < j) of sightseeing spots is values[i] + values[j] + i - j: 
    the sum of the values of the sightseeing spots, minus the distance between them.

    Return the maximum score of a pair of sightseeing spots.
    
    Constraints:
    2 <= values.length <= 5 * 10^4
    1 <= values[i] <= 1000
     */
    
    public class Solution
    {
        public static int MaxScoreSightseeingPair(int[] values)
        {
            int maxScore = 0;
            int maxI = values[0] + 0; // values[i] + i

            for (int j = 1; j < values.Length; j++)
            {
                maxScore = Math.Max(maxScore, maxI + values[j] - j);
                maxI = Math.Max(maxI, values[j] + j);
            }

            return maxScore;
        }

        public static bool ValidateInput(int[] values)
        {
            if (values.Length < 2 || values.Length > 5 * 10000)
            {
                return false;
            }
            foreach (int val in values)
            {
                if (val < 1 || val > 1000)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the values (comma-separated):");
            string valuesInput = Console.ReadLine() ?? "";
            int[] values = valuesInput.Split(',').Select(int.Parse).ToArray();

            if (ValidateInput(values))
            {
                int result = MaxScoreSightseeingPair(values);
                Console.WriteLine("Maximum Score of Best Sightseeing Pair: " + result);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please follow the constraints.");
                Console.ReadKey();
            }
        }
    }

}
