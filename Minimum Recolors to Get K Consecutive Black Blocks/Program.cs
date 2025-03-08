namespace Minimum_Recolors_to_Get_K_Consecutive_Black_Blocks
{
    /*You are given a 0-indexed string blocks of length n, where blocks[i] is either 'W' or 'B', 
    representing the color of the ith block. The characters 'W' and 'B' denote the colors white and black, respectively.
    You are also given an integer k, which is the desired number of consecutive black blocks.
    In one operation, you can recolor a white block such that it becomes a black block.
    Return the minimum number of operations needed such that there is at least one occurrence of k consecutive black blocks.
    
    Constraint:
    n == blocks.length
    1 <= n <= 100
    blocks[i] is either 'W' or 'B'.
    1 <= k <= n
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100;
        private const int minValue = 1;
        public static int MinimumRecolors(string blocks, int k)
        {
            int currentRecolors = 0;

            for (int i = 0; i < k; i++)
            {
                if (blocks[i] == 'W') currentRecolors++;
            }
            int minRecolors = currentRecolors;

            for (int i = k; i < blocks.Length; i++)
            {
                if (blocks[i - k] == 'W') currentRecolors--;
                if (blocks[i] == 'W') currentRecolors++;
                minRecolors = Math.Min(minRecolors, currentRecolors);
            }
            return minRecolors;
        }

        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter the blocks string (W or B): ");
                string blocks = Console.ReadLine() ?? "";

                Console.Write("Enter the value of k: ");
                if (!int.TryParse(Console.ReadLine(), out int k))
                {
                    Console.WriteLine("Error: k must be an integer.");
                    continue;
                }

                var errors = ValidateInput(blocks, k);

                if (errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                    continue;
                }

                Console.WriteLine("Minimum recolors needed: " + MinimumRecolors(blocks, k));
                Console.ReadKey();
                break;
            }
        }

        public static List<string> ValidateInput(string blocks, int k)
        {
            var errors = new List<string>();
            int n = blocks.Length;

            if (n < 1 || n > 100) errors.Add("Error: n must satisfy 1 <= n <= 100.");
            if (k < 1 || k > n) errors.Add("Error: k must satisfy 1 <= k <= n.");
            foreach (char c in blocks)
            {
                if (c != 'W' && c != 'B')
                {
                    errors.Add("Error: blocks must contain only 'W' or 'B'.");
                    break;
                }
            }

            return errors;
        }
    }
}
