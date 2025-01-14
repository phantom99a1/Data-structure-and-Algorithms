namespace Find_the_Prefix_Common_Array_of_Two_Arrays
{
    /*You are given two 0-indexed integer permutations A and B of length n.
    A prefix common array of A and B is an array C such that C[i] is equal to the count of numbers that are present at or before the index i in both A and B.
    Return the prefix common array of A and B.
    A sequence of n integers is called a permutation if it contains all integers from 1 to n exactly once.
    
    Constraint:
    1 <= A.length == B.length == n <= 50
    1 <= A[i], B[i] <= n
    It is guaranteed that A and B are both a permutation of n integers.
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 50;
        public static void Main()
        {
            int[] A;
            int[] B;

            do
            {
                Console.Write("Enter the array A (separated by comma): ");
                string aInput = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(aInput))
                {
                    Console.WriteLine($"Invalid input: Input cannot be empty.");
                    continue;
                }
                string[] aParts = aInput.Split(',');
                if(aParts.Length == 0 || aParts.Any(part => !int.TryParse(part, out int _)))
                {
                    Console.WriteLine("Invalid input: Input must be a comma-separated list of numbers and all elements are integer.");
                    continue;
                }

                A = aParts.Select(int.Parse).ToArray();

                if (A.Length < minLength || A.Length > maxLength)
                {
                    Console.WriteLine($"Invalid input: The length of array A must be between {minLength} and {maxLength}.");
                    continue;
                }

                if (!A.All(num => num >= 1 && num <= A.Length) || A.Distinct().Count() != A.Length)
                {
                    Console.WriteLine($"Invalid input: A must be a permutation of 1 to {A.Length}.");
                    continue;
                }

                break;

            } while (true);

            do
            {
                Console.Write("Enter the array B (separated by comma): ");
                string bInput = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(bInput))
                {
                    Console.WriteLine($"Invalid input: Input cannot be empty.");
                    continue;
                }
                string[] bParts = bInput.Split(',');
                if (bParts.Length == 0 || bParts.Any(part => !int.TryParse(part, out int _)))
                {
                    Console.WriteLine("Invalid input: Input must be a comma-separated list of numbers and all elements are integer.");
                    continue;
                }
                B = bParts.Select(int.Parse).ToArray();

                if (B.Length != A.Length)
                {
                    Console.WriteLine("Invalid input: The length of array B must be the same as the length of array A.");
                    continue;
                }

                if (!B.All(num => num >= 1 && num <= B.Length) || B.Distinct().Count() != B.Length)
                {
                    Console.WriteLine($"Invalid input: B must be a permutation of 1 to {B.Length}.");
                    continue;
                }

                break;

            } while (true);

            Console.WriteLine($"Prefix Common Array: [{string.Join(", ", FindPrefixCommonArray(A, B))}]");
            Console.ReadKey();
        }

        public static int[] FindPrefixCommonArray(int[] A, int[] B)
        {
            int n = A.Length;
            int[] C = new int[n];
            var seenA = new HashSet<int>();
            var seenB = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                seenA.Add(A[i]);
                seenB.Add(B[i]);

                C[i] = seenA.Intersect(seenB).Count();
            }

            return C;
        }
    }
}
