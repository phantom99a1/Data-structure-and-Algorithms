namespace Minimum_Number_of_Increments_on_Subarrays_to_Form_a_Target_Array
{
    public class Solution
    {
        public int MinNumberOperations(int[] target)
        {
            int operations = 0;
            int prev = 0;

            foreach (int num in target)
            {
                operations += Math.Max(0, num - prev);
                prev = num;
            }

            return operations;
        }
    }
}
