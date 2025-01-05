using System.Text;

namespace Shifting_Letters_II
{
    /*You are given a string s of lowercase English letters and a 2D integer array shifts where 
     * shifts[i] = [starti, endi, directioni]. For every i, shift the characters in s from the index starti to the index 
     * endi (inclusive) forward if directioni = 1, or shift the characters backward if directioni = 0.
    Shifting a character forward means replacing it with the next letter in the alphabet (wrapping around so that 'z' becomes 'a'). 
    Similarly, shifting a character backward means replacing it with the previous letter in the alphabet 
    (wrapping around so that 'a' becomes 'z').
    Return the final string after all such shifts to s are applied.
    
    Constraint:
    1 <= s.length, shifts.length <= 5 * 10^4
    shifts[i].length == 3
    0 <= starti <= endi < s.length
    0 <= directioni <= 1
    s consists of lowercase English letters.
     */

    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 50000;
        public static void Main()
        {
            string? s;
            do
            {
                Console.WriteLine($"Enter a non-empty string ({minLength} <= length <= {maxLength}):");
                s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) 
                { 
                    Console.WriteLine("The string cannot be null or whitespace. Please try again."); 
                }
                else if (s.Length < minLength || s.Length > maxLength) 
                { 
                    Console.WriteLine($"The string length must be between {minLength} and {maxLength}. Please try again."); 
                }
            } while (string.IsNullOrWhiteSpace(s) || s.Length < minLength || s.Length > maxLength);
            List<int[]>? shifts = null;
            while (shifts == null || !ValidateInput(s, shifts))
            {               
                Console.WriteLine("Enter the shifts (in format [[start1, end1, dir1], ...]):");
                string input = Console.ReadLine() ?? "";
                try
                {                    
                    shifts = System.Text.Json.JsonSerializer.Deserialize<List<int[]>>(input) ?? [];
                    if (!ValidateInput(s, shifts))
                    {
                        Console.WriteLine("Invalid shifts entered. Please try again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format. Please try again.");
                    shifts = null;
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Output string: " + ShiftingLetters(s, shifts));
            Console.ReadKey();
        }

        public static string ShiftingLetters(string s, List<int[]> shifts)
        {
            int n = s.Length;
            int[] shift = new int[n + 1];

            foreach (var shiftOp in shifts)
            {
                int start = shiftOp[0], end = shiftOp[1], direction = shiftOp[2];
                shift[start] += (direction == 1 ? 1 : -1);
                if (end + 1 < n) shift[end + 1] -= (direction == 1 ? 1 : -1);
            }

            int currentShift = 0;
            var result = new StringBuilder(s);
            for (int i = 0; i < n; ++i)
            {
                currentShift += shift[i];
                shift[i] = currentShift;
            }

            for (int i = 0; i < n; ++i)
            {
                int netShift = (shift[i] % 26 + 26) % 26;
                result[i] = (char)('a' + (s[i] - 'a' + netShift) % 26);
            }

            return result.ToString();
        }

        public static bool ValidateInput(string s, List<int[]> shifts)
        {
            // Check the length constraints of s and shifts
            //int minLength = 1;
            //int maxLength = 5 * (int)Math.Pow(10, 4);
            if (shifts.Count < minLength || shifts.Count > maxLength)
            {
                return false;
            }

            // Check each shift
            foreach (var shift in shifts)
            {
                if (shift.Length != 3)
                {
                    return false;
                }

                int start = shift[0];
                int end = shift[1];
                int direction = shift[2];

                // Validate each constraint for shift
                if (start < 0 || start >= s.Length || end < start || end >= s.Length || (direction != 0 && direction != 1))
                {
                    return false;
                }
            }

            return true;
        }
    }
}