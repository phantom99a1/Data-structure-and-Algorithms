namespace Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box
{
    /*You have n boxes. You are given a binary string boxes of length n, 
     * where boxes[i] is '0' if the ith box is empty, and '1' if it contains one ball.
    In one operation, you can move one ball from a box to an adjacent box. Box i is adjacent to box j if abs(i - j) == 1. 
    Note that after doing so, there may be more than one ball in some boxes.
    Return an array answer of size n, where answer[i] is the minimum number of operations 
    needed to move all the balls to the ith box.
    Each answer[i] is calculated considering the initial state of the boxes.
    
    Constraint:
    n == boxes.length
    1 <= n <= 2000
    boxes[i] is either '0' or '1'.
     */
    public class Program
    {
        public static void Main()
        {
            string boxes = "";
            int minLength = 1;
            int maxLength = 2000;

            do
            {
                Console.Write("Enter the boxes string (e.g., 110): ");
                boxes = Console.ReadLine() ?? "";
                int n = boxes.Length;
                if (n < minLength || n > maxLength)
                {
                    Console.WriteLine($"The length must be between {minLength} and {maxLength}. Please enter again.");
                }
                if (boxes.Any(c => c != '0' && c != '1'))
                {
                    Console.WriteLine($"The boxes string is only contain 0 or 1. Please enter again.");
                }
            } while (boxes.Length < minLength || boxes.Length > maxLength || !boxes.All(c => c == '0' || c == '1'));                       

            var result = MinOperations(boxes);
            Console.WriteLine($"Minimum number of operations: [{string.Join(", ", result)}]");
            Console.ReadKey();
        }

        public static int[] MinOperations(string boxes)
        {
            int n = boxes.Length;
            int[] result = new int[n];
            int count = 0;
            int steps = 0;

            for (int i = 0; i < n; i++)
            {
                result[i] += steps;
                count += boxes[i] == '1' ? 1 : 0;
                steps += count;
            }

            count = 0;
            steps = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] += steps;
                count += boxes[i] == '1' ? 1 : 0;
                steps += count;
            }

            return result;
        }
    }
}