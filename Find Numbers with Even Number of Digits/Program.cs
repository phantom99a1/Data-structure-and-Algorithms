namespace Find_Numbers_with_Even_Number_of_Digits
{
    /*Given an array nums of integers, return how many of them contain an even number of digits.
     
    Constraint:
    1 <= nums.length <= 500
    1 <= nums[i] <= 10^5
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public int FindNumbers(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i].ToString().Length % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
