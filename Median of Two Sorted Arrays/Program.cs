namespace Median_of_Two_Sorted_Arrays
{
    /*Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    The overall run time complexity should be O(log (m+n)).

    Constraint:
    nums1.length == m
    nums2.length == n
    0 <= m <= 1000
    0 <= n <= 1000
    1 <= m + n <= 2000
    -10^6 <= nums1[i], nums2[i] <= 10^6
     */
    
    public class Solution
    {
        public static void Main()
        {
            Console.WriteLine("Enter the first sorted array (comma-separated):");
            var inputNums1 = Console.ReadLine() ?? "";
            if (!ValidateInput(inputNums1))
            {
                Console.WriteLine("Input nums1 is invalid! Please enter the integer number and non-empty input!");
                Console.ReadKey();
                return;
            }
            int[] nums1 = inputNums1.Split(',').Select(int.Parse).ToArray();

            Console.WriteLine("Enter the second sorted array (comma-separated):");
            var inputNums2 = Console.ReadLine() ?? "";
            if (!ValidateInput(inputNums2))
            {
                Console.WriteLine("Input nums2 is invalid! Please enter the integer number and non-empty input!");
                Console.ReadKey();
                return;
            }
            int[] nums2 = inputNums2.Split(',').Select(int.Parse).ToArray();

            if(!ValidateInput(nums1, nums2, out string errorMessage))
            {
                Console.WriteLine(errorMessage);
                Console.ReadKey();
                return;
            }

            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
            Console.ReadKey();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                (nums2, nums1) = (nums1, nums2);
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int imin = 0, imax = m, halfLen = (m + n + 1) / 2;

            while (imin <= imax)
            {
                int i = (imin + imax) / 2;
                int j = halfLen - i;

                if (i < m && nums1[i] < nums2[j - 1])
                {
                    imin = i + 1;
                }
                else if (i > 0 && nums1[i - 1] > nums2[j])
                {
                    imax = i - 1;
                }
                else
                {
                    int maxOfLeft;
                    if (i == 0) { maxOfLeft = nums2[j - 1]; }
                    else if (j == 0) { maxOfLeft = nums1[i - 1]; }
                    else { maxOfLeft = Math.Max(nums1[i - 1], nums2[j - 1]); }

                    if ((m + n) % 2 == 1)
                    {
                        return maxOfLeft;
                    }

                    int minOfRight;
                    if (i == m) { minOfRight = nums2[j]; }
                    else if (j == n) { minOfRight = nums1[i]; }
                    else { minOfRight = Math.Min(nums1[i], nums2[j]); }

                    return (maxOfLeft + minOfRight) / 2.0;
                }
            }

            return 0.0;
        }

        private static bool ValidateInput(string input)
        {
            if(string.IsNullOrWhiteSpace(input)) 
                return false;
            var array = input.Split(',');
            if (array.Any(x => !int.TryParse(x.ToString(), out _)))
                return false;
            return true;
        }

        private static bool ValidateInput(int[] nums1, int[] nums2, out string errorMessage)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int minLength = 0;
            int maxLength = 1000;
            int maxMergeLength = 2000;
            int maxValue = 1000000;
            int minValue = -1000000;
            if (m < minLength || m > maxLength || n < minLength || n > maxLength || m + n < 1 || m + n > maxMergeLength)
            {                
                errorMessage = "Input arrays lengths are out of bounds.";
                return false;
            }

            if(nums1.Any(num => num < minValue || num > maxValue) || nums2.Any(num => num < minValue || num > maxValue))
            {
                errorMessage = "Array elements are out of bounds.";
                return false;
            }

            errorMessage = "";
            return true;
        }
    }
}