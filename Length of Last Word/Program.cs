namespace Length_of_Last_Word
{
    /*Given a string s consisting of words and spaces, return the length of the last word in the string.
    A word is a maximal substring consisting of non-space characters only.
    
     Constraint:
    1 <= s.length <= 10^4
    s consists of only English letters and spaces ' '.
    There will be at least one word in s.
     */

    public class LastWordLengthFinder
    {
        private const int minLength = 1;
        private const int maxLength = 10000;
        public static void Main()
        {
            string input;
            while (true)
            {
                Console.Write("Enter a string: ");
                input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input:");
                    foreach(var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                }
            }

            int lastWordLength = FindLengthOfLastWord(input);
            Console.WriteLine($"Length of the last word: {lastWordLength}");
            Console.ReadKey();
        }

        public static bool IsValidInput(string s, out List<string> errorMessages)
        {
            errorMessages = [];
            if (s.Length < minLength || s.Length > maxLength)
            {
                errorMessages.Add($"The length of the string must be between {minLength} and {maxLength} characters.");
            }

            if(s.Any(c => !char.IsLetter(c) && c != ' '))
            {
                errorMessages.Add("The string must consist of only English letters and spaces.");
            }            

            return errorMessages.Count == 0;
        }

        public static int FindLengthOfLastWord(string s)
        {
            s = s.Trim();
            var array = s.Split(' ');
            return array[^1].Length;
        }
    }
}
