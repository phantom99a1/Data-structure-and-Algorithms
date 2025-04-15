namespace Count_Good_Triplets_in_an_Array
{
    /*You are given two 0-indexed arrays nums1 and nums2 of length n, both of which are permutations of [0, 1, ..., n - 1].
    A good triplet is a set of 3 distinct values which are present in increasing order by position both in nums1 and nums2. 
    In other words, if we consider pos1v as the index of the value v in nums1 and pos2v as the index of the value v in nums2, 
    then a good triplet will be a set (x, y, z) where 0 <= x, y, z <= n - 1, 
    such that pos1x < pos1y < pos1z and pos2x < pos2y < pos2z. Return the total number of good triplets.
    
     Constraint:
    n == nums1.length == nums2.length
    3 <= n <= 10^5
    0 <= nums1[i], nums2[i] <= n - 1
    nums1 and nums2 are permutations of [0, 1, ..., n - 1].
     */
    using System;
    using System;

    public class FenwickTree
    {
        private int[] tree;

        public FenwickTree(int size)
        {
            tree = new int[size + 1];
        }

        public void Update(int index, int delta)
        {
            index++;
            while (index < tree.Length)
            {
                tree[index] += delta;
                index += index & -index;
            }
        }

        public int Query(int index)
        {
            index++;
            int res = 0;
            while (index > 0)
            {
                res += tree[index];
                index -= index & -index;
            }
            return res;
        }
    }
    public class Solution
    {
        public static int GoodTriplets(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int[] pos2 = new int[n];
            int[] reversedIndexMapping = new int[n];

            for (int i = 0; i < n; i++)
            {
                pos2[nums2[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                reversedIndexMapping[pos2[nums1[i]]] = i;
            }

            FenwickTree tree = new FenwickTree(n);
            int res = 0;

            for (int value = 0; value < n; value++)
            {
                int pos = reversedIndexMapping[value];
                int left = tree.Query(pos);
                tree.Update(pos, 1);
                int right = n - 1 - pos - (value - left);
                res += left * right;
            }

            return res;
        }

        public static void Main(string[] args)
        {
            int[] nums1 = { 2, 0, 1, 3 };
            int[] nums2 = { 0, 1, 2, 3 };
            Console.WriteLine(GoodTriplets(nums1, nums2)); // Output: 1
        }
    }
}
