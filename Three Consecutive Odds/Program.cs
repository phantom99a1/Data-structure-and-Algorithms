namespace Three_Consecutive_Odds
{
    /*Given an integer array arr, return true if there are three consecutive odd numbers in the array. Otherwise, return false.
    
    Constraint:
    1 <= arr.length <= 1000
    1 <= arr[i] <= 1000
    */
    public class Solution
    {
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] % 2 != 0 && arr[i + 1] % 2 != 0 && arr[i + 2] % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
