namespace Minimum_Operations_to_Make_Array_Sum_Divisible_by_K
{
    public class Solution
    {
        public int MinOperations(int[] Nums, int K)
        {
            int Sum = 0;

            for (int i = 0; i < Nums.Length; i++)
            {
                Sum += Nums[i];
            }

            return Sum % K;
        }
    }
}
