namespace Reverse_Integer
{
    /*Given a signed 32-bit integer x, return x with its digits reversed. 
     * If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
    
    Constraint:
    -2^31 <= x <= 2^31 - 1
     */
    
    public class Solution
    {
        private const int MIN_INT = int.MinValue;
        private const int MAX_INT = int.MaxValue;
        public static void Main()
        {
            int x;
            List<string> errors;

            do
            {
                (x, errors) = GetValidInput("Enter an integer: ");
                if (errors.Count > 0)
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            } while (errors.Count > 0);

            int result = ReverseInteger(x);
            Console.WriteLine("Reversed integer: " + result);
            Console.ReadKey();
        }

        public static (int, List<string>) GetValidInput(string prompt)
        {
            var errors = new List<string>();
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int x))
            {
                errors.Add("Input must be a integer number.");
            }
            else
            {
                if (x < MIN_INT || x > MAX_INT)
                {
                    errors.Add($"Input must be between {MIN_INT} and {MAX_INT}.");
                }
            }

            return (x, errors);
        }

        public static int ReverseInteger(int x)
        {
            if (x == int.MinValue)
            {
                return 0;
            }

            int sign = Math.Sign(x);
            char[] charArray = Math.Abs(x).ToString().ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new(charArray);
            long reversedNumber = sign * long.Parse(reversedString);

            if (reversedNumber < MIN_INT || reversedNumber > MAX_INT)
            {
                return 0;
            }
            return (int)reversedNumber;
        }
    }
}
