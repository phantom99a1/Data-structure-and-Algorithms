namespace Alternating_Groups_II
{
    /*There is a circle of red and blue tiles. You are given an array of integers colors and an integer k. 
    The color of tile i is represented by colors[i]:
    colors[i] == 0 means that tile i is red.
    colors[i] == 1 means that tile i is blue.
    An alternating group is every k contiguous tiles in the circle with alternating colors (each tile in the group except the 
    first and last one has a different color from its left and right tiles).
    Return the number of alternating groups.
    Note that since colors represents a circle, the first and the last tiles are considered to be next to each other.
    
    Constraint:
    3 <= colors.length <= 10^5
    0 <= colors[i] <= 1
    3 <= k <= colors.length
     */
    using System;
    using System.Linq;

    public class AlternatingGroupsII
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter colors as comma-separated values and k (e.g., '0,1,0,1;3'):");
                string input = Console.ReadLine() ?? "";

                string[] parts = input.Split(';');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Error: Input must be in the format 'colors;k'.");
                    continue;
                }

                int[] colors = parts[0].Split(',').Select(int.Parse).ToArray();
                if (!int.TryParse(parts[1], out int k))
                {
                    Console.WriteLine("Error: k must be a valid integer.");
                    continue;
                }

                var errors = ValidateInput(colors, k);
                if (errors.Any())
                {
                    Console.WriteLine(string.Join("\n", errors));
                }
                else
                {
                    Console.WriteLine("Input is valid.");
                    int result = CountAlternatingGroups(colors, k);
                    Console.WriteLine($"Number of alternating groups: {result}");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public static string[] ValidateInput(int[] colors, int k)
        {
            var errors = new List<string>();
            if (colors.Length < 3 || colors.Length > 100000)
            {
                errors.Add("Error: colors.Length must be between 3 and 10^5.");
            }
            if (!colors.All(c => c == 0 || c == 1))
            {
                errors.Add("Error: All elements in colors must be 0 or 1.");
            }
            if (k < 3 || k > colors.Length)
            {
                errors.Add("Error: k must be between 3 and colors.Length.");
            }
            return [.. errors];
        }

        public static int CountAlternatingGroups(int[] colors, int k)
        {
            // Extend the circular array by duplicating the first (k - 1) elements
            int n = colors.Length;
            int[] extendedColors = new int[n + k - 1];
            Array.Copy(colors, extendedColors, n);
            Array.Copy(colors, 0, extendedColors, n, k - 1);

            int count = 0;
            int left = 0;

            // Sliding window approach
            for (int right = 0; right < extendedColors.Length; right++)
            {
                if (right > 0 && extendedColors[right] == extendedColors[right - 1])
                {
                    left = right; // Move the left pointer to the current position
                }

                if (right - left + 1 >= k)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
