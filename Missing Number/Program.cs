namespace Missing_Number
{
    /*Given an array nums containing n distinct numbers in the range [0, n], 
    return the only number in the range that is missing from the array.
    
    Constraint:
    n == nums.length
    1 <= n <= 10^4
    0 <= nums[i] <= n
    All the numbers of nums are unique.*/
    
    public class MissingNumberFinder
    {
        private const int minLength = 1;
        private const int maxLength = 10000;
        private const int minValue = 0;
        public static void Main()
        {
            Console.Write("Enter the value of n: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || !IsValidN(n))
            {
                Console.Write($"Invalid value for n. Enter the value of n ({minLength} <= n <= {maxLength}): ");
            }

            int[] array;
            while (true)
            {
                Console.Write($"Enter {n} unique numbers between {minValue} and {n} separated by spaces: ");
                string input = Console.ReadLine() ?? "";
                string[] inputs = input.Split(' ');
                List<string> errors = ValidateInput(inputs, n, out array);

                if (errors.Count == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error}");
                    }
                }
            }

            Console.WriteLine($"Missing number: {FindMissingNumber(array)}");
            Console.ReadKey();
        }

        public static bool IsValidN(int n)
        {
            return n >= minLength && n <= maxLength;
        }

        public static List<string> ValidateInput(string[] inputs, int n, out int[] array)
        {
            var errors = new List<string>();
            array = new int[inputs.Length];

            if (inputs.Length != n)
            {
                errors.Add($"The number of inputs should be exactly {n}.");
            }

            bool allIntegers = true;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (!int.TryParse(inputs[i], out array[i]))
                {
                    errors.Add($"'{inputs[i]}' is not a valid integer.");
                    allIntegers = false;
                }
            }

            if (allIntegers)
            {
                var numSet = new HashSet<int>(array);
                if (numSet.Count != array.Length)
                {
                    errors.Add("All numbers must be unique.");
                }
                if (array.Any(num => num < 0 || num > n))
                {
                    errors.Add($"All numbers must be between 0 and {n}.");
                }
            }

            return errors;
        }

        public static int FindMissingNumber(int[] arr)
        {
            int n = arr.Length;
            int xorTotal = 0;
            int xorArray = 0;

            for (int i = 1; i <= n; i++)
            {
                xorTotal ^= i;
            }

            foreach (int num in arr)
            {
                xorArray ^= num;
            }

            return xorTotal ^ xorArray;
        }
    }
}
