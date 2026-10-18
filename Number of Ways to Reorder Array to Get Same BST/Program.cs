namespace Number_of_Ways_to_Reorder_Array_to_Get_Same_BST
{
    public class Solution
    {
        readonly int mod = 1000000007; //% 10^9 + 7 is requirement of problem
        long[,] coefficientTable;
        public int NumOfWays(int[] nums)
        {
            GenerateBinomialCoefficientTable(nums.Length);
            return (NumOfWays(nums.ToList()) - 1) % mod;
        }
        public int NumOfWays(List<int> nums)
        {
            if (nums.Count <= 2)
                return 1;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int root = nums[0];

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < root)
                    left.Add(nums[i]);
                else
                    right.Add(nums[i]);
            }

            long waysLeft = NumOfWays(left);
            long waysRight = NumOfWays(right);
            long subtrees = (waysLeft * waysRight) % mod;
            long binomialCoefficient = coefficientTable[nums.Count - 1, left.Count];
            return (int)((binomialCoefficient * subtrees) % mod);
        }
        public void GenerateBinomialCoefficientTable(int size)
        {
            coefficientTable = new long[size, size];
            for (int i = 0; i < size; ++i)
            {
                coefficientTable[i, 0] = 1;
                coefficientTable[i, i] = 1;
            }
            for (int i = 2; i < size; i++)
                for (int j = 1; j < i; j++)
                    coefficientTable[i, j] = (coefficientTable[i - 1, j - 1] + coefficientTable[i - 1, j]) % mod;
        }
    }
}
