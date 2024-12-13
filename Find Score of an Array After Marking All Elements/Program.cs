namespace Find_Score_of_an_Array_After_Marking_All_Elements
{
    /*You are given an array nums consisting of positive integers.

    Starting with score = 0, apply the following algorithm:

    Choose the smallest integer of the array that is not marked. If there is a tie, choose the one with the smallest index.
    Add the value of the chosen integer to score.
    Mark the chosen element and its two adjacent elements if they exist.
    Repeat until all the array elements are marked.
    Return the score you get after applying the above algorithm.*/
    public class Program
    {
        public static void Main()
        {
            // Read input from the keyboard
            Console.Write("Enter the array of integers (space separated): ");
            string input = Console.ReadLine() ?? "";
            List<long> arr;

            // Validate input
            try
            {
                arr = input.Split(' ').Select(long.Parse).ToList();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid array of positive integers.");
                Console.ReadKey();
                return;
            }

            if (arr.Count == 0 || arr.Any(x => x <= 0))
            {
                Console.WriteLine("Invalid input. Please enter a valid array of positive integers.");
                Console.ReadKey();
                return;
            }

            // Calculate and print the score of the array
            long score = FindScore(arr);
            Console.WriteLine("Score of the array: " + score);
            Console.ReadKey();
        }

        // Function to find the score of the array
        public static long FindScore(List<long> arr)
        {
            long score = 0;
            bool[] marked = new bool[arr.Count];

            // Create a list of tuples with value and index
            var indexedArr = arr.Select((value, index) => new { value, index }).ToList();

            // Sort the list based on value
            indexedArr = [.. indexedArr.OrderBy(x => x.value)];

            foreach (var element in indexedArr)
            {
                if (!marked[element.index])
                {
                    // Add the value to the score
                    score += element.value;
                    marked[element.index] = true;
                    // Mark left and right neighbors
                    if (element.index > 0) marked[element.index - 1] = true;
                    if (element.index < arr.Count - 1) marked[element.index + 1] = true;
                }
            }

            return score;
        }
    }
}
