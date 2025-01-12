namespace Check_if_a_Parentheses_String_Can_Be_Valid
{
    /*A parentheses string is a non-empty string consisting only of '(' and ')'. It is valid if any of the following 
    conditions is true:
    It is ().
    It can be written as AB (A concatenated with B), where A and B are valid parentheses strings.
    It can be written as (A), where A is a valid parentheses string.
    You are given a parentheses string s and a string locked, both of length n. locked is a binary string consisting only 
    of '0's and '1's. For each index i of locked,
    If locked[i] is '1', you cannot change s[i].
    But if locked[i] is '0', you can change s[i] to either '(' or ')'.
    Return true if you can make s a valid parentheses string. Otherwise, return false.
    
     Constraint:
    n == s.length == locked.length
    1 <= n <= 10^5
    s[i] is either '(' or ')'.
    locked[i] is either '0' or '1'.
     */
    
    public class Program
    {
        private const int minLength = 1;
        private const int maxLength = 100000;
        public static void Main()
        {
            string s;
            do
            {
                Console.Write("Enter the string s: ");
                s = Console.ReadLine() ?? "";

                if (s.Length < minLength || s.Length > maxLength)
                {
                    Console.WriteLine($"The length of parentheses string  must be between {minLength} and {maxLength}.");
                    continue;
                }

                if(s.Any(x => x != '(' && x != ')'))
                {
                    Console.WriteLine($"The parentheses string must only include ( and ).");
                    continue;
                }

                break;

            } while (true);

            string locked;
            do
            {
                Console.Write("Enter the string locked: ");
                locked = Console.ReadLine() ?? "";

                if (s.Length != locked.Length || !IsValidLockedString(locked))
                {
                    Console.WriteLine("Locked must have the same length as parentheses string and consist only of 0 and 1.");
                    continue;
                }

                break;

            } while (true);

            Console.WriteLine(CanBeValid(s, locked));
            Console.ReadKey();
        }

        public static bool CanBeValid(string s, string locked)
        {
            if (s.Length % 2 != 0) return false; // If length is odd, it can't be valid

            int balance = 0;
            int unlock = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (locked[i] == '1')
                {
                    balance += (s[i] == '(') ? 1 : -1;
                }
                else
                {
                    unlock++;
                }
                if (balance + unlock < 0) return false;
            }

            balance = 0;
            unlock = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (locked[i] == '1')
                {
                    balance += (s[i] == ')') ? 1 : -1;
                }
                else
                {
                    unlock++;
                }
                if (balance + unlock < 0) return false;
            }

            return true;
        }

        public static bool IsValidLockedString(string locked)
        {
            foreach (char c in locked)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
