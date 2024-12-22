namespace String_to_Integer__atoi_
{
    /*
    Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
    The algorithm for myAtoi(string s) is as follows:
    1. Whitespace: Ignore any leading whitespace (" ").
    2. Signedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.
    3. Conversion: Read the integer by skipping leading zeros until 
    a non-digit character is encountered or the end of the string is reached. If no digits were read, then the result is 0.
    4. Rounding: If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1], 
    then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.
    Return the integer as the final result.
    Constraints:
    0 <= s.length <= 200
    s consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.*/
    public class Solution
    {
        public static int MyAtoi(string s)
        {
            const int INT_MAX = 2147483647;
            const int INT_MIN = -2147483648;

            int i = 0;
            int n = s.Length;
            int result = 0;
            int sign = 1;

            // Skip leading whitespace
            while (i < n && s[i] == ' ')
            {
                i++;
            }

            // Check for optional sign
            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                sign = s[i] == '-' ? -1 : 1;
                i++;
            }

            // Convert digits to integer
            while (i < n && s[i] >= '0' && s[i] <= '9')
            {
                int digit = s[i] - '0';
                if (result > (INT_MAX - digit) / 10)
                {
                    return sign == 1 ? INT_MAX : INT_MIN;
                }
                result = result * 10 + digit;
                i++;
            }

            return result * sign;
        }

        public static bool ValidateInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length <= 200;
        }

        public static void Main()
        {
            Console.Write("Enter a string to convert to an integer: ");
            string input = Console.ReadLine() ?? "";

            if (ValidateInput(input))
            {
                int result = MyAtoi(input);
                Console.WriteLine($"Converted integer: {result}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid string.");
                Console.ReadKey();
            }
        }
    }
}
