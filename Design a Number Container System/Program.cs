using Design_a_Number_Container_System;

namespace Design_a_Number_Container_System
{
    /*Design a number container system that can do the following:
    Insert or Replace a number at the given index in the system.
    Return the smallest index for the given number in the system.
    Implement the NumberContainers class:
    NumberContainers() Initializes the number container system.
    void change(int index, int number) Fills the container at index with the number. 
    If there is already a number at that index, replace it.
    int find(int number) Returns the smallest index for the given number, or -1 
    if there is no index that is filled by number in the system.
    
     Constraint:
    1 <= index, number <= maxValue
    At most 10^5 calls will be made in total to change and find.
     */
    
    public class NumberContainers
    {
        private readonly Dictionary<int, HashSet<int>> numMap;
        private readonly Dictionary<int, int> numMapCache;
        private readonly Dictionary<int, int> idxMap;
        private int callCount;

        private const int minValue = 1;
        private const int maxValue = 1000000000;
        private const int maxValueCallCount = 100000;
        public NumberContainers()
        {
            numMap = [];
            numMapCache = [];
            idxMap = [];
        }

        public void Change(int index, int number)
        {
            if (index < minValue || index > maxValue || number < minValue || number > maxValue)
            {
                Console.WriteLine($"Invalid input: index and number must be between {minValue} and {maxValue}");
                return;
            }
            if (callCount >= maxValueCallCount)
            {
                Console.WriteLine("Maximum number of calls reached.");
                return;
            }
            callCount++;
            if (idxMap.TryGetValue(index, out int value_))
            {
                int oldNum = value_;
                if (oldNum == number) return;

                numMap[oldNum].Remove(index);
                if (numMap[oldNum].Count == 0)
                {
                    numMap.Remove(oldNum);
                }

                if (numMapCache.TryGetValue(oldNum, out int _oldNum) && _oldNum == index)
                {
                    numMapCache.Remove(oldNum);
                }
            }

            idxMap[index] = number;

            if (!numMap.TryGetValue(number, out HashSet<int>? value))
            {
                value = [];
                numMap[number] = value;
            }

            value.Add(index);

            if (numMapCache.TryGetValue(number, out int _value))
            {
                numMapCache[number] = Math.Min(index, _value);
            }
        }

        public int Find(int number)
        {
            if (number < minValue || number > maxValue)
            {
                Console.WriteLine($"Invalid input: number must be between {minValue} and {maxValue}");
                return -1;
            }
            if (callCount >= maxValueCallCount)
            {
                Console.WriteLine("Maximum number of calls reached.");
                return -1;
            }
            callCount++;
            if (!numMap.TryGetValue(number, out HashSet<int>? value) || value.Count == 0)
            {
                return -1;
            }

            if (numMapCache.TryGetValue(number, out int _numMapCache))
            {
                return _numMapCache;
            }

            SortedSet<int> sortedSet = new(value);
            int minIndex = sortedSet.Min;
            numMapCache[number] = minIndex;
            return minIndex;
        }
    }

}

public class Program
{
    public static void Main()
    {
        var nc = new NumberContainers();
        string command;
        do
        {
            Console.WriteLine("Enter a command (change/find/exit):");
            command = (Console.ReadLine() ?? "").Trim().ToLower();

            if (command == "change")
            {
                Console.WriteLine("Enter index and number (separated by space):");
                string[] input = (Console.ReadLine() ?? "").Split(' ');
                if (input.Length != 2 || !int.TryParse(input[0], out int index) || !int.TryParse(input[1], out int number))
                {
                    Console.WriteLine("Invalid input format. Please enter valid index and number.");
                    continue;
                }
                nc.Change(index, number);
            }
            else if (command == "find")
            {
                Console.WriteLine("Enter number:");
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                    continue;
                }
                int result = nc.Find(number);
                Console.WriteLine($"Find result: {result}");
            }
            else if (command != "exit")
            {
                Console.WriteLine("Invalid command. Please enter 'change', 'find', or 'exit'.");
            }
        } while (command != "exit");
    }
}
