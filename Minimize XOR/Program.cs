namespace Minimize_XOR
{
    /*Given two positive integers num1 and num2, find the positive integer x such that:
    x has the same number of set bits as num2, and
    The value x XOR num1 is minimal.
    Note that XOR is the bitwise XOR operation.
    Return the integer x. The test cases are generated such that x is uniquely determined.
    The number of set bits of an integer is the number of 1's in its binary representation.
    
    Constraint:
    1 <= num1, num2 <= 10^9
     */
   
    public class Program
    {
        private const int minValue = 1;
        private const int maxValue = 1000000000;
        public static void Main()
        {
            int num1;
            int num2;

            do
            {
                Console.Write("Enter num1: ");
                string num1Input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(num1Input))
                {
                    Console.WriteLine("Invalid input: Input must be non-empty.");
                    continue;
                }

                if (!int.TryParse(num1Input, out num1) || num1 < minValue || num1 > maxValue)
                {
                    Console.WriteLine($"Invalid input: num1 must be an integer between {minValue} and {maxValue}.");
                    continue;
                }

                break;
            } while (true);

            do
            {
                Console.Write("Enter num2: ");
                string num2Input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(num2Input))
                {
                    Console.WriteLine("Invalid input: Input must be non-empty.");
                    continue;
                }

                if (!int.TryParse(num2Input, out num2) || num2 < minValue || num2 > maxValue)
                {
                    Console.WriteLine($"Invalid input: num2 must be an integer between {minValue} and {maxValue}.");
                    continue;
                }

                break;
            } while (true);

            Console.WriteLine("Minimized XOR: " + MinimizeXOR(num1, num2));
            Console.ReadKey();
        }

        public static int MinimizeXOR(int num1, int num2)
        {
            static int countBits(int num) => Convert.ToString(num, 2).Count(c => c == '1');

            int bits1 = countBits(num1);
            int bits2 = countBits(num2);

            int result = 0;
            // Set bits from the most significant bit of num1
            for (int i = 31; i >= 0 && bits2 > 0; i--)
            {
                if ((num1 & (1 << i)) != 0)
                {
                    result |= 1 << i;
                    bits2--;
                }
            }

            // If bits2 is not zero, set the remaining bits from the least significant bit
            for (int i = 0; i <= 31 && bits2 > 0; i++)
            {
                if ((result & (1 << i)) == 0)
                {
                    result |= 1 << i;
                    bits2--;
                }
            }

            return result;
        }
    }
}
