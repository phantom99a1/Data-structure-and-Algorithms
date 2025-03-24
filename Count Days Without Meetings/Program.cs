namespace Count_Days_Without_Meetings
{
    /*You are given a positive integer days representing the total number of days an employee is available for work 
     * (starting from day 1). You are also given a 2D array meetings of size n where, meetings[i] = [start_i, end_i] 
     * represents the starting and ending days of meeting i (inclusive).
    Return the count of days when the employee is available for work but no meetings are scheduled.
    Note: The meetings may overlap.
    
     Constraint:
    1 <= days <= 10^9
    1 <= meetings.length <= 10^5
    meetings[i].length == 2
    1 <= meetings[i][0] <= meetings[i][1] <= days
    */
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static int CountDays(int days, int[][] meetings)
        {
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> mergedMeetings = new List<int[]>();
            foreach (var meeting in meetings)
            {
                if (mergedMeetings.Count == 0 || meeting[0] > mergedMeetings[^1][1])
                {
                    mergedMeetings.Add(meeting);
                }
                else
                {
                    mergedMeetings[^1][1] = Math.Max(mergedMeetings[^1][1], meeting[1]);
                }
            }

            int meetingDaysCount = 0;
            foreach (var m in mergedMeetings)
            {
                meetingDaysCount += (m[1] - m[0] + 1);
            }

            return days - meetingDaysCount;
        }
        static void Main()
        {
            Console.Write("Enter number of days: ");
            int days;
            if (!int.TryParse(Console.ReadLine(), out days) || days < 1 || days > 1_000_000_000)
            {
                Console.WriteLine("Error: 'days' must be between 1 and 10^9.");
                return;
            }

            Console.WriteLine("Enter meetings in the format 'start end', one per line. Type 'done' to finish:");
            var meetings = new List<Tuple<int, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "done") break;

                var parts = input.Split(' ').Select(int.Parse).ToArray();
                if (parts.Length != 2 || parts[0] < 1 || parts[1] > days || parts[0] > parts[1])
                {
                    Console.WriteLine($"Error: Invalid meeting range: {input}");
                    continue;
                }
                meetings.Add(new Tuple<int, int>(parts[0], parts[1]));
            }

            if (meetings.Count < 1 || meetings.Count > 100_000)
            {
                Console.WriteLine("Error: 'meetings' length must be between 1 and 10^5.");
                return;
            }
            var meetingArray = meetings.Select(tuple => new int[] { tuple.Item1, tuple.Item2 }).ToArray();
            Console.WriteLine("Days without meetings: " + CountDays(days, meetingArray));
            Console.ReadKey();
        }
    }
}
