namespace String_Matching_in_an_Array
{
    /*Given an array of string words, return all strings in words that is a substring of another word. 
     * You can return the answer in any order.
    A substring is a contiguous sequence of characters within a string
    
    Constraint:
    1 <= words.length <= 100
    1 <= words[i].length <= 30
    words[i] contains only lowercase English letters.
    All the strings of words are unique.
     */
    
    public class Program
    {
        public static void Main()
        {
            string[] words;

            while (true)
            {
                Console.WriteLine("Enter words separated by a space: ");
                string input = Console.ReadLine() ?? "";
                words = input.Split(' ');

                if (words.Length < 1 || words.Length > 100)
                {
                    Console.WriteLine("The number of words should be between 1 and 100.");
                    continue;
                }

                bool isValid = true;

                foreach (var word in words)
                {
                    if (word.Length < 1 || word.Length > 30 || !word.All(char.IsLower))
                    {
                        Console.WriteLine("Each word should be between 1 and 30 lowercase English letters.");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    break;
                }
            }

            var result = StringMatching(words);
            Console.WriteLine($"Matching words: [{string.Join(", ", result)}]");
            Console.ReadKey();
        }

        public static List<string> StringMatching(string[] words)
        {
            string allWords = string.Join("#", words);
            var result = new List<string>();

            foreach (var word in words)
            {
                if (allWords.IndexOf(word) != allWords.LastIndexOf(word))
                {
                    result.Add(word);
                }
            }

            return result;
        }
    }
}
