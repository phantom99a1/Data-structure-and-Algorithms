namespace Minimum_Length_of_String_After_Operations
{
    /*You are given a string s.
    You can perform the following process on s any number of times:
    Choose an index i in the string such that there is at least one character to the left of index i that is equal to s[i], 
    and at least one character to the right that is also equal to s[i].
    Delete the closest character to the left of index i that is equal to s[i].
    Delete the closest character to the right of index i that is equal to s[i].
    Return the minimum length of the final string s that you can achieve.
    
    Constraint:
    1 <= s.length <= 2 * 10^5
    s consists only of lowercase English letters.
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 200000;
        public static void Main()
        {
            string s;
            do
            {
                Console.Write("Enter the string input: ");
                s = Console.ReadLine() ?? "";

                if (s.Length < minLength || s.Length > maxLength)
                {
                    Console.WriteLine($"Invalid input: The length of input must be between {minLength} and {maxLength}.");
                    continue;
                }

                if (!IsLowercaseLetters(s))
                {
                    Console.WriteLine("Invalid input: Input must consist only of lowercase English letters.");
                    continue;
                }

                break;
            } while (true);

            Console.WriteLine("Minimum length after operations: " + MinimumLengthAfterOperations(s));
            Console.ReadKey();
        }

        public static int MinimumLengthAfterOperations(string s)
        {
            var frequency = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }

            int minLength = 0;
            foreach (var count in frequency.Values)
            {
                if (count >= 3)
                {
                    minLength += (count % 2 == 0) ? 2 : 1;
                }
                else
                {
                    minLength += count;
                }
            }

            return minLength;
        }

        public static bool IsLowercaseLetters(string s)
        {
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
