using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Defuse_the_bomb
{
//  You have a bomb to defuse, and your time is running out! Your informer will provide you
//  with a circular array code of length of n and a key k.
//  To decrypt the code, you must replace every number.All the numbers are replaced simultaneously.
//  If k > 0, replace the ith number with the sum of the next k numbers.
//  If k < 0, replace the ith number with the sum of the previous k numbers.
//  If k == 0, replace the ith number with 0.
//  As code is circular, the next element of code[n - 1] is code[0], and the previous element of code[0] is code[n - 1].
//  Given the circular array code and an integer key k, return the decrypted code to defuse the bomb!
    public class Program
    {
        public static int[] Decrypt(int[] code, int k)
        {
            int n = code.Length; int[] result = new int[n]; if (k == 0) { 
                return result; 
            }
            for (int i = 0; i < n; i++) 
            { 
                int sum = 0; 
                for (int j = 1; j <= Math.Abs(k); j++) 
                { 
                    if (k > 0) 
                    { 
                        sum += code[(i + j) % n]; 
                    } 
                    else 
                    { 
                        sum += code[(i - j + n) % n]; 
                    } 
                } result[i] = sum; 
            }
            return result;
        }
        public static void Main()
        {
            Console.Write("Please enter the elements of the array: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The array isn't empty!");
                Console.ReadKey();
                return;
            }
            string[] stringArray = input.Split(' ');
            int[] nums = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                nums[i] = int.Parse(stringArray[i]);
            }
            Console.WriteLine("Please enter the target: ");
            var targetString = Console.ReadLine();
            if (string.IsNullOrEmpty(targetString))
            {
                Console.WriteLine("The target isn't empty!");
                Console.ReadKey();
                return;
            }

            if (!int.TryParse(targetString, out _))
            {
                Console.WriteLine("The target is invalid!");
                Console.ReadKey();
                return;
            }
            var target = int.Parse(targetString);
            var result = Decrypt(nums, target);
            Console.WriteLine("The decrypted code to defuse the bomb is: {0}", string.Join(", ", result));
            Console.ReadKey();
        }
    }
}
