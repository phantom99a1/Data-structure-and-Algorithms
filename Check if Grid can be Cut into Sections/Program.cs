namespace Check_if_Grid_can_be_Cut_into_Sections
{
    /*You are given an integer n representing the dimensions of an n x n grid, with the origin at the bottom-left corner of the grid.
     You are also given a 2D array of coordinates rectangles, where rectangles[i] is in the form [startx, starty, endx, endy], 
    representing a rectangle on the grid. Each rectangle is defined as follows:
    (startx, starty): The bottom-left corner of the rectangle.
    (endx, endy): The top-right corner of the rectangle.
    Note that the rectangles do not overlap. Your task is to determine if it is possible to make either two horizontal or two vertical
    cuts on the grid such that:
    Each of the three resulting sections formed by the cuts contains at least one rectangle.
    Every rectangle belongs to exactly one section.
    Return true if such cuts can be made; otherwise, return false.
    
    Constraint:
    3 <= n <= 10^9
    3 <= rectangles.length <= 10^5
    0 <= rectangles[i][0] < rectangles[i][2] <= n
    0 <= rectangles[i][1] < rectangles[i][3] <= n
    No two rectangles overlap.
     */
    using System;
    using System.Collections.Generic;

    class GridSectionValidation
    {
        public static List<string> ValidateInput(long n, List<int[]> rectangles)
        {
            List<string> errors = new List<string>();

            // Validate n
            if (n < 3 || n > 1_000_000_000)
            {
                errors.Add("Grid size (n) must satisfy 3 <= n <= 10^9.");
            }

            // Validate rectangles
            if (rectangles.Count < 3 || rectangles.Count > 100_000)
            {
                errors.Add("Number of rectangles must satisfy 3 <= rectangles.length <= 10^5.");
            }

            for (int i = 0; i < rectangles.Count; i++)
            {
                int[] rect = rectangles[i];
                int x1 = rect[0], y1 = rect[1], x2 = rect[2], y2 = rect[3];

                if (x1 < 0 || x2 > n || x1 >= x2)
                {
                    errors.Add($"Rectangle {i}: Invalid horizontal coordinates (0 <= x1 < x2 <= n).");
                }
                if (y1 < 0 || y2 > n || y1 >= y2)
                {
                    errors.Add($"Rectangle {i}: Invalid vertical coordinates (0 <= y1 < y2 <= n).");
                }
            }

            return errors;
        }

        public static void Main()
        {
            Console.Write("Enter grid size (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter number of rectangles: ");
            int count = int.Parse(Console.ReadLine());

            List<int[]> rectangles = new List<int[]>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter rectangle {i} (x1 y1 x2 y2): ");
                string[] input = Console.ReadLine().Split(' ');
                rectangles.Add(Array.ConvertAll(input, int.Parse));
            }

            List<string> errors = ValidateInput(n, rectangles);

            if (errors.Count > 0)
            {
                Console.WriteLine("Errors:");
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            else
            {
                Console.WriteLine("Valid input! Proceeding with further processing...");
                Console.WriteLine("The result: " + CheckValidCuts(n, [.. rectangles]));
                // Additional logic to check the grid sections can go here.
            }
        }
        public static bool CheckValidCuts(int n, int[][] rectangles)
        {
            var xIntervals = rectangles.Select(rect => new int[] { rect[0], rect[2] }).ToArray();
            var yIntervals = rectangles.Select(rect => new int[] { rect[1], rect[3] }).ToArray();

            return Check(xIntervals) || Check(yIntervals);
        }

        private static bool Check(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int sections = 0;
            int maxEnd = intervals[0][1];

            foreach (var interval in intervals)
            {
                if (maxEnd <= interval[0])
                {
                    sections++;
                }
                maxEnd = Math.Max(maxEnd, interval[1]);
            }

            return sections >= 2;
        }
    }
}
