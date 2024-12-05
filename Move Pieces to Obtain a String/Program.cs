namespace Move_Pieces_to_Obtain_a_String
{
    /*You are given two strings start and target, both of length n. 
     * Each string consists only of the characters 'L', 'R', and '_' where:

    The characters 'L' and 'R' represent pieces, where a piece 'L' can move to the left only 
    if there is a blank space directly to its left, and a piece 'R' can move to the right only 
    if there is a blank space directly to its right.
    The character '_' represents a blank space that can be occupied by any of the 'L' or 'R' pieces.
    Return true if it is possible to obtain the string target by moving the pieces of the string start any number of times. 
    Otherwise, return false.*/
    public class Solution
    {
        public static bool CanObtainTarget(string start, string target)
        {
            if (start.Length != target.Length) return false;

            int startPtr = 0, targetPtr = 0;

            while (startPtr < start.Length && targetPtr < target.Length)
            {
                while (startPtr < start.Length && start[startPtr] == '_') startPtr++;
                while (targetPtr < target.Length && target[targetPtr] == '_') targetPtr++;

                if (startPtr == start.Length || targetPtr == target.Length) break;

                if (start[startPtr] != target[targetPtr]) return false;

                if (start[startPtr] == 'L' && startPtr < targetPtr) return false;
                if (start[startPtr] == 'R' && startPtr > targetPtr) return false;

                startPtr++;
                targetPtr++;
            }

            while (startPtr < start.Length && start[startPtr] == '_') startPtr++;
            while (targetPtr < target.Length && target[targetPtr] == '_') targetPtr++;

            return startPtr == start.Length && targetPtr == target.Length;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the start string:");
            string start = Console.ReadLine()  ?? "";

            Console.WriteLine("Enter the target string:");
            string target = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(target))
            {
                Console.WriteLine("Invalid input. Both strings must be non-empty.");
                Console.ReadKey();
                return;
            }

            if (start.Length != target.Length)
            {
                Console.WriteLine("Invalid input. Both strings must be of the same length.");
                Console.ReadKey(true);
                return;
            }

            bool result = CanObtainTarget(start, target);
            Console.WriteLine(result ? "Yes, target can be obtained from start." : "No, target cannot be obtained from start.");
            Console.ReadKey();
        }
    }
}
