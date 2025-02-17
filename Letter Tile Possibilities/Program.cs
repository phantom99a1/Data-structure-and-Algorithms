using System.Text.RegularExpressions;

namespace Letter_Tile_Possibilities
{
    /*You have n  tiles, where each tile has one letter tiles[i] printed on it.
    Return the number of possible non-empty sequences of letters you can make using the letters printed on those tiles.
    
    Constraint:
    1 <= tiles.length <= 7
    tiles consists of uppercase English letters.
     */
    
    public partial class Program
    {
        private const int minLength = 1;
        private const int maxLength = 7;
        public static bool ValidateInput(string tiles)
        {
            if (tiles.Length >= minLength && tiles.Length <= maxLength && MyRegex().IsMatch(tiles))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter {minLength} to {maxLength} uppercase English letters.");
                return false;
            }
        }

        public static void Backtrack(char[] tiles, string path, HashSet<string> result, bool[] used)
        {
            if (path.Length > 0)
            {
                result.Add(path);
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                if (used[i] || (i > 0 && tiles[i] == tiles[i - 1] && !used[i - 1]))
                {
                    continue;
                }
                used[i] = true;
                Backtrack(tiles, path + tiles[i], result, used);
                used[i] = false;
            }
        }

        public static int NumTilePossibilities(string tiles)
        {
            var result = new HashSet<string>();
            var used = new bool[tiles.Length];
            Array.Sort(tiles.ToCharArray());
            Backtrack(tiles.ToCharArray(), "", result, used);
            return result.Count;
        }

        public static void Main()
        {
            Console.Write("Enter tiles: ");
            string input = Console.ReadLine() ?? "";
            if (ValidateInput(input))
            {
                Console.WriteLine("Number of possible sequences: " + NumTilePossibilities(input));
                Console.ReadKey();
            }
        }

        [GeneratedRegex("^[A-Z]+$")]
        private static partial Regex MyRegex();
    }
}
