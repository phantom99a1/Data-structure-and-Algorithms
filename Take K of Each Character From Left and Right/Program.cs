namespace Take_K_of_Each_Character_From_Left_and_Right
{
    /*You are given a string s consisting of the characters 'a', 'b', and 'c' and a non-negative integer k. 
     * Each minute, you may take either the leftmost character of s, or the rightmost character of s.

    Return the minimum number of minutes needed for you to take at least k of each character, 
    or return -1 if it is not possible to take k of each character.
     */
    public class Program
    {
        public static int TakeCharacters(string s, int k)
        {
            int[] count = new int[3];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            if (count[0] < k || count[1] < k || count[2] < k)
            {
                return -1;
            }

            int requiredA = count[0] - k;
            int requiredB = count[1] - k;
            int requiredC = count[2] - k;

            int[] windowCount = new int[3];
            int left = 0, maxMiddleLength = 0;
            for (int right = 0; right < s.Length; right++)
            {
                windowCount[s[right] - 'a']++;

                while (windowCount[0] > requiredA || windowCount[1] > requiredB || windowCount[2] > requiredC)
                {
                    windowCount[s[left] - 'a']--;
                    left++;
                }
                maxMiddleLength = Math.Max(maxMiddleLength, right - left + 1);
            }
            return s.Length - maxMiddleLength;
        }
        public static void Main()
        {
            Console.Write("Please enter the string: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The string isn't empty!");
                Console.ReadKey();
                return;
            }
            input ??= "";
            Console.WriteLine("Please enter the target: ");
            var targetString = Console.ReadLine();
            if (string.IsNullOrEmpty(targetString))
            {
                Console.WriteLine("The target isn't empty!");
                Console.ReadKey();
                return;
            }

            if (!int.TryParse(targetString, out _))
            {
                Console.WriteLine("The target is invalid!");
                Console.ReadKey();
                return;
            }
            var target = int.Parse(targetString);
            var result = TakeCharacters(input, target);
            Console.WriteLine("The minimum number of minutes needed to take at least {0} of each character is: {1}",target, result);
            Console.ReadKey();
        }
    }
}
