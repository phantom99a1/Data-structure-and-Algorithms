namespace Find_the_Count_of_Good_Integers
{
    /*You are given two positive integers n and k. An integer x is called k-palindromic if:
    x is a palindrome.
    x is divisible by k.
    An integer is called good if its digits can be rearranged to form a k-palindromic integer. 
    For example, for k = 2, 2020 can be rearranged to form the k-palindromic integer 2002, 
    whereas 1010 cannot be rearranged to form a k-palindromic integer.Return the count of good integers containing n digits.
    Note that any integer must not have leading zeros, neither before nor after rearrangement. 
    For example, 1010 cannot be rearranged to form 101.
    
    Constraint:
    1 <= n <= 10
    1 <= k <= 9
     */
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter n and k separated by a space:");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');

                if (parts.Length != 2 || !int.TryParse(parts[0], out int n) || !int.TryParse(parts[1], out int k))
                {
                    Console.WriteLine("Invalid input. Please enter two integers separated by a space.");
                    continue;
                }

                List<string> errors = ValidateInput(n, k);
                if (errors.Count > 0)
                {
                    Console.WriteLine("Errors:");
                    errors.ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine(CountGoodIntegers(n, k));
                    break;
                }
            }
        }

        static List<string> ValidateInput(int n, int k)
        {
            var errors = new List<string>();
            if (n < 1 || n > 10) errors.Add("n must be between 1 and 10.");
            if (k < 1 || k > 9) errors.Add("k must be between 1 and 9.");
            return errors;
        }

        public static long CountGoodIntegers(int n, int k)
        {
            var dict = new HashSet<string>();
            int baseVal = (int)Math.Pow(10, (n - 1) / 2);
            int skip = n & 1;
            /* Enumerate the number of palindrome numbers of n digits */
            for (int i = baseVal; i < baseVal * 10; i++)
            {
                string s = i.ToString();
                s += new string(s.Reverse().Skip(skip).ToArray());
                long palindromicInteger = long.Parse(s);
                /* If the current palindrome number is a k-palindromic integer */
                if (palindromicInteger % k == 0)
                {
                    char[] chars = s.ToCharArray();
                    Array.Sort(chars);
                    dict.Add(new string(chars));
                }
            }

            long[] factorial = new long[n + 1];
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial[i] = factorial[i - 1] * i;
            }

            long ans = 0;
            foreach (string s in dict)
            {
                int[] cnt = new int[10];
                foreach (char c in s)
                {
                    cnt[c - '0']++;
                }
                /* Calculate permutations and combinations */
                long tot = (n - cnt[0]) * factorial[n - 1];
                foreach (int x in cnt)
                {
                    tot /= factorial[x];
                }
                ans += tot;
            }

            return ans;
        }
    }
}
