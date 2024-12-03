namespace Adding_Spaces_to_a_String
{
    /*You are given a 0-indexed string s and a 0-indexed integer array spaces 
     * that describes the indices in the original string where spaces will be added. 
     * Each space should be inserted before the character at the given index.

    For example, given s = "EnjoyYourCoffee" and spaces = [5, 9], we place spaces before 'Y' and 'C', 
    which are at indices 5 and 9 respectively. Thus, we obtain "Enjoy Your Coffee".
    Return the modified string after the spaces have been added.*/
    public class Solution
    {
        public static string AddSpacesToString(string s, int[] spaces)
        {
            var result = new System.Text.StringBuilder();
            int spaceIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (spaceIndex < spaces.Length && i == spaces[spaceIndex])
                {
                    result.Append(' ');
                    spaceIndex++;
                }
                result.Append(s[i]);
            }
            return result.ToString();
        }

        public static void Main()
        {
            Console.WriteLine("Enter the string:");
            var s = Console.ReadLine();

            Console.WriteLine("Enter the indices separated by spaces:");
            var spacesInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(spacesInput))
            {
                Console.WriteLine("Invalid input. Please ensure the string and indices are non-empty.");
                return;
            }

            var spaces = spacesInput.Split(' ')
                                    .Select(x => int.TryParse(x, out int num) ? num : (int?)null)
                                    .ToArray();

            if (spaces.Any(x => !x.HasValue || x < 0 || x >= s.Length))
            {
                Console.WriteLine("Invalid input. Please enter valid indices within the bounds of the string.");
            }
            else
            {
                var result = AddSpacesToString(s, spaces.Select(x => x.Value).ToArray());
                Console.WriteLine("Resulting string: " + result);
            }
            Console.ReadKey();
        }
    }
}
