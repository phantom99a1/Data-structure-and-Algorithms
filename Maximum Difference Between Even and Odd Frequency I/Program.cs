namespace Maximum_Difference_Between_Even_and_Odd_Frequency_I
{
    /*You are given a string s consisting of lowercase English letters. Your task is to find the maximum difference 
    between the frequency of two characters in the string such that:
    One of the characters has an even frequency in the string.
    The other character has an odd frequency in the string.
    Return the maximum difference, calculated as the frequency of the character with an odd frequency minus the frequency 
    of the character with an even frequency.

    Constraint:
    3 <= s.length <= 100
    s consists only of lowercase English letters.
    s contains at least one character with an odd frequency and one with an even frequency.*/
    public class Solution
    {
        private const int
        public static int MaxDifferenceEvenOddFrequency(string s)
        {
            var frequency = new Dictionary<char, int>();

            // Count frequency of each character
            foreach (var c in s)
            {
                if (frequency.TryGetValue(c, out int value))
                {
                    frequency[c] = ++value;
                }
                else
                {
                    frequency[c] = 1;
                }
            }

            int maxDiff = int.MinValue;

            // Find the maximum difference
            foreach (var freq1 in frequency)
            {
                if (freq1.Value % 2 != 0)
                { // odd frequency
                    foreach (var freq2 in frequency)
                    {
                        if (freq2.Value % 2 == 0)
                        { // even frequency
                            maxDiff = Math.Max(maxDiff, freq1.Value - freq2.Value);
                        }
                    }
                }
            }

            // If no valid pairs found, return 0
            return maxDiff == int.MinValue ? 0 : maxDiff;
        }

        public static bool IsValidInput(string s)
        {
            if (s.Length < 3 || s.Length > 100) return false;
            if (!s.All(char.IsLower)) return false;

            var frequency = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (frequency.TryGetValue(c, out int value))
                {
                    frequency[c] = ++value;
                }
                else
                {
                    frequency[c] = 1;
                }
            }

            bool hasEven = frequency.Values.Any(freq => freq % 2 == 0);
            bool hasOdd = frequency.Values.Any(freq => freq % 2 != 0);

            return hasEven && hasOdd;
        }

        public static void PromptUserForValidInput()
        {
            Console.WriteLine("Enter a string: ");
            string s = Console.ReadLine() ?? "";

            if (IsValidInput(s))
            {
                Console.WriteLine("Maximum Difference: " + MaxDifferenceEvenOddFrequency(s));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please make sure that the input meets all the constraints.");
                PromptUserForValidInput();
            }
        }
    }    
}
