namespace Count_Total_Number_of_Colored_Cells
{
    /*There exists an infinitely large two-dimensional grid of uncolored unit cells. You are given a positive integer n, 
    indicating that you must do the following routine for n minutes:
    At the first minute, color any arbitrary unit cell blue.
    Every minute thereafter, color blue every uncolored cell that touches a blue cell.
    Below is a pictorial representation of the state of the grid after minutes 1, 2, and 3.
    
    Constraint:
    1 <= n <= 10^5
     */
    public class Program
    {
        private const int minValue = 1;
        private const int maxValue = 100000;
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter a number: ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int n) && n >= minValue && n <= maxValue)
                {
                    Console.WriteLine($"Total Colored Cells: {CountColoredCells(n)}");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter an integer between {minValue} and {maxValue}.");
                }
            }
        }
        public static long CountColoredCells(int n)
        {
            // Hypothetical formula for colored cells:
            // Total cells = 2 * n * (n - 1) + 1 (adjust based on problem specifics)
            return 2L * n * (n - 1) + 1;
        }
    }
}
