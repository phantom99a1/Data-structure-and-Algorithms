namespace Push_Dominoes
{
    /**/

    public class Solution
    {
        public string PushDominoes(string dominoes)
        {
            int n = dominoes.Length;
            int[] forces = new int[n];

            // Apply forces from the right
            int force = 0;
            for (int i = 0; i < n; i++)
            {
                if (dominoes[i] == 'R') force = n;
                else if (dominoes[i] == 'L') force = 0;
                else force = Math.Max(force - 1, 0);
                forces[i] += force;
            }

            // Apply forces from the left
            force = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dominoes[i] == 'L') force = n;
                else if (dominoes[i] == 'R') force = 0;
                else force = Math.Max(force - 1, 0);
                forces[i] -= force;
            }

            // Determine final result
            char[] result = new char[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = forces[i] > 0 ? 'R' : forces[i] < 0 ? 'L' : '.';
            }

            return new string(result);
        }
    }

    // Example usage
    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            Console.WriteLine(sol.PushDominoes(".L.R...LR..L..")); // Output: "LL.RR.LLRRLL.."
        }
    }
}
