namespace Construct_String_With_Repeat_Limit
{
    /*You are given a string s and an integer repeatLimit. 
     * Construct a new string repeatLimitedString using the characters of s such that no letter appears more 
     * than repeatLimit times in a row. You do not have to use all characters from s.

    Return the lexicographically largest repeatLimitedString possible.

    A string a is lexicographically larger than a string b if in the first position where a and b differ, 
    string a has a letter that appears later in the alphabet than the corresponding letter in b. 
    If the first min(a.length, b.length) characters do not differ, then the longer string is the lexicographically larger one.
    
    Constraints:
    1 <= repeatLimit <= s.length <= 10^5
    s consists of lowercase English letters.
     */
    public class Program
    {
        public static void Main()
        {
            string? s;
            int repeatLimit;

            // Read and validate the input string
            while (true)
            {
                Console.Write("Enter the string: ");
                s = Console.ReadLine() ?? "";

                if (!string.IsNullOrEmpty(s) && s.Length <= Math.Pow(10,5) && s.All(char.IsLower))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-empty string and all lowercase English letter.");
                    Console.ReadKey();
                }
            }

            // Read and validate the repeat limit
            while (true)
            {
                Console.Write("Enter the repeat limit: ");
                var repeatLimitInput = Console.ReadLine();

                if (int.TryParse(repeatLimitInput, out repeatLimit) && repeatLimit > 0 && repeatLimit <= s.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer and is not greater than the length of string for the repeat limit.");
                    Console.ReadKey();
                }
            }

            // Construct and print the string with repeat limit
            string result = ConstructStringWithRepeatLimit(s, repeatLimit);
            Console.WriteLine($"Constructed string: {result}");
            Console.ReadKey();
        }

        // Function to construct the string with repeat limit
        public static string ConstructStringWithRepeatLimit(string s, int repeatLimit)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }

            var pq = new PriorityQueue<(char ch, int count), char>(Comparer<char>.Create((a, b) => b.CompareTo(a)));
            for (int i = 0; i < 26; i++)
            {
                if (freq[i] > 0)
                {
                    pq.Enqueue(((char ch, int count))('a' + i, freq[i]), (char)('a' + i));
                }
            }

            var result = new System.Text.StringBuilder();
            while (pq.Count > 0)
            {
                var (ch, count) = pq.Dequeue();
                int used = Math.Min(repeatLimit, count);
                result.Append(ch, used);
                count -= used;

                if (count > 0)
                {
                    if (pq.Count == 0) break;
                    var (nextCh, nextCount) = pq.Dequeue();
                    result.Append(nextCh);
                    nextCount--;

                    if (nextCount > 0) pq.Enqueue((nextCh, nextCount), nextCh);
                    pq.Enqueue((ch, count), ch);
                }
            }
            return result.ToString();
        }
    }
}
