namespace Count_and_Say
{
    /*The count-and-say sequence is a sequence of digit strings defined by the recursive formula:
    countAndSay(1) = "1"
    countAndSay(n) is the run-length encoding of countAndSay(n - 1).
    Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical 
    characters (repeated 2 or more times) with the concatenation of the character and the number marking 
    the count of the characters (length of the run). For example, to compress the string "3322251" 
    we replace "33" with "23", replace "222" with "32", replace "5" with "15" and replace "1" with "11". Thus the compressed 
    string becomes "23321511".Given a positive integer n, return the nth element of the count-and-say sequence.

    Constraint:
    1 <= n <= 30
    */
    using System;

    class Program
    {
        static string CountAndSay(int n)
        {
            string result = "1";

            for (int i = 1; i < n; i++)
            {
                string temp = "";
                int count = 1;

                for (int j = 0; j < result.Length; j++)
                {
                    if (j + 1 < result.Length && result[j] == result[j + 1])
                    {
                        count++;
                    }
                    else
                    {
                        temp += count.ToString() + result[j];
                        count = 1;
                    }
                }

                result = temp;
            }

            return result;
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a number between 1 and 30: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int n))
                {
                    if (n >= 1 && n <= 30)
                    {
                        Console.WriteLine("Result: " + CountAndSay(n));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: The number must be between 1 and 30.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
