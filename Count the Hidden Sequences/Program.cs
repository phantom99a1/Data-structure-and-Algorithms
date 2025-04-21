namespace Count_the_Hidden_Sequences
{
    /*You are given a 0-indexed array of n integers differences, which describes the differences between each pair of 
    consecutive integers of a hidden sequence of length (n + 1). More formally, call the hidden sequence hidden, 
    then we have that differences[i] = hidden[i + 1] - hidden[i]. You are further given two integers lower and upper 
    that describe the inclusive range of values [lower, upper] that the hidden sequence can contain.
    For example, given differences = [1, -3, 4], lower = 1, upper = 6, the hidden sequence is a sequence of
    length 4 whose elements are in between 1 and 6 (inclusive).
    [3, 4, 1, 5] and [4, 5, 2, 6] are possible hidden sequences.
    [5, 6, 3, 7] is not possible since it contains an element greater than 6.
    [1, 2, 3, 4] is not possible since the differences are not correct.
    Return the number of possible hidden sequences there are. If there are no possible sequences, return 0.
    
     Constraint:
    n == differences.length
    1 <= n <= 10^5
    -10^5 <= differences[i] <= 10^5
    -10^5 <= lower <= upper <= 10^5
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public long NumberOfArrays(int[] differences, int lower, int upper)
        {
            long prefix = 0, min = 0, max = 0;
            foreach (var diff in differences)
            {
                prefix += diff;
                min = Math.Min(min, prefix);
                max = Math.Max(max, prefix);
            }
            return Math.Max(0, (upper - lower) - (max - min) + 1);
        }
    }
}
