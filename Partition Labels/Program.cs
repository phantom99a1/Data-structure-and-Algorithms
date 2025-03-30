namespace Partition_Labels
{
    /*You are given a string s. We want to partition the string into as many parts as possible so that each letter appears 
     in at most one part. For example, the string "ababcc" can be partitioned into ["abab", "cc"], 
    but partitions such as ["aba", "bcc"] or ["ab", "ab", "cc"] are invalid.
    Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
    Return a list of integers representing the size of these parts.
    
    Constraint:
    1 <= s.length <= 500
    s consists of lowercase English letters.
     */
    
    class PartitionLabels
    {
        static List<int> PartitionLabelsFunc(string s)
        {
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                last[s[i] - 'a'] = i;
            }

            List<int> partitions = new List<int>();
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, last[s[i] - 'a']);
                if (i == end)
                {
                    partitions.Add(end - start + 1);
                    start = i + 1;
                }
            }
            return partitions;
        }

        static bool IsValidInput(string input)
        {
            if (input.Length < 1 || input.Length > 500)
            {
                Console.WriteLine("Error: Input length must be between 1 and 500.");
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-z]+$"))
            {
                Console.WriteLine("Error: Input must consist only of lowercase English letters.");
                return false;
            }
            return true;
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                if (IsValidInput(input))
                {
                    Console.WriteLine("Partition sizes: " + string.Join(", ", PartitionLabelsFunc(input)));
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }
}
