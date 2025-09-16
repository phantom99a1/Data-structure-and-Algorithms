namespace Replace_Non_Coprime_Numbers_in_Array
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            var ans = new List<int>();

            foreach (var num in nums)
            {
                int current = num;
                while (ans.Count > 0 && GCD(ans[^1], current) > 1)
                {
                    current = LCM(ans[^1], current);
                    ans.RemoveAt(ans.Count - 1);
                }
                ans.Add(current);
            }

            return ans;
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private int LCM(int a, int b)
        {
            return a / GCD(a, b) * b;
        }
    }

    // Example usage:
    // var sol = new Solution();
    // var result = sol.ReplaceNonCoprimes(new int[] { 4, 6, 7, 30 });
    // Console.WriteLine(string.Join(", ", result)); // Output: 12, 7, 30
}
