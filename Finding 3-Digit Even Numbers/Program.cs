namespace Finding_3_Digit_Even_Numbers
{
    /*You are given an integer array digits, where each element is a digit. The array may contain duplicates.

    You need to find all the unique integers that follow the given requirements:

    The integer consists of the concatenation of three elements from digits in any arbitrary order.
    The integer does not have leading zeros.
    The integer is even.
    For example, if the given digits were [1, 2, 3], integers 132 and 312 follow the requirements.

    Return a sorted array of the unique integers.*/
    public class Solution
    {
        public int[] FindEvenNumbers(int[] digits)
        {
            List<int> result = new List<int>();

            for (int i = 100; i < 1000; i += 2)
            {
                int three = i / 100;
                int two = (i / 10) % 10;
                int one = i % 10;

                List<int> temp = new List<int>(digits);

                if (temp.Contains(three))
                {
                    temp.Remove(three);
                    if (temp.Contains(two))
                    {
                        temp.Remove(two);
                        if (temp.Contains(one))
                        {
                            result.Add(i);
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}
