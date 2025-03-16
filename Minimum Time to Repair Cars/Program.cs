namespace Minimum_Time_to_Repair_Cars
{
    /*You are given an integer array ranks representing the ranks of some mechanics. ranksi is the rank of the ith mechanic. 
     A mechanic with a rank r can repair n cars in r * n^2 minutes.
    You are also given an integer cars representing the total number of cars waiting in the garage to be repaired.
    Return the minimum time taken to repair all the cars.
    Note: All the mechanics can repair the cars simultaneously.

    Constraint:
    1 <= ranks.length <= 10^5
    1 <= ranks[i] <= 100
    1 <= cars <= 10^6
    */
    
    class Program
    {
        static bool CanRepairAllCars(int[] ranks, int cars, long time)
        {
            long carsRepaired = 0;
            foreach (int rank in ranks)
            {
                carsRepaired += (long)Math.Floor(Math.Sqrt((double)time / rank));
                if (carsRepaired >= cars) return true;
            }
            return false;
        }

        static long MinimumTime(int[] ranks, int cars)
        {
            long left = 1, right = (long)ranks.Max() * cars * cars, result = right;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;

                if (CanRepairAllCars(ranks, cars, mid))
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return result;
        }

        static void Main()
        {
            Console.WriteLine("Enter ranks (comma-separated): ");
            int[] ranks = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("Enter number of cars: ");
            if (!int.TryParse(Console.ReadLine(), out int cars))
            {
                Console.WriteLine("Invalid input: Please enter valid integers.");
                return;
            }

            if (ranks.Length < 1 || ranks.Length > 100000 || ranks.Any(rank => rank < 1 || rank > 100) ||
                cars < 1 || cars > 1000000)
            {
                Console.WriteLine("Invalid input: Please follow the constraints.");
            }
            else
            {
                Console.WriteLine("Minimum Time to Repair All Cars: " + MinimumTime(ranks, cars));
            }
        }
    }

}
