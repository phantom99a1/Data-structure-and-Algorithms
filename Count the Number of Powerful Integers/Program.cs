namespace Count_the_Number_of_Powerful_Integers
{
    /*You are given three integers start, finish, and limit. You are also given a 0-indexed string s representing 
    a positive integer.A positive integer x is called powerful if it ends with s (in other words, s is a suffix of x) 
    and each digit in x is at most limit.Return the total number of powerful integers in the range [start..finish].
    A string x is a suffix of a string y if and only if x is a substring of y that starts from some index (including 0) 
    in y and extends to the index y.length - 1. For example, 25 is a suffix of 5125 whereas 512 is not.
    
     Constraint:
    1 <= start <= finish <= 10^15
    1 <= limit <= 9
    1 <= s.length <= floor(log10(finish)) + 1
    s only consists of numeric digits which are at most limit.
    s does not have leading zeros.
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static bool IsValidInput(long start, long finish, int limit, string s)
        {
            if (!(1 <= start && start <= finish && finish <= (long)Math.Pow(10, 15)))
            {
                Console.WriteLine("Invalid range. Ensure 1 <= start <= finish <= 10^15.");
                return false;
            }
            if (!(1 <= limit && limit <= 9))
            {
                Console.WriteLine("Invalid limit. Ensure 1 <= limit <= 9.");
                return false;
            }
            if (!(1 <= s.Length && s.Length <= Math.Floor(Math.Log10(finish) + 1)))
            {
                Console.WriteLine("Invalid string length. Ensure 1 <= s.length <= floor(log10(finish)) + 1.");
                return false;
            }
            if (!long.TryParse(s, out _) || s.StartsWith('0') || s.Any(c => int.Parse(c.ToString()) > limit))
            {
                Console.WriteLine("Invalid string. Ensure s consists of numeric digits <= limit and has no leading zeros.");
                return false;
            }
            return true;
        }

        public static long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            string startStr = (start - 1).ToString();
            string finishStr = finish.ToString();
            return Calculate(finishStr, s, limit) - Calculate(startStr, s, limit);
        }
        private static long Calculate(string x, string s, int limit)
        {
            if (x.Length < s.Length)
                return 0;

            if (x.Length == s.Length)
                return String.Compare(x, s) >= 0 ? 1 : 0;

            // Ensure all digits in suffix s are <= limit
            foreach (char c in s)
            {
                if (c - '0' > limit)
                    return 0;
            }

            long count = 0;
            int prefixLen = x.Length - s.Length;
            bool tight = true;

            for (int i = 0; i < prefixLen; i++)
            {
                int maxDigit = tight ? (x[i] - '0') : limit;

                for (int d = 0; d < maxDigit && d <= limit; d++)
                {
                    count += (long)Math.Pow(limit + 1, prefixLen - 1 - i);
                }

                if ((x[i] - '0') > limit)
                    return count;

                if ((x[i] - '0') < maxDigit)
                    tight = false;
            }

            string candidate = x.Substring(0, prefixLen) + s;
            if (String.Compare(candidate, x) <= 0)
            {
                count++;
            }

            return count;
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Enter start, finish, limit, and string s (separated by spaces): ");
                string input = Console.ReadLine();
                var parts = input.Split(' ');
                if (parts.Length != 4)
                {
                    Console.WriteLine("Invalid input format. Please try again.");
                    continue;
                }

                long start = long.Parse(parts[0]);
                long finish = long.Parse(parts[1]);
                int limit = int.Parse(parts[2]);
                string s = parts[3];

                if (!IsValidInput(start, finish, limit, s)) continue;

                var result = NumberOfPowerfulInt(start, finish, limit, s);
                Console.WriteLine("Powerful Integers: " + string.Join(", ", result));
                break;
            }
        }
    }
}
