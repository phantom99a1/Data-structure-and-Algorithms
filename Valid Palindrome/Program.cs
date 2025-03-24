namespace Valid_Palindrome
{
    /*A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing 
    all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
    Given a string s, return true if it is a palindrome, or false otherwise.
    
     Constraint:
    1 <= s.length <= 2 * 10^5
    s consists only of printable ASCII characters.*/
    
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine() ?? "";

                // Input validation
                if (!ValidateInput(input))
                {
                    Console.WriteLine("Please enter a valid string.");
                    continue;
                }

                // Check if the string is a palindrome
                Console.WriteLine("Is palindrome: " + IsPalindrome(input));
                Console.ReadKey();
                break;
            }
        }

        static bool ValidateInput(string s)
        {
            if (s.Length < 1 || s.Length > 200000)
            {
                Console.WriteLine("Error: Input length must be between 1 and 2 * 10^5.");
                return false;
            }

            if (!s.All(c => c >= 32 && c <= 126)) // ASCII printable range
            {
                Console.WriteLine("Error: Input must consist only of printable ASCII characters.");
                return false;
            }

            return true;
        }

        static bool IsPalindrome(string s)
        {
            // Clean the string by removing non-alphanumeric characters and converting to lowercase
            var cleaned = new string(s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray());
            int left = 0, right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
    }
}
