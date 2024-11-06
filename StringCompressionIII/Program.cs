namespace StringCompressionIII
{
    //Given a string word, compress it 
    //using the following algorithm: Begin with an empty string comp.
    //While word is not empty, use the following operation: Remove a maximum length prefix of word made of a single character c repeating at most 9 times.
    //Append the length of the prefix followed by c to comp.
    //Return the string comp

    public class Solution
    {
        public static string Compress(string word)
        {
            string comp = ""; int i = 0;
            while (i < word.Length)
            {
                char c = word[i]; int count = 0; // Count up to 9 occurrences of the same character
                while (i < word.Length && word[i] == c && count < 9) { 
                    count++; 
                    i++; 
                } 
                // Append the count and character to the result
                comp += count.ToString() + c; 
            } 
            return comp;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the string word:");
            string word = Console.ReadLine() ?? "";
            if(string.IsNullOrEmpty(word))
            {
                Console.WriteLine("The word isn't null or empty!");
                Console.ReadKey(true);
                return;
            }
            string compressed = Solution.Compress(word);
            Console.WriteLine(compressed);
            Console.ReadKey();
        }
    }
}
