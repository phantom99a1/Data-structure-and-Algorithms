namespace Count_Good_Triplets
{
    /*Given an array of integers arr, and three integers a, b and c. You need to find the number of good triplets.
    A triplet (arr[i], arr[j], arr[k]) is good if the following conditions are true:
    0 <= i < j < k < arr.length
    |arr[i] - arr[j]| <= a
    |arr[j] - arr[k]| <= b
    |arr[i] - arr[k]| <= c
    Where |x| denotes the absolute value of x.
    Return the number of good triplets.
    
     Constraint:
    3 <= arr.length <= 100
    0 <= arr[i] <= 1000
    0 <= a, b, c <= 1000
     */
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an array (comma-separated numbers):");
            string inputArr = Console.ReadLine();
            Console.WriteLine("Enter a, b, c (comma-separated):");
            string inputParams = Console.ReadLine();

            int[] arr = inputArr.Split(',').Select(int.Parse).ToArray();
            int[] paramsArr = inputParams.Split(',').Select(int.Parse).ToArray();

            int a = paramsArr[0], b = paramsArr[1], c = paramsArr[2];

            if (IsValid(arr, a, b, c))
            {
                Console.WriteLine("Good Triplets Count: " + CountGoodTriplets(arr, a, b, c));
            }
            else
            {
                Console.WriteLine("Invalid input. Ensure constraints are met.");
            }
        }

        static bool IsValid(int[] arr, int a, int b, int c)
        {
            return arr.Length >= 3 && arr.Length <= 100 &&
                   arr.All(num => num >= 0 && num <= 1000) &&
                   a >= 0 && a <= 1000 && b >= 0 && b <= 1000 && c >= 0 && c <= 1000;
        }

        static int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a &&
                            Math.Abs(arr[j] - arr[k]) <= b &&
                            Math.Abs(arr[i] - arr[k]) <= c)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
