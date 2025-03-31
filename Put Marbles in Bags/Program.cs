namespace Put_Marbles_in_Bags
{
    /*You have k bags. You are given a 0-indexed integer array weights where weights[i] is the weight of the ith marble. 
     You are also given the integer k. Divide the marbles into the k bags according to the following rules:
    No bag is empty.If the ith marble and jth marble are in a bag, then all marbles with an index between the ith and jth 
    indices should also be in that same bag.If a bag consists of all the marbles with an index from i to j inclusively, 
    then the cost of the bag is weights[i] + weights[j].The score after distributing the marbles is the sum of the costs of 
    all the k bags.Return the difference between the maximum and minimum scores among marble distributions.
    
    Constraint:
    1 <= k <= weights.length <= 10^5
    1 <= weights[i] <= 10^9
     */
    using System;
    using System.Linq;

    class Program
    {
        static string IsValidInput(int k, int[] weights)
        {
            if (k < 1 || k > weights.Length)
            {
                return "Invalid k. Constraint: 1 <= k <= weights.Length";
            }
            if (weights.Length > 100000)
            {
                return "Invalid weights length. Constraint: weights.Length <= 10^5";
            }
            if (weights.Any(w => w < 1 || w > 1000000000))
            {
                return "Invalid weight. Constraint: 1 <= weights[i] <= 10^9";
            }
            return null;
        }

        public static int PutMarbles(int[] weights, int k)
        {
            int n = weights.Length - 1;
            int[] costs = new int[n];

            for (int i = 0; i < n; i++)
            {
                costs[i] = weights[i] + weights[i + 1];
            }

            Array.Sort(costs);

            int minScore = weights[0] + weights[weights.Length - 1];
            int maxScore = minScore;

            for (int i = 0; i < k - 1; i++)
            {
                minScore += costs[i];
                maxScore += costs[n - 1 - i];
            }

            return maxScore - minScore;
        }


        static void Main()
        {
            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Enter weights (comma-separated): ");
            int[] weights = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            string error = IsValidInput(k, weights);

            if (error != null)
            {
                Console.WriteLine("Error: " + error);
            }
            else
            {
                Console.WriteLine(PutMarbles(weights, k));
            }
        }
    }
}
