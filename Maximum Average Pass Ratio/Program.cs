namespace Maximum_Average_Pass_Ratio
{
    /*There is a school that has classes of students and each class will be having a final exam. 
     * You are given a 2D integer array classes, where classes[i] = [passi, totali]. 
     * You know beforehand that in the ith class, there are totali total students, 
     * but only passi number of students will pass the exam.

    You are also given an integer extraStudents. There are another extraStudents brilliant students that are 
    guaranteed to pass the exam of any class they are assigned to. 
    You want to assign each of the extraStudents students to a class in a way that maximizes the average pass ratio across 
    all the classes.
    
    The pass ratio of a class is equal to the number of students of the class that will pass the exam divided 
    by the total number of students of the class. The average pass ratio is the sum of pass ratios of all the 
    classes divided by the number of the classes.

    Return the maximum possible average pass ratio after assigning the extraStudents students. 
    Answers within 10-5 of the actual answer will be accepted.
    Constraints:

    1 <= classes.length <= 10^5
    classes[i].length == 2
    1 <= passi <= totali <= 10^5
    1 <= extraStudents <= 10^5
    */
    public class Program
    {
        public static void Main()
        {
            // Read input from the keyboard
            Console.Write("Enter the number of classes: ");
            if (!int.TryParse(Console.ReadLine(), out int numClasses) || numClasses <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of classes.");
                Console.ReadKey();
                return;
            }

            var classes = new int[numClasses][];
            Console.WriteLine("Enter the classes (each class in the format \"pass/total\", separated by space): ");
            for (int i = 0; i < numClasses; i++)
            {
                var inputs = (Console.ReadLine() ?? "").Split('/').Select(int.Parse).ToArray();
                if (inputs.Length != 2 || inputs[0] < 0 || inputs[1] <= 0 || inputs[0] > inputs[1])
                {
                    Console.WriteLine("Invalid input. Please enter valid class data.");
                    Console.ReadKey();
                    return;
                }
                classes[i] = inputs;
            }

            Console.Write("Enter the number of extra students: ");
            if (!int.TryParse(Console.ReadLine(), out int extraStudents) || extraStudents < 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of extra students.");
                Console.ReadKey();
                return;
            }

            // Calculate and print the maximum average pass ratio
            double result = MaxAverageRatio(classes, extraStudents);
            Console.WriteLine("Maximum average pass ratio: {0:F5}", result);
            Console.ReadKey();
        }

        // Function to calculate the maximum average pass ratio
        public static double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var heap = new PriorityQueue<(int pass, int total), double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

            foreach (var cls in classes)
            {
                double delta = CalculateDelta(cls[0], cls[1]);
                heap.Enqueue((cls[0], cls[1]), delta);
            }

            while (extraStudents > 0)
            {
                var (pass, total) = heap.Dequeue();
                pass++;
                total++;
                heap.Enqueue((pass, total), CalculateDelta(pass, total));
                extraStudents--;
            }

            double totalRatio = 0;
            foreach (var (Element, Priority) in heap.UnorderedItems)
            {
                totalRatio += (double)Element.pass / Element.total;
            }

            return totalRatio / classes.Length;
        }

        private static double CalculateDelta(int pass, int total)
        {
            return (double)(pass + 1) / (total + 1) - (double)pass / total;
        }
    }
}
