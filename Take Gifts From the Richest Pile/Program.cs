namespace Take_Gifts_From_the_Richest_Pile
{
    /*You are given an integer array gifts denoting the number of gifts in various piles. Every second, you do the following:

    Choose the pile with the maximum number of gifts.
    If there is more than one pile with the maximum number of gifts, choose any.
    Leave behind the floor of the square root of the number of gifts in the pile. Take the rest of the gifts.
    Return the number of gifts remaining after k seconds.*/
    public class Program
    {
        public static void Main()
        {
            long[] gifts = ParseArrayInput("Enter the numbers in the array (comma-separated): ");
            int k = ParseNumberInput("Enter the number of operations (k): ");
            long result = TakeGifts(gifts, k);
            Console.WriteLine($"The total number of gifts taken after {k} operations is: {result}");
            Console.ReadKey();
        }

        public static long[] ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input;
            do
            {
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    Console.ReadKey();
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input.Split(',').Select(long.Parse).ToArray();
        }

        public static int ParseNumberInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input;
            int number;
            do
            {
                input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out number) || number <= 0)
                {
                    Console.WriteLine("Input must be a valid positive number. Please try again.");
                }
            } while (!int.TryParse(input, out number) || number <= 0);
            return number;
        }

        public static long TakeGifts(long[] gifts, int k)
        {
            for (int i = 0; i < k; ++i)
            {
                long maxGifts = 0;
                var pileIndex = 0;
                for (int j = 0; j < gifts.Length; ++j)
                {
                    if (maxGifts < gifts[j])
                    {
                        maxGifts = gifts[j];
                        pileIndex = j;
                    }
                }

                gifts[pileIndex] = (int)Math.Sqrt(gifts[pileIndex]);
            }

            long remaining = 0;
            for (int i = 0; i < gifts.Length; ++i)
            {
                remaining += gifts[i];
            }

            return remaining;
        }
    }

}
