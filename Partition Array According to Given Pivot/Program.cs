namespace Partition_Array_According_to_Given_Pivot
{
    /*You are given a 0-indexed integer array nums and an integer pivot. 
     * Rearrange nums such that the following conditions are satisfied:
    Every element less than pivot appears before every element greater than pivot.
    Every element equal to pivot appears in between the elements less than and greater than pivot.
    The relative order of the elements less than pivot and the elements greater than pivot is maintained.
    More formally, consider every pi, pj where pi is the new position of the ith element and pj is the new position of the 
    jth element. If i < j and both elements are smaller (or larger) than pivot, then pi < pj.
    Return nums after the rearrangement.
    
    Constraint:
    1 <= nums.length <= 10^5
    -10^6 <= nums[i] <= 10^6
    pivot equals to an element of nums.
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        private const int minValue = -1000000;
        private const int maxValue = 1000000;
        public static int[] PivotArray(int[] nums, int pivot)
        {
            List<int> less = [];
            List<int> equal = [];
            List<int> greater = [];

            foreach (var num in nums)
            {
                if (num < pivot)
                {
                    less.Add(num);
                }
                else if (num == pivot)
                {
                    equal.Add(num);
                }
                else
                {
                    greater.Add(num);
                }
            }

            List<int> result = [.. less, .. equal, .. greater];

            return [.. result];
        }

        public static void Main()
        {
            int[]? nums = null;
            int pivot = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Enter the elements of the array separated by spaces:");
                    string input = Console.ReadLine() ?? "";
                    string[] inputArr = input.Split(' ');
                    nums = new int[inputArr.Length];

                    if (nums.Length < minLength || nums.Length > maxLength)
                    {
                        throw new Exception($"Array length must be between {minLength} and {maxLength}.");
                    }

                    for (int i = 0; i < inputArr.Length; i++)
                    {
                        nums[i] = int.Parse(inputArr[i]);
                        if (nums[i] < minValue || nums[i] > maxValue)
                        {
                            throw new Exception($"Array elements must be between {minValue} and {maxValue}.");
                        }
                    }
                    
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must contain only integers.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool validPivot = false;
            while (!validPivot)
            {
                try
                {
                    Console.WriteLine("Enter the pivot value:");
                    pivot = int.Parse(Console.ReadLine() ?? "");
                    if (!Array.Exists(nums!, element => element == pivot))
                    {
                        throw new Exception("Pivot value must be one of the elements in the array.");
                    }
                    validPivot = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Pivot value must be an integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int[] result = PivotArray(nums!, pivot);
            Console.WriteLine($"Pivoted array: [{string.Join(" ", result)}]");
            Console.ReadKey();
        }
    }

}
