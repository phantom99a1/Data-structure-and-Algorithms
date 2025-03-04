namespace Check_if_Number_is_a_Sum_of_Powers_of_Three
{
    /*Given an integer n, return true if it is possible to represent n as the sum of distinct powers of three. 
    Otherwise, return false. An integer y is a power of three if there exists an integer x such that y == 3^x.
    
    Constraint:
    1 <= n <= 10^7
     */
    
    public class Program
    {
        private const int minValue = 1;
        private const int maxValue = 10000000;
        public static void Main()
        {
            Console.WriteLine("Enter a number:");
            bool isValidInput = false;
            int n = 0;

            while (!isValidInput)
            {
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out n))
                {
                    Console.WriteLine("Error: Input is not an integer. Please try again.");
                }
                else if (n < minValue || n > maxValue)
                {
                    Console.WriteLine("Error: Number is out of range. Please try again.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            Console.WriteLine($"Is {n} a sum of powers of three? {IsSumOfPowersOfThree(n)}");
            Console.ReadKey();
        }

        public static bool IsSumOfPowersOfThree(int n)
        {
            if (n <= 0) return false;
            while (n > 0)
            {
                if (n % 3 > 1) return false;
                n /= 3;
            }
            return true;
        }
    }
}
