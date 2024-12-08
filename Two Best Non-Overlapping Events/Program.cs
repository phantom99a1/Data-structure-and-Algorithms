namespace Two_Best_Non_Overlapping_Events
{
    /*You are given a 0-indexed 2D integer array of events where events[i] = [startTimei, endTimei, valuei]. 
     * The ith event starts at startTimei and ends at endTimei, and if you attend this event, 
     * you will receive a value of valuei. You can choose at most two non-overlapping events to attend such 
     * that the sum of their values is maximized.

    Return this maximum sum.

    Note that the start time and end time is inclusive: that is, you cannot attend two events 
    where one of them starts and the other ends at the same time. More specifically, 
    if you attend an event with end time t, the next event must start at or after t + 1.*/
    public class Program
    {
        public static void Main()
        {
            try
            {
                var events = ParseArrayInput("Enter the events (start,end,value) separated by semicolons: ");
                int result = MaxTwoEvents(events);
                Console.WriteLine($"The maximum sum of the values of two non-overlapping events is: {result}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static List<int[]> ParseArrayInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            return input.Split(';').Select(eventString =>
            {
                var parts = eventString.Split(',').Select(int.Parse).ToArray();
                if (parts.Length != 3)
                {
                    throw new Exception("Invalid input format. Each event must have exactly three numeric values separated by commas.");
                }
                return parts;
            }).ToList();
        }

        public static int MaxTwoEvents(List<int[]> events)
        {
            events = [.. events.OrderBy(e => e[0])]; // Sort by start time
            var maxHeap = new SortedSet<(int end, int value)>();
            int maxSum = 0;
            int bestSingleEvent = 0;

            foreach (var e in events)
            {
                int start = e[0], end = e[1], value = e[2];
                // Remove events that end before the current event starts
                while (maxHeap.Count > 0 && maxHeap.Min.end < start)
                {
                    var top = maxHeap.Min;
                    bestSingleEvent = Math.Max(bestSingleEvent, top.value);
                    maxHeap.Remove(top);
                }
                // Update the max sum of two non-overlapping events
                maxSum = Math.Max(maxSum, bestSingleEvent + value);
                // Insert the current event into the heap
                maxHeap.Add((end, value));
            }

            return maxSum;
        }
    }
}
