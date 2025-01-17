namespace Neighboring_Bitwise_XOR
{
    /*A 0-indexed array derived with length n is derived by computing the bitwise XOR (⊕) of 
    adjacent values in a binary array original of length n.
    Specifically, for each index i in the range [0, n - 1]:
    If i = n - 1, then derived[i] = original[i] ⊕ original[0].
    Otherwise, derived[i] = original[i] ⊕ original[i + 1].
    Given an array derived, your task is to determine whether there exists a valid binary 
    array original that could have formed derived.
    Return true if such an array exists or false otherwise.
    A binary array is an array containing only 0's and 1's
    
    Constraint:
    n == derived.length
    1 <= n <= 10^5
    The values in derived are either 0's or 1's
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        public static void Main()
        {
            int[] derived = GetValidInput("Enter the array derived (comma-separated): ");
            bool doesValidArrayExist = DoesValidArrayExist(derived);
            Console.WriteLine("Can form original array: " + doesValidArrayExist);
            Console.ReadKey();
        }

        public static bool IsValidInput(string input, out List<string> errorMessages)
        {
            errorMessages = [];

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessages.Add("Input cannot be empty.");
                return false;
            }

            string[] parts = input.Split(',').Select(p => p.Trim()).ToArray();
            if (parts.Length < minLength || parts.Length > maxLength)
            {
                errorMessages.Add($"The length of the array must be between {minLength} and {maxLength}.");
            }

            var parsedNumbers = parts.Select(p => int.TryParse(p, out int num) ? (num == 0 || num == 1 ? num : (int?)null) : null).ToArray();

            if(parsedNumbers.Any(value => !value.HasValue || (value != 0 && value != 1)))
            {
                errorMessages.Add("All element of the array must be 0 or 1");
            }

            return errorMessages.Count == 0;
        }

        public static int[] GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (IsValidInput(input, out List<string> errorMessages))
                {
                    return input.Split(',').Select(int.Parse).ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine($"- {errorMessage}");
                    }
                }
            }
        }

        public static bool DoesValidArrayExist(int[] derived)
        {
            int n = derived.Length;
            int xorSum = 0;

            for (int i = 0; i < n; i++)
            {
                xorSum ^= derived[i];
            }

            return xorSum == 0;
        }
    }
}
