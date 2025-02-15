namespace Find_the_Punishment_Number_of_an_Integer
{
    /*Given a positive integer n, return the punishment number of n.
    The punishment number of n is defined as the sum of the squares of all integers i such that:
    1 <= i <= n
    The decimal representation of i * i can be partitioned into contiguous substrings 
    such that the sum of the integer values of these substrings equals i.
    
    Constraint:
    1 <= n <= 1000
     */
    
    public class Solution
    {
        private const int minValue = 1;
        private const int maxValue = 1000;
        public static int PunishmentNumber(int n)
        {
            int punishmentNumber = 0;
            for (int i = 1; i <= n; i++)
            {
                string squareStr = (i * i).ToString();
                if (CanPartition(squareStr, i))
                {
                    punishmentNumber += i * i;
                }
            }
            return punishmentNumber;
        }

        private static bool CanPartition(string numStr, int target)
        {
            return Dfs(numStr, 0, target);
        }

        private static bool Dfs(string numStr, int index, int remaining)
        {
            if (index == numStr.Length)
            {
                return remaining == 0;
            }
            int num = 0;
            for (int i = index; i < numStr.Length; i++)
            {
                num = num * 10 + (numStr[i] - '0');
                if (num > remaining) break;
                if (Dfs(numStr, i + 1, remaining - num)) return true;
            }
            return false;
        }

        public static void Main()
        {
            int n;
            while (true)
            {
                Console.Write("Enter an integer: ");
                string input = Console.ReadLine() ?? "";
                string errorMessage = ValidateInput(input, out n);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }

            int punishmentNumber = PunishmentNumber(n);
            Console.WriteLine($"The Punishment Number is: {punishmentNumber}");
            Console.ReadKey();
        }

        public static string ValidateInput(string input, out int number)
        {
            if (!int.TryParse(input, out number))
            {
                return "Input is not a valid number.";
            }
            if (number < minValue || number > maxValue)
            {
                return $"Input must be an integer between {minValue} and {maxValue}.";
            }
            return string.Empty;
        }
    }
}
