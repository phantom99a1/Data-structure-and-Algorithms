namespace Max_Chunks_To_Make_Sorted
{
    /*You are given an integer array arr of length n that represents a permutation of the integers in the range [0, n - 1].
    We split arr into some number of chunks (i.e., partitions), and individually sort each chunk. 
    After concatenating them, the result should equal the sorted array.
    Return the largest number of chunks we can make to sort the array.
    
    Constraints:

    n == arr.length
    1 <= n <= 10
    0 <= arr[i] < n
    All the elements of arr are unique.
     */
    public class Program
    {
        public static void Main()
        {
            int[]? arr = null;

            // Read and validate the input array
            while (true)
            {
                Console.Write("Enter the array elements as space-separated integers: ");
                var input = Console.ReadLine() ?? "";

                try
                {
                    arr = input.Split(' ').Select(int.Parse).ToArray();
                    if (arr.Length > 0 && arr.Length <= 10 && arr.All(x => x >= 0 && x < arr.Length))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a list of space-separated integers between 0 and n-1.");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a list of space-separated integers.");
                    Console.ReadKey();
                }
            }

            // Calculate the result
            int result = MaxChunksToSorted(arr);
            Console.WriteLine("Max Chunks To Make Sorted: " + result);
            Console.ReadKey();
        }

        public static int MaxChunksToSorted(int[] arr)
        {
            int maxChunks = 0;
            int maxSeen = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                maxSeen = Math.Max(maxSeen, arr[i]);
                if (maxSeen == i)
                {
                    maxChunks++;
                }
            }

            return maxChunks;
        }
    }
}
