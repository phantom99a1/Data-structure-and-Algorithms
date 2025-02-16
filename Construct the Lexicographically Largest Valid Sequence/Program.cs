namespace Construct_the_Lexicographically_Largest_Valid_Sequence
{
    /*Given an integer n, find a sequence that satisfies all of the following:
    The integer 1 occurs once in the sequence.
    Each integer between 2 and n occurs twice in the sequence.
    For every integer i between 2 and n, the distance between the two occurrences of i is exactly i.
    The distance between two numbers on the sequence, a[i] and a[j], is the absolute difference of their indices, |j - i|.
    Return the lexicographically largest sequence. It is guaranteed that under the given constraints, there is always a solution.
    A sequence a is lexicographically larger than a sequence b (of the same length) if in the first position where a and b differ, 
    sequence a has a number greater than the corresponding number in b. For example, [0,1,9,0] is lexicographically larger 
    than [0,1,5,6] because the first position they differ is at the third number, and 9 is greater than 5.
    
    Constraint:
    1 <= n <= 20
     */
    
    public class LexicographicallyLargestSequence
    {
        private const int minValue = 1;
        private const int maxValue = 20;
        public static void Main()
        {
            int n;
            while (true)
            {
                Console.WriteLine("Enter a value for n:");
                if (int.TryParse(Console.ReadLine(), out n) && n >= minValue && n <= maxValue)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
                }
            }

            int[] result = ConstructDistancedSequence(n);

            Console.WriteLine($"Lexicographically Largest Valid Sequence: [{string.Join(", ", result)}]");
            Console.ReadKey();
        }

        public static int[] ConstructDistancedSequence(int n)
        {
            int[] result = new int[2 * n - 1]; // Initialize the result array
            bool[] used = new bool[n + 1]; // To track used numbers
            Backtrack(result, used, n, 0);
            return result;
        }

        private static bool Backtrack(int[] result, bool[] used, int n, int index)
        {
            if (index == result.Length)
            {
                return true; // Successfully filled the sequence
            }

            if (result[index] != 0)
            {
                return Backtrack(result, used, n, index + 1); // Skip if already filled
            }

            // Try to place numbers from n down to 1
            for (int num = n; num >= 1; num--)
            {
                if (!used[num])
                {
                    // Check if we can place num at index
                    if (num == 1)
                    {
                        result[index] = num;
                        used[num] = true;
                    }
                    else
                    {
                        int nextIndex = index + num; // The position for the second occurrence
                        if (nextIndex < result.Length && result[nextIndex] == 0)
                        {
                            // Place the number
                            result[index] = num;
                            result[nextIndex] = num;
                            used[num] = true;
                        }
                        else
                        {
                            continue; // Skip if cannot place the second occurrence
                        }
                    }

                    // Recur to fill the next position
                    if (Backtrack(result, used, n, index + 1))
                    {
                        return true; // Found a valid sequence
                    }

                    // Backtrack
                    result[index] = 0;
                    if (num == 1)
                    {
                        used[num] = false;
                    }
                    else
                    {
                        int nextIndex = index + num;
                        result[nextIndex] = 0;
                        used[num] = false;
                    }
                }
            }

            return false; // No valid placement found
        }
    }
}
