namespace Counting_Words_With_a_Given_Prefix
{
    /*You are given an array of strings words and a string pref.
    Return the number of strings in words that contain pref as a prefix.
    A prefix of a string s is any leading contiguous substring of s.
    
    Constraint:
    1 <= words.length <= 100
    1 <= words[i].length, pref.length <= 100
    words[i] and pref consist of lowercase English letters.
     */    
    public class Program
    {
        private const int minArrayLength = 1;
        private const int maxArrayLength = 100;
        private const int minLength = 1;
        private const int maxLength = 100;
        public static void ValidInput(string[] words)
        {
            if (words.Length < minArrayLength || words.Length > maxArrayLength)
            {
                throw new ArgumentException($"words.length must be between {minArrayLength} and {maxArrayLength}");
            }
            foreach (string word in words)
            {
                if (word.Length < minLength || word.Length > maxLength)
                {
                    throw new ArgumentException($"Each word must be {minLength} to {maxLength}");
                }

                if (word.Any(c => !char.IsLower(c)))
                {
                    throw new ArgumentException("Each word must be lowercase English letters");
                }
            }
        }

        public static void ValidInput(string prefix)
        {
            if (prefix.Length < minLength || prefix.Length > maxLength)
            {
                throw new ArgumentException($"Each word must be {minLength} to {maxLength}");
            }

            if (prefix.Any(c => !char.IsLower(c)))
            {
                throw new ArgumentException("Each word must be lowercase English letters");
            }
        }
        public static void Main()
        {
            string[] words;
            string prefix;
            while (true)
            {
                Console.WriteLine("Enter the words (separated by spaces):");
                words = (Console.ReadLine() ?? "").Split(' ');
                try
                {
                    ValidInput(words);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }                
            }

            while (true)
            {
                Console.WriteLine("Enter the prefix:");
                prefix = Console.ReadLine() ?? "";

                try
                {
                    ValidInput(prefix);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }

            int count = words.Count(word => word.StartsWith(prefix));
            Console.WriteLine($"The number of words starts with {prefix}: {count}");
            Console.ReadKey(true);
        }
    }
}
