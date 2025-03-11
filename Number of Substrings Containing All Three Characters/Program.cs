namespace Number_of_Substrings_Containing_All_Three_Characters
{
    /*Given a string s consisting only of characters a, b and c.
    Return the number of substrings containing at least one occurrence of all these characters a, b and c.
    
    Constraint:
    3 <= s.length <= 5 x 10^4
    s only consists of a, b or c characters.
     */
    
    public class Program
    {
        private const int minLength = 3;
        private const int maxLength = 50000;
        public static bool ValidateInput(string s)
        {
            if (s.Length < minLength || s.Length > maxLength)
            {
                Console.WriteLine($"Error: String length must be between {minLength} and {maxLength}.");
                return false;
            }
            foreach (char c in s)
            {
                if (c != 'a' && c != 'b' && c != 'c')
                {
                    Console.WriteLine("Error: String must only contain characters 'a', 'b', or 'c'.");
                    return false;
                }
            }
            return true;
        }

        public static int CountSubstrings(string s)
        {
            int count = 0;
            Dictionary<char, int> freq = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 } };
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                freq[s[right]]++;
                while (freq['a'] > 0 && freq['b'] > 0 && freq['c'] > 0)
                {
                    count += s.Length - right;
                    freq[s[left]]--;
                    left++;
                }
            }
            return count;
        }

        public static void Main()
        {
            while (true)
            {
                Console.Write("Enter a valid string (only 'a', 'b', 'c'): ");
                string input = Console.ReadLine() ?? "";
                if (ValidateInput(input))
                {
                    Console.WriteLine("Number of substrings containing all three characters: " + CountSubstrings(input));
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
